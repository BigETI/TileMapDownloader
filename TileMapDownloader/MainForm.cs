using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Time map downloader namespace
/// </summary>
namespace TileMapDownloader
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class MainForm : MaterialForm
    {
        /// <summary>
        /// Thread pool
        /// </summary>
        private CountableThreadPool threadPool;

        /// <summary>
        /// Main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            MaterialSkinManager material_skin_manager = MaterialSkinManager.Instance;
            material_skin_manager.AddFormToManage(this);
            material_skin_manager.Theme = MaterialSkinManager.Themes.DARK;
            material_skin_manager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue800, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);

            threadPool = new CountableThreadPool(Environment.ProcessorCount - (Environment.ProcessorCount / 4));
        }

        /// <summary>
        /// Swap values correctly
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        private static void SwapValuesCorrectly<T>(ref T min, ref T max) where T : IComparable<T>
        {
            if (max.CompareTo(min) < 0)
            {
                T t = min;
                min = max;
                max = t;
            }
        }

        /// <summary>
        /// Download button click event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            int x_min;
            int x_max;
            int y_min;
            int y_max;
            if (int.TryParse(xMinimumTextField.Text.Trim(), out x_min) && int.TryParse(xMaximumTextField.Text.Trim(), out x_max) && int.TryParse(yMinimumTextField.Text.Trim(), out y_min) && int.TryParse(yMaximumTextField.Text.Trim(), out y_max))
            {
                if ((sourceTextField.Text.Trim().Length > 0) && (destinationTextField.Text.Trim().Length > 0))
                {
                    string source = sourceTextField.Text;
                    string destination = destinationTextField.Text;
                    xMinimumTextField.Enabled = false;
                    xMaximumTextField.Enabled = false;
                    yMinimumTextField.Enabled = false;
                    yMaximumTextField.Enabled = false;
                    sourceTextField.Enabled = false;
                    destinationTextField.Enabled = false;
                    downloadButton.Enabled = false;
                    abortButton.Enabled = true;
                    SwapValuesCorrectly(ref x_min, ref x_max);
                    SwapValuesCorrectly(ref y_min, ref y_max);
                    downloadProgressBar.Value = 0;
                    downloadProgressBar.Maximum = ((x_max - x_min) + 1) * ((y_max - y_min) + 1);
                    downloadProgressBar.Visible = true;
                    for (int x, y = y_min; y <= y_max; y++)
                    {
                        for (x = x_min; x <= x_max; x++)
                        {
                            threadPool.AddToQueue((point) =>
                            {
                                if (point is Point)
                                {
                                    Point p = (Point)point;
                                    string src = string.Format(source, p.X, p.Y);
                                    string dest = Path.GetFullPath(string.Format(destination, p.X, p.Y));
                                    string directory = Path.GetDirectoryName(destination);
                                    if (!(Directory.Exists(directory)))
                                    {
                                        try
                                        {
                                            Directory.CreateDirectory(directory);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.Error.WriteLine(ex.Message);
                                        }
                                    }
                                    try
                                    {
                                        using (HttpClient client = new HttpClient())
                                        {
                                            Task<byte[]> task = client.GetByteArrayAsync(src);
                                            byte[] data = task.Result;
                                            if (data != null)
                                            {
                                                if (data.Length > 0)
                                                {
                                                    using (FileStream file = File.Open(dest, FileMode.Create))
                                                    {
                                                        file.Write(data, 0, data.Length);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Error.WriteLine(ex.Message);
                                    }
                                }
                            }, new Point(x, y));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please specify something for source and destination.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please use numbers for x minimum, x maximum, y minimum and y maximum to download tile maps.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Threads timer tick event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void threadsTimer_Tick(object sender, EventArgs e)
        {
            if (downloadProgressBar.Visible)
            {
                int count = threadPool.OverallCount;
                if (count <= 0)
                {
                    xMinimumTextField.Enabled = true;
                    xMaximumTextField.Enabled = true;
                    yMinimumTextField.Enabled = true;
                    yMaximumTextField.Enabled = true;
                    sourceTextField.Enabled = true;
                    destinationTextField.Enabled = true;
                    downloadButton.Enabled = true;
                    abortButton.Enabled = false;
                    downloadProgressBar.Visible = false;
                }
                else
                {
                    downloadProgressBar.Value = downloadProgressBar.Maximum - count;
                }
            }
        }

        /// <summary>
        /// Abort button click event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void abortButton_Click(object sender, EventArgs e)
        {
            threadPool.Abort();
        }

        /// <summary>
        /// Main form form closed event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Form closed event arguments</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            threadPool.Dispose();
        }
    }
}

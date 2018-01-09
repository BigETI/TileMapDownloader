using System;
using System.Threading;

/// <summary>
/// Tile map download namespace
/// </summary>
namespace TileMapDownloader
{
    /// <summary>
    /// Parameterized thread class
    /// </summary>
    public class ParameterizedThread : IDisposable
    {
        /// <summary>
        /// Thread
        /// </summary>
        private Thread thread;

        /// <summary>
        /// Parameter
        /// </summary>
        private object parameter;

        /// <summary>
        /// Thread
        /// </summary>
        public Thread Thread
        {
            get
            {
                return thread;
            }
        }

        /// <summary>
        /// Parameter
        /// </summary>
        public object Parameter
        {
            get
            {
                return parameter;
            }
        }

        /// <summary>
        /// COnstructor
        /// </summary>
        /// <param name="thread">Thread</param>
        public ParameterizedThread(Thread thread)
        {
            this.thread = thread;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thread">Thread</param>
        /// <param name="parameter">Parameter</param>
        public ParameterizedThread(Thread thread, object parameter)
        {
            this.thread = thread;
            this.parameter = parameter;
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            if (thread != null)
            {
                if (parameter == null)
                {
                    thread.Start();
                }
                else
                {
                    thread.Start(parameter);
                }
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (thread != null)
            {
                try
                {
                    thread.Abort();
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
    }
}

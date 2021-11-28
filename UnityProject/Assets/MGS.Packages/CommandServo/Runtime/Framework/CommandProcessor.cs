/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandProcessor.cs
 *  Description  :  Processor of Command.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Threading;

namespace MGS.CommandServo
{
    /// <summary>
    /// Processor of Command (Singleton, Lazy, Thread safety).
    /// </summary>
    public sealed class CommandProcessor : CommandController, ICommandProcessor
    {
        #region Singleton
        /// <summary>
        /// Instance of processor (Lazy).
        /// </summary>
        public static CommandProcessor Instance { get { return Agent.instance; } }

        /// <summary>
        /// Agent provide the single instance (Thread safety).
        /// </summary>
        private class Agent { internal static readonly CommandProcessor instance = new CommandProcessor(); }
        #endregion

        #region Field and Property
        /// <summary>
        /// Processor is active?
        /// </summary>
        public bool IsActive { set; get; }

        /// <summary>
        /// Interval of processor run time (ms).
        /// </summary>
        public int Interval { set; get; }
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private CommandProcessor()
        {
            IsActive = true;
            Interval = 200;
            new Thread(ThreadCruise) { IsBackground = true }.Start();
        }

        /// <summary>
        /// Thread cruise.
        /// </summary>
        private void ThreadCruise()
        {
            while (true)
            {
                if (IsActive)
                {
                    ScanCommandExecute();
                }
                Thread.Sleep(Interval);
            }
        }
        #endregion
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandAdapter.cs
 *  Description  :  Interface for Command Adapter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Interface for Command Adapter.
    /// </summary>
    public interface ICommandAdapter
    {
        #region Property
        /// <summary>
        /// Command IO.
        /// </summary>
        ICommandIO CommandIO { set; get; }

        /// <summary>
        /// Command parser.
        /// </summary>
        ICommandParser CommandParser { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Enqueue command to pending buffer.
        /// </summary>
        /// <param name="command">Command to enqueue.</param>
        void EnqueueCommand(Command command);

        /// <summary>
        /// Discard command from pending buffer.
        /// </summary>
        /// <param name="command">Command to discard.</param>
        void DiscardCommand(Command command);

        /// <summary>
        /// Dequeue commands from pending and IO buffer.
        /// </summary>
        /// <returns>Current commands.</returns>
        IEnumerable<Command> DequeueCommands();

        /// <summary>
        /// Respond command to IO.
        /// </summary>
        /// <param name="command">Command to respond.</param>
        void RespondCommand(Command command);
        #endregion
    }
}
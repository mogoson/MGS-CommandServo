/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandAdapter.cs
 *  Description  :  Adapter of Command.
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
    /// Adapter of Command.
    /// </summary>
    public class CommandAdapter : ICommandAdapter
    {
        #region Field and Property
        /// <summary>
        /// Command IO.
        /// </summary>
        public ICommandIO CommandIO { set; get; }

        /// <summary>
        /// Command parser.
        /// </summary>
        public ICommandParser CommandParser { set; get; }

        /// <summary>
        /// Command pending buffer.
        /// </summary>
        protected List<Command> commandBuffer = new List<Command>();

        /// <summary>
        /// The settings is valid?
        /// </summary>
        protected bool IsSettingsValid
        {
            get
            {
                if (CommandIO == null || CommandParser == null)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="commandIO">Command IO.</param>
        /// <param name="commandParser">Command parser.</param>
        public CommandAdapter(ICommandIO commandIO, ICommandParser commandParser)
        {
            CommandIO = commandIO;
            CommandParser = commandParser;
        }

        /// <summary>
        /// Enqueue command to pending buffer.
        /// </summary>
        /// <param name="command">Command to enqueue.</param>
        public void EnqueueCommand(Command command)
        {
            if (commandBuffer.Contains(command))
            {
                return;
            }

            commandBuffer.Add(command);
        }

        /// <summary>
        /// Discard command from pending buffer.
        /// </summary>
        /// <param name="command">Command to discard.</param>
        public void DiscardCommand(Command command)
        {
            commandBuffer.Remove(command);
        }

        /// <summary>
        /// Dequeue commands from pending and IO buffer.
        /// </summary>
        /// <returns>Current commands.</returns>
        public virtual IEnumerable<Command> DequeueCommands()
        {
            if (!IsSettingsValid)
            {
                return null;
            }

            var ioBuffer = CommandIO.ReadBuffer();
            var ioCommands = CommandParser.ToCommands(ioBuffer);
            if (ioCommands != null)
            {
                commandBuffer.AddRange(ioCommands);
            }

            var commands = commandBuffer.ToArray();
            commandBuffer.Clear();
            return commands;
        }

        /// <summary>
        /// Respond command to IO.
        /// </summary>
        /// <param name="command">Command to respond.</param>
        public virtual void RespondCommand(Command command)
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var cmdBuffer = CommandParser.ToBuffer(command);
            CommandIO.WriteBuffer(cmdBuffer);
        }
        #endregion
    }
}
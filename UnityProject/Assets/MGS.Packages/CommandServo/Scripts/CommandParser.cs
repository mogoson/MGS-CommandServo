/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandParser.cs
 *  Description  :  Command Parser.
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
    /// Command Parser.
    /// </summary>
    public abstract class CommandParser : ICommandParser
    {
        #region Public Method
        /// <summary>
        /// Parser byte buffer to commands.
        /// </summary>
        /// <param name="buffer">Buffer to parse.</param>
        /// <returns>Commands from buffer.</returns>
        public abstract byte[] ToBuffer(Command command);

        /// <summary>
        /// Parser command to byte buffer.
        /// </summary>
        /// <param name="command">Command to parse.</param>
        /// <returns>Buffer from command.</returns>
        public abstract IEnumerable<Command> ToCommands(byte[] buffer);
        #endregion
    }
}
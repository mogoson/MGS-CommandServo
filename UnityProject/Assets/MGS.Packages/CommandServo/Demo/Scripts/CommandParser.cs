/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandParser.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.CommandServo.Demo
{
    public class CommandParser : ICommandParser
    {
        #region Field and Property
        private readonly List<string> codes = new List<string>
        {
            "CSC_MOVE", "CSC_ROTATE", "CSC_COLOR"
        };
        #endregion

        #region Public Method
        public byte[] ToBuffer(Command command)
        {
            var buffer = new byte[3];
            var index = codes.IndexOf(command.Code);
            buffer[index] = (byte)command.Args[0];
            return buffer;
        }

        public IEnumerable<Command> ToCommands(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                return null;
            }

            var commands = new List<Command>();
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0)
                {
                    continue;
                }
                commands.Add(new Command(codes[i], buffer[i]));
            }
            return commands;
        }
        #endregion
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Command.cs
 *  Description  :  Define Command struct.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.CommandServo
{
    /// <summary>
    /// Command struct.
    /// </summary>
    public struct Command
    {
        #region Field and Property
        /// <summary>
        /// Code of command unit.
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// Args of command unit.
        /// </summary>
        public object[] Args { set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Code of command unit.</param>
        /// <param name="args">Args of command unit.</param>
        public Command(string code, params object[] args)
        {
            Code = code;
            Args = args;
        }
        #endregion
    }
}
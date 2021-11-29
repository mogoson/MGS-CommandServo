/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandIO.cs
 *  Description  :  Command IO.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

 namespace MGS.CommandServo
{
    /// <summary>
    /// Command IO.
    /// </summary>
    public abstract class CommandIO : ICommandIO
    {
        #region Public Method
        /// <summary>
        /// Read buffer from IO.
        /// </summary>
        /// <returns>Buffer from IO.</returns>
        public abstract byte[] ReadBuffer();

        /// <summary>
        /// Write buffer to IO.
        /// </summary>
        /// <param name="buffer">Buffer to IO.</param>
        public abstract void WriteBuffer(byte[] buffer);
        #endregion
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandProcessor.cs
 *  Description  :  Interface for Command Processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.CommandServo
{
    /// <summary>
    /// Interface for Command Processor.
    /// </summary>
    public interface ICommandProcessor : ICommandController
    {
        #region Property
        /// <summary>
        /// Processor is active?
        /// </summary>
        bool IsActive { set; get; }

        /// <summary>
        /// Interval of processor run time (ms).
        /// </summary>
        int Interval { set; get; }
        #endregion
    }
}
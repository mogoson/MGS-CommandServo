/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandController.cs
 *  Description  :  Interface for Command Controller.
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
    /// Interface for Command Controller.
    /// </summary>
    public interface ICommandController
    {
        #region Property
        /// <summary>
        /// Adapter of command.
        /// </summary>
        ICommandAdapter CommandAdapter { set; get; }

        /// <summary>
        /// Register of command unit.
        /// </summary>
        ICommandUnitRegister UnitRegister { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="commandAdapter">Adapter of command.</param>
        /// <param name="unitRegister">Register of command unit.</param>
        void Initialize(ICommandAdapter commandAdapter, ICommandUnitRegister unitRegister);

        /// <summary>
        /// Scan command from IO and execute.
        /// </summary>
        void ScanCommandExecute();
        #endregion
    }
}
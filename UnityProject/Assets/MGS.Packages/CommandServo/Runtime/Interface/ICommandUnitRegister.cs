/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandUnitRegister.cs
 *  Description  :  Interface for Command Unit Register.
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
    /// Interface for Command Unit Register.
    /// </summary>
    public interface ICommandUnitRegister
    {
        #region Property
        /// <summary>
        /// On command respond event.
        /// </summary>
        event Action<Command> OnRespondEvent;
        #endregion

        #region Method
        /// <summary>
        /// Register command unit.
        /// </summary>
        /// <param name="unit">Command unit.</param>
        void RegisterUnit(ICommandUnit unit);

        /// <summary>
        /// Unregister command unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        void UnregisterUnit(string code);

        /// <summary>
        /// Unregister command units.
        /// </summary>
        void UnregisterUnits();

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        void Execute(Command command);
        #endregion
    }
}
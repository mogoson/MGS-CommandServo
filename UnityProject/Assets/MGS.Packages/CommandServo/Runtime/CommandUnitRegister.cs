/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandUnitRegister.cs
 *  Description  :  Register of Command unit.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Register of Command unit.
    /// </summary>
    public class CommandUnitRegister : ICommandUnitRegister
    {
        #region Field and Property
        /// <summary>
        /// On command respond event.
        /// </summary>
        public event Action<Command> OnRespondEvent;

        /// <summary>
        /// Command units managed.
        /// </summary>
        protected Dictionary<string, ICommandUnit> units = new Dictionary<string, ICommandUnit>();
        #endregion

        #region Private Method
        /// <summary>
        /// On command unit respond.
        /// </summary>
        /// <param name="code">Command code.</param>
        /// <param name="args">Command args.</param>
        protected void OnUnitRespond(string code, params object[] args)
        {
            InvokeOnRespondEvent(new Command(code, args));
        }

        /// <summary>
        /// Invoke on respond event.
        /// </summary>
        /// <param name="command">Command to respond.</param>
        protected void InvokeOnRespondEvent(Command command)
        {
            if (OnRespondEvent != null)
            {
                OnRespondEvent.Invoke(command);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Register command unit.
        /// </summary>
        /// <param name="unit">Command unit.</param>
        public void RegisterUnit(ICommandUnit unit)
        {
            if (unit == null || string.IsNullOrEmpty(unit.Code))
            {
                return;
            }

            unit.OnRespondEvent += OnUnitRespond;
            units.Add(unit.Code, unit);
        }

        /// <summary>
        /// Unregister command unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        public void UnregisterUnit(string code)
        {
            if (units.ContainsKey(code))
            {
                units[code].OnRespondEvent -= OnUnitRespond;
                units.Remove(code);
            }
        }

        /// <summary>
        /// Unregister command units.
        /// </summary>
        public void UnregisterUnits()
        {
            foreach (var unit in units.Values)
            {
                unit.OnRespondEvent -= OnUnitRespond;
            }
            units.Clear();
        }

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        public virtual void Execute(Command command)
        {
            if (units.ContainsKey(command.Code))
            {
                units[command.Code].Execute(command.Args);
            }
        }
        #endregion
    }
}
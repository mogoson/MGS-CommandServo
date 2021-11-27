/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandController.cs
 *  Description  :  Controller of Command.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.CommandServo
{
    /// <summary>
    /// Controller of Command.
    /// </summary>
    public class CommandController : ICommandController
    {
        #region Field and Property
        /// <summary>
        /// Adapter of command.
        /// </summary>
        public ICommandAdapter CommandAdapter { set; get; }

        /// <summary>
        /// Register of command unit.
        /// </summary>
        public ICommandUnitRegister UnitRegister
        {
            set
            {
                if (unitRegister != null)
                {
                    unitRegister.OnRespondEvent -= OnUnitRespond;
                }

                if (value != null)
                {
                    value.OnRespondEvent += OnUnitRespond;
                }
                unitRegister = value;
            }
            get { return unitRegister; }
        }

        /// <summary>
        /// Register of command unit.
        /// </summary>
        protected ICommandUnitRegister unitRegister;

        /// <summary>
        /// The settings is valid?
        /// </summary>
        protected bool IsSettingsValid
        {
            get
            {
                if (CommandAdapter == null || UnitRegister == null)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// On unit respond.
        /// </summary>
        /// <param name="command">Respond Command.</param>
        protected virtual void OnUnitRespond(Command command)
        {
            if (!IsSettingsValid)
            {
                return;
            }

            CommandAdapter.RespondCommand(command);
        }
        #endregion

        #region Method
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="commandAdapter">Adapter of command.</param>
        /// <param name="unitRegister">Register of command unit.</param>
        public virtual void Initialize(ICommandAdapter commandAdapter, ICommandUnitRegister unitRegister)
        {
            CommandAdapter = commandAdapter;
            UnitRegister = unitRegister;
        }

        /// <summary>
        /// Scan command from IO and execute.
        /// </summary>
        public virtual void ScanCommandExecute()
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var commands = CommandAdapter.DequeueCommands();
            if (commands != null)
            {
                foreach (var command in commands)
                {
                    UnitRegister.Execute(command);
                }
            }
        }
        #endregion
    }
}
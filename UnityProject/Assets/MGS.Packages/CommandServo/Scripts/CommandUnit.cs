/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandUnit.cs
 *  Description  :  Command unit.
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
    /// Command unit.
    /// </summary>
    public abstract class CommandUnit : ICommandUnit
    {
        #region Field and Property
        /// <summary>
        /// Code of command unit.
        /// </summary>
        public virtual string Code { set; get; }

        /// <summary>
        /// On command unit respond event.
        /// </summary>
        public event Action<string, object[]> OnRespondEvent;
        #endregion

        #region Public Method
        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="args">Command args.</param>
        public abstract void Execute(params object[] args);
        #endregion

        #region
        /// <summary>
        /// Invoke on respond event.
        /// </summary>
        /// <param name="args">Command args.</param>
        protected void InvokeOnRespondEvent(object[] args)
        {
            if (OnRespondEvent != null)
            {
                OnRespondEvent.Invoke(Code, args);
            }
        }
        #endregion
    }
}
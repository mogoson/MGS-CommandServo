/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCommandUnit.cs
 *  Description  :  Mono Command unit.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.CommandServo
{
    /// <summary>
    /// Mono Command unit.
    /// </summary>
    public abstract class MonoCommandUnit : MonoBehaviour, ICommandUnit
    {
        /// <summary>
        /// Command unit code.
        /// </summary>
        [SerializeField]
        protected string code;

        /// <summary>
        /// Command unit code.
        /// </summary>
        public string Code
        {
            set { code = value; }
            get { return code; }
        }

        /// <summary>
        /// On command unit respond event.
        /// </summary>
        public event Action<string, object[]> OnRespondEvent;

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="args">Command args.</param>
        public abstract void Execute(params object[] args);

        /// <summary>
        /// Invoke OnRespondEvent.
        /// </summary>
        /// <param name="args"></param>
        protected void InvokeOnRespondEvent(object[] args)
        {
            if (OnRespondEvent == null)
            {
                return;
            }
            OnRespondEvent.Invoke(Code, args);
        }
    }
}
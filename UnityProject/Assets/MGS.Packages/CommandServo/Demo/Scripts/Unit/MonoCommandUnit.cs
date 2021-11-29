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
using System.Collections.Generic;
using UnityEngine;

namespace MGS.CommandServo
{
    public abstract class MonoCommandUnit : MonoBehaviour, ICommandUnit
    {
        [SerializeField]
        protected string code;

        public string Code
        {
            set { code = value; }
            get { return code; }
        }

        public event Action<string, object[]> OnRespondEvent;

        protected Queue<Action> actions = new Queue<Action>();

        protected virtual void Update()
        {
            lock (actions)
            {
                while (actions.Count > 0)
                {
                    actions.Dequeue().Invoke();
                }
            }
        }

        protected void BeginInvoke(Action action)
        {
            lock (actions)
            {
                actions.Enqueue(action);
            }
        }

        public void Execute(params object[] args)
        {
            //Execute in main thread.
            BeginInvoke(() => ExecuteCmd(args));
        }

        protected abstract void ExecuteCmd(params object[] args);

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
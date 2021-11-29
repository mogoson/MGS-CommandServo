/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandInitializer.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.CommandServo.Demo
{
    public class CommandInitializer : MonoBehaviour
    {
        #region Field and Property
        public MonoCommandIO commandIO;
        public Transform commandUnits;
        #endregion

        #region Private Method
        private void Start()
        {
            var register = new CommandUnitRegister();
            var units = commandUnits.GetComponentsInChildren<MonoCommandUnit>(true);
            foreach (var unit in units)
            {
                register.RegisterUnit(unit);
            }

            var adapter = new CommandAdapter(commandIO, new CommandParser());
            CommandProcessor.Instance.Initialize(adapter, register);
        }
        #endregion
    }
}
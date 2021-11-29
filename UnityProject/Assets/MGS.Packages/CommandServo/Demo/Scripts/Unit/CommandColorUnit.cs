/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandColorUnit.cs
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
    [RequireComponent(typeof(MeshRenderer))]
    public class CommandColorUnit : MonoCommandUnit
    {
        #region Field and Property
        public Color[] colors = new Color[]
        {
            Color.blue, Color.green, Color.red
        };

        private MeshRenderer meshRenderer;
        #endregion

        #region Private
        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        protected override void ExecuteCmd(params object[] args)
        {
            var index = int.Parse(args[0].ToString()) - 1;
            if (index < 0 || index >= colors.Length)
            {
                return;
            }

            meshRenderer.material.color = colors[index];
            InvokeOnRespondEvent(new object[] { (byte)0 });
        }
        #endregion
    }
}
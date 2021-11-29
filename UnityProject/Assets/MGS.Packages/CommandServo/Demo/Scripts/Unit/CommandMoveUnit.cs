/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderMoveUnit.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.CommandServo.Demo
{
    public class CommandMoveUnit : MonoCommandUnit
    {
        #region Private
        private IEnumerator DelayRevert(float displacement, float time)
        {
            yield return new WaitForSeconds(time);
            transform.Translate(Vector3.up * displacement);
            InvokeOnRespondEvent(new object[] { (byte)0 });
        }

        protected override void ExecuteCmd(params object[] args)
        {
            var displacement = float.Parse(args[0].ToString());
            transform.Translate(Vector3.up * displacement);

            StopAllCoroutines();
            StartCoroutine(DelayRevert(-displacement, 1.0f));
        }
        #endregion
    }
}
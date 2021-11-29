/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandRotateUnit.cs
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
    public class CommandRotateUnit : MonoCommandUnit
    {
        #region Private
        private IEnumerator KeepRotate(float speed, float time)
        {
            var timer = 0f;
            while (timer < time)
            {
                timer += Time.deltaTime;
                transform.Rotate(Vector3.forward * speed);
                yield return new WaitForEndOfFrame();
            }
            InvokeOnRespondEvent(new object[] { (byte)0 });
        }

        protected override void ExecuteCmd(params object[] args)
        {
            var speed = float.Parse(args[0].ToString());

            StopAllCoroutines();
            StartCoroutine(KeepRotate(speed, 5));
        }
        #endregion
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UDPCommandIO.cs
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
    public class UDPCommandIO : MonoCommandIO, ICommandIO
    {
        #region Field and Property
        #endregion

        #region Private Method
        #endregion

        #region Public Method
        public override byte[] ReadBuffer()
        {
            Debug.LogError("NotImplementedException");
            return null;
        }

        public override void WriteBuffer(byte[] buffer)
        {
            Debug.LogError("NotImplementedException");
        }
        #endregion
    }
}
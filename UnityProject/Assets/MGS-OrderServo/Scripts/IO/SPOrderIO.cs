/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SPOrderIO.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.OrderServo
{
    [AddComponentMenu("MGS/OrderServo/SPOrderIO")]
    public class SPOrderIO : MonoOrderIO, IOrderIO
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
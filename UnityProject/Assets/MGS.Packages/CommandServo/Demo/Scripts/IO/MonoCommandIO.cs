/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCommandIO.cs
 *  Description  :  Mono Command IO.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.CommandServo
{
    public abstract class MonoCommandIO : MonoBehaviour, ICommandIO
    {
        public abstract byte[] ReadBuffer();

        public abstract void WriteBuffer(byte[] buffer);
    }
}
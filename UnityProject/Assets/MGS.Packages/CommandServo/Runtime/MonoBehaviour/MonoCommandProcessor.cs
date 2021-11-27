/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCommandProcessor.cs
 *  Description  :  Mono Command Processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.CommandServo
{
    /// <summary>
    /// Mono Command Processor (Singleton, Lazy, Thread safety).
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class MonoCommandProcessor : MonoBehaviour, ICommandProcessor
    {
        #region Singleton
        /// <summary>
        /// Instance of processor (Lazy).
        /// </summary>
        public static MonoCommandProcessor Instance { get { return Agent.instance; } }

        /// <summary>
        /// Agent provide the single instance (Thread safety).
        /// </summary>
        private class Agent
        {
            internal static readonly MonoCommandProcessor instance;
            static Agent()
            {
                instance = new GameObject(typeof(MonoCommandProcessor).Name).AddComponent<MonoCommandProcessor>();
                DontDestroyOnLoad(instance);
            }
        }
        #endregion

        /// <summary>
        /// Processor is active?
        /// </summary>
        public bool IsActive { set; get; }

        /// <summary>
        /// Interval of processor run time (ms).
        /// </summary>
        public int Interval { set; get; }

        /// <summary>
        /// Adapter of command.
        /// </summary>
        public ICommandAdapter CommandAdapter
        {
            set { controller.CommandAdapter = value; }
            get { return controller.CommandAdapter; }
        }

        /// <summary>
        /// Register of command unit.
        /// </summary>
        public ICommandUnitRegister UnitRegister
        {
            set { controller.UnitRegister = value; }
            get { return controller.UnitRegister; }
        }

        /// <summary>
        /// Controller of Command.
        /// </summary>
        private ICommandController controller = new CommandController();

        /// <summary>
        /// Awake processor.
        /// </summary>
        private void Awake()
        {
            IsActive = true;
            Interval = 200;
            StartCoroutine(CoroutineCruise());
        }

        /// <summary>
        /// Coroutine cruise.
        /// </summary>
        /// <returns></returns>
        private IEnumerator CoroutineCruise()
        {
            while (true)
            {
                if (IsActive)
                {
                    ScanCommandExecute();
                }
                yield return new WaitForSeconds(Interval / 1000.0f);
            }
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="commandAdapter">Adapter of command.</param>
        /// <param name="unitRegister">Register of command unit.</param>
        public void Initialize(ICommandAdapter commandAdapter, ICommandUnitRegister unitRegister)
        {
            controller.Initialize(commandAdapter, unitRegister);
        }

        /// <summary>
        /// Scan command from IO and execute.
        /// </summary>
        public void ScanCommandExecute()
        {
            controller.ScanCommandExecute();
        }
    }
}
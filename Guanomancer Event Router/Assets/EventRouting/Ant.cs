using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Guanomancer.EventRouting
{
    public class Ant : MonoBehaviour
    {
        [SerializeField]
        private string _assemblyName;

        [SerializeField]
        private string _interfaceName;

        [ContextMenu("Get Assembly")]
        public void GetAssembly()
        {
            if (!AppDomain.CurrentDomain.GetAssemblyByName(_assemblyName, out Assembly assembly))
            {
                Debug.LogWarning($"Invalid assembly name {_assemblyName} or assembly not loadet.");
                return;
            }
            Debug.Log(assembly.FullName);
        }

        [ContextMenu("Get Type By Interface Name")]
        public void GetTypes()
        {
            if (!AppDomain.CurrentDomain.GetTypesByInterfaceName(_interfaceName, _assemblyName, out Type[] types))
            {
                Debug.LogWarning($"Invalid assembly name {_assemblyName} or assembly not loadet, or no types inherit specified interface.");
                return;
            }

            foreach(var type in types)
                Debug.Log(type.FullName);
        }
    }
}

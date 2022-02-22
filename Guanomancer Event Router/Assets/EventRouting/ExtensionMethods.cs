using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Guanomancer.EventRouting
{
    public static class AppDomainExtensions
    {
        public static bool GetAssemblyByName(this AppDomain domain, string assemblyName, out Assembly assembly)
        {
            assembly = domain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == assemblyName);

            if (assembly == null)
            {
                Debug.LogWarning($"Invalid assembly name {assemblyName} or assembly not loadet.");
                return false;
            }

            return true;
        }

        public static bool GetTypeByName(this AppDomain domain, string typeName, string assemblyName, out Type type)
        {
            if (!domain.GetAssemblyByName(assemblyName, out Assembly assembly))
            {
                type = null;
                return false;
            }

            type = assembly.GetType(typeName, false);
            return type != null;
        }

        public static bool GetTypesByInterfaceName(this AppDomain domain, string interfaceTypeName, string assemblyName, out Type[] types)
        {
            if (!domain.GetAssemblyByName(assemblyName, out Assembly assembly))
            {
                types = null;
                return false;
            }

            List<Type> typeList = new List<Type>();
            foreach(var t in assembly.GetTypes())
                if(t.GetInterface(interfaceTypeName) != null)
                    typeList.Add(t);

            types = typeList.ToArray();
            return types.Length > 0;
        }
    }
}
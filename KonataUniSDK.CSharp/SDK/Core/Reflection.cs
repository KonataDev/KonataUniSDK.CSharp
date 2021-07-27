using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KonataCSharp.SDK.EventArgs.BaseModel;
using KonataCSharp.SDK.EventArgs.Enums;
using KonataCSharp.SDK.EventArgs.Events;

namespace KonataCSharp.SDK.Core
{
    internal static class Reflection
    {
        private static Dictionary<Type, KonataEventTypeInfo> InterfaceContainer { get; } = GetIKonataEventTypes();
        private static Dictionary<Type, KonataEventTypeInfo> EventContainer { get; } = new();

        internal static object InvokeMethods(object eventargs)
        {
            var type = eventargs.GetType();

            if (!EventContainer.TryGetValue(type, out var info))
            {
                if (!InterfaceContainer.TryGetValue(type.GetCustomAttribute<InterfaceAttribute>()?.Interface!,
                    out info))
                    return null;
                EventContainer.Add(type, info);
            }

            return info.Instance != null
                ? info.MethodInfo.Invoke(info.Instance, new object[] {eventargs}) ?? KonataEventReturnType.Ignore
                : eventargs is StartupEventArgs or EnabledEventArgs
                    ? true
                    : KonataEventReturnType.Ignore;
        }

        internal static void InterfaceInitialize()
        {
            var definedTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly != Assembly.GetExecutingAssembly())
                .Select(i => i.DefinedTypes)
                .Aggregate((i, j) => i.Concat(j)).ToArray();


            if (definedTypes.Length > 0)
                foreach (var type in definedTypes)
                foreach (var intpe in type.ImplementedInterfaces.Where(i => InterfaceContainer.ContainsKey(i)))
                    InterfaceContainer[intpe].Instance =
                        Activator.CreateInstance(type) ??
                        throw new ApplicationException("Couldn't create bot instance.");
        }

        private static Dictionary<Type, KonataEventTypeInfo> GetIKonataEventTypes()
        {
            return (from type in Assembly.GetExecutingAssembly().DefinedTypes
                    from inte in type.ImplementedInterfaces
                    where inte == typeof(IKonataEvent)
                    select (type, type.GetMethods()[0]))
                .ToDictionary(i => i.type.AsType(),
                    i => new KonataEventTypeInfo {MethodInfo = i.Item2});
        }

        internal static object GetEventArgsInstance(KonataEventMetadata data)
        {
            return Activator.CreateInstance(
                Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(i =>
                        i.GetCustomAttribute<EventNameAttribute>()?.Name == data.eventName) ??
                typeof(KonataUnknownEventArgs), data);
        }

        private class KonataEventTypeInfo
        {
            internal MethodInfo MethodInfo { get; init; }
            internal object Instance { get; set; }
        }
    }
}
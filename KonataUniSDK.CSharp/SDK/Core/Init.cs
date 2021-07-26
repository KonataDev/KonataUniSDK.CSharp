using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.Core
{
    internal static class Init
    {
        private static readonly Type[] KonataEventTypes =
        {
            typeof(IOnStartup),
            typeof(IOnEnabled),
            typeof(IOnDestroy),
            typeof(IGroupPoke),
            typeof(IOnDisabled),
            typeof(IGroupMessage),
            typeof(IPrivateMessage),
            typeof(IGroupMuteMember),
            typeof(IGroupAdminChange),
            typeof(IGroupMessageRecall)
        };

        internal static Dictionary<Type, object> Container { get; } = new();

        internal static void InterfaceReflector()
        {
            var definedTypes = Assembly.GetEntryAssembly()?.DefinedTypes;

            if (definedTypes != null)
                foreach (var type in definedTypes)
                foreach (var inte in from inte in type.ImplementedInterfaces
                    where GetIKonataEvent(inte) != default
                    select inte)
                    Container.Add(GetIKonataEvent(inte),
                        Activator.CreateInstance(type) ??
                        throw new ApplicationException("Couldn't create bot instance"));
        }

        private static Type GetIKonataEvent(Type type)
        {
            return KonataEventTypes.FirstOrDefault(i => type == i);
        }
    }
}
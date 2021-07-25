using System;
using System.Linq;
using System.Reflection;
using KonataCSharp.SDK.Core.TinyIOC;
using KonataCSharp.SDK.EventArgs.Interfaces;

namespace KonataCSharp.SDK.Core
{
    internal static class Init
    {
        private static readonly Type[] KonataEventTypes =
        {
            typeof(IOnStartup), typeof(IOnEnabled), typeof(IOnDestroy), typeof(IOnDisabled), typeof(IGroupMessage),
            typeof(IPrivateMessage), typeof(IGroupAdminChange)
        };

        internal static TinyIoCContainer Container { get; } = new();

        internal static void InterfaceReflector()
        {
            var definedTypes = Assembly.GetEntryAssembly()?.DefinedTypes;

            if (definedTypes != null)
                foreach (var type in definedTypes)
                foreach (var inte in from inte in type.ImplementedInterfaces
                    let realtype = GetIKonataEvent(inte)
                    where realtype != default
                    select inte)
                    Container.Register(GetIKonataEvent(inte), type);
        }


        private static Type GetIKonataEvent(Type type)
        {
            return KonataEventTypes.FirstOrDefault(i => type == i);
        }
    }
}
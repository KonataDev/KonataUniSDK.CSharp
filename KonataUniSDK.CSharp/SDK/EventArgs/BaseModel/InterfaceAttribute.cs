using System;

namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    internal class InterfaceAttribute : Attribute
    {
        internal InterfaceAttribute(Type type)
        {
            Interface = type;
        }

        internal Type Interface { get; }
    }
}
using System;

namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    internal class InterfaceAttribute : Attribute
    {
        internal Type Interface { get; set; }

        internal InterfaceAttribute(Type type)
        {
            Interface = type;
        }
    }
}

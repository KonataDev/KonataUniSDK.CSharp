using System;

namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    internal class EventNameAttribute : Attribute
    {
        internal EventNameAttribute(string name)
        {
            Name = name;
        }

        internal string Name { get; }
    }
}
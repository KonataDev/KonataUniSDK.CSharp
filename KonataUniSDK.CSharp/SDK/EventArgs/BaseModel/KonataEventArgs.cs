namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    public abstract class KonataEventArgs
    {
        internal KonataEventArgs(KonataEventMetadata _)
        {
        }

        public KonataApi Api { get; } = new();
    }
}
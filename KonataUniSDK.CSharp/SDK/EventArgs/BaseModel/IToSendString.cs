namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    /// <summary>
    ///     将抽象Message转换为string的接口
    /// </summary>
    public interface IToSendString
    {
        /// <summary>
        ///     将抽象Message转换为string
        /// </summary>
        string ToSendString();
    }
}
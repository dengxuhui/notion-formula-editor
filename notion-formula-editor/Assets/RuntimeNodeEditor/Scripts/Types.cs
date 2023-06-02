namespace RuntimeNodeEditor
{
    public enum MathOperations
    {
        Multiply,
        Divide,
        Add,
        Subtract
    }

    public enum ConnectionType
    {
        Single,
        Multiple
    }

    /// <summary>
    /// 端口类型
    /// </summary>
    public enum SocketType
    {
        /// <summary>
        /// 入口socket
        /// </summary>
        Input,
        /// <summary>
        /// 出口socket
        /// </summary>
        Output,
    }
}
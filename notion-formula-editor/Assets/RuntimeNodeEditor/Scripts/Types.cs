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
    
    
    /// <summary>
    /// 端口值类型定义
    /// </summary>
    public enum SocketOutputValueType
    {
        String,
        Int,
        Float,
        Bool,
    }
}
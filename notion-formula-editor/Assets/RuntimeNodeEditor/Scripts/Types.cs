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
    /// 常量类型
    /// </summary>
    public enum ConstantNodeType
    {
        /// <summary>
        /// The base of the natural logarithm.
        /// </summary>
        e,
        /// <summary>
        /// The ratio of a circle's circumference to its diameter.
        /// </summary>
        pi,
        /// <summary>
        /// boolean true
        /// </summary>
        boolean_true,
        /// <summary>
        /// boolean false
        /// </summary>
        boolean_false,
    }
}
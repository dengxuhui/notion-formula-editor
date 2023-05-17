namespace NotionFormulaEditor.Types
{
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

    /// <summary>
    /// 节点类型
    /// </summary>
    public static class NodeType
    {
        /// <summary>
        /// 常量类型
        /// </summary>
        public static readonly int Constant = 1;
        /// <summary>
        /// 操作符
        /// </summary>
        public static readonly int Operator = 2;
        /// <summary>
        /// 函数类型
        /// </summary>
        public static readonly int Function = 3;
    }
}
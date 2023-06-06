using RuntimeNodeEditor;

namespace NotionFormulaEditor.Utility
{
    /// <summary>
    /// 节点工具
    /// </summary>
    public static class NodeUtility
    {
        /// <summary>
        /// 转换配置值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ParseConfigValue(SocketOutputValueType type, string value)
        {
            object result;
            switch (type)
            {
                case SocketOutputValueType.Bool:
                    result = int.Parse(value) > 0;
                    break;
                case SocketOutputValueType.Float:
                    result = float.Parse(value);
                    break;
                case SocketOutputValueType.Int:
                    result = int.Parse(value);
                    break;
                case SocketOutputValueType.String:
                default:
                    result = value;
                    break;
            }

            return result;
        }
    }
}
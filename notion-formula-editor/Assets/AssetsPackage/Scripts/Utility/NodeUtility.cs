using System;
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

        /// <summary>
        /// 转换为bool值
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool ConvertToBool(SocketOutput output)
        {
            if (output.IsBool())
            {
                return output.GetValue<bool>();
            }
            else if (output.IsNumber())
            {
                return Convert.ToBoolean(output.GetValue<float>());
            }
            else if (output.IsString())
            {
                return string.IsNullOrEmpty(output.GetValue<string>());
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 校验类型是否相等
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool IsSameType(SocketOutput o1, SocketOutput o2)
        {
            return o1.GetValueType() == o2.GetValueType();
        }
    }
}
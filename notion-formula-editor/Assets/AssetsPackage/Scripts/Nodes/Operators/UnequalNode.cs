using NotionFormulaEditor.Utility;
using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 判断两个输入是否不相等，输出bool值
    /// </summary>
    public class UnequalNode : Node
    {
        public SocketInput param1;
        public SocketInput param2;
        public SocketOutput output;

        public override void Setup()
        {
            base.Setup();
            Register(param1);
            Register(param2);
            Register(output);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (param1.TryGetConnectionOutput(out var param1Output) &&
                param2.TryGetConnectionOutput(out var param2Output) &&
                NodeUtility.IsSameType(param1Output, param2Output))
            {
                output.SetValue(param1Output.GetValue<object>() != param2Output.GetValue<object>());
            }
            else
            {
                output.SetValue(null);
            }
            
        }
    }
}
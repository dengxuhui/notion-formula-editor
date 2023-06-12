using System;
using NotionFormulaEditor.Utility;
using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 逻辑与，输出bool值
    /// </summary>
    public class AndNode : Node
    {
        public SocketInput param1;
        public SocketInput param2;
        public SocketOutput andResult;

        public override void Setup()
        {
            base.Setup();
            Register(param1);
            Register(param2);
            Register(andResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (param1.TryGetConnectionOutput(out var param1Output) &&
                param2.TryGetConnectionOutput(out var param2Output))
            {
                andResult.SetValue(NodeUtility.ConvertToBool(param1Output) && NodeUtility.ConvertToBool(param2Output));
            }
            else
            {
                andResult.SetValue(null);
            }
        }
    }
}
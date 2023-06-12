using System;
using NotionFormulaEditor.Utility;
using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 逻辑取反，输出bool值
    /// </summary>
    public class NotNode : Node
    {
        public SocketInput input;
        public SocketOutput output;

        public override void Setup()
        {
            base.Setup();
            Register(input);
            Register(output);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (input.TryGetConnectionOutput(out var socketOutput))
            {
                output.SetValue(!NodeUtility.ConvertToBool(socketOutput));
            }
            else
            {
                output.SetValue(null);
            }
        }
    }
}
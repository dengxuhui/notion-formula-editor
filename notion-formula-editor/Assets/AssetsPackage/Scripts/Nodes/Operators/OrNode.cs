using NotionFormulaEditor.Utility;
using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 逻辑或，输出bool值
    /// </summary>
    public class OrNode : Node
    {
        public SocketInput param1;
        public SocketInput param2;
        public SocketOutput orResult;

        public override void Setup()
        {
            base.Setup();
            Register(param1);
            Register(param2);
            Register(orResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (param1.TryGetConnectionOutput(out var param1Output) &&
                param2.TryGetConnectionOutput(out var param2Output))
            {
                orResult.SetValue(NodeUtility.ConvertToBool(param1Output) || NodeUtility.ConvertToBool(param2Output));
            }
            else
            {
                orResult.SetValue(null);
            }
        }
    }
}
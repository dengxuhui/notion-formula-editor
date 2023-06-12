using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 乘法节点
    /// </summary>
    public class MultiplyNode : Node
    {
        public SocketInput param1;
        public SocketInput param2;
        public SocketOutput multiplyResult;

        public override void Setup()
        {
            base.Setup();
            Register(param1);
            Register(param2);
            Register(multiplyResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (param1.TryGetConnectionOutput(out var param1Output) &&
                param2.TryGetConnectionOutput(out var param2Output))
            {
                if (param1Output.IsNumber() && param2Output.IsNumber())
                {
                    multiplyResult.SetValue(param1Output.GetValue<float>() * param2Output.GetValue<float>());
                }
                else
                {
                    multiplyResult.SetValue(null);
                }
            }
            else
            {
                multiplyResult.SetValue(null);
            }
        }
    }
}
using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 加法节点
    /// </summary>
    public class SubtractNode : Node
    {
        public SocketInput param1;
        public SocketInput param2;
        public SocketOutput subtractResult;

        public override void Setup()
        {
            base.Setup();
            Register(param1);
            Register(param2);
            Register(subtractResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (param1.TryGetConnectionOutput(out var param1Output) &&
                param2.TryGetConnectionOutput(out var param2Output))
            {
                if (param1Output.IsNumber() && param2Output.IsNumber())
                {
                    subtractResult.SetValue(param1Output.GetValue<float>() - param2Output.GetValue<float>());
                }
                else
                {
                    subtractResult.SetValue(null);
                }
            }
            else
            {
                subtractResult.SetValue(null);
            }
        }
    }
}
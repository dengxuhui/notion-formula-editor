using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 分支节点
    /// </summary>
    public class BranchNode : Node
    {
        public SocketInput predicateInput;
        public SocketInput trueInput;
        public SocketInput falseInput;

        public SocketOutput output;

        public override void Setup()
        {
            base.Setup();
            Register(output);
            Register(predicateInput, false);
            Register(trueInput, false);
            Register(falseInput, false);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (predicateInput.TryGetConnectionOutput(out var predicateOutput))
            {
                bool predicateValue = predicateOutput.GetValue<bool>();
                if (predicateValue && trueInput.TryGetConnectionOutput(out var trueOutput))
                {
                    output.SetValue(trueOutput.GetValue<object>());
                }
                else
                {
                    output.SetValue(null);
                }

                if (!predicateValue && falseInput.TryGetConnectionOutput(out var falseOutput))
                {
                    output.SetValue(falseOutput.GetValue<object>());
                }
                else
                {
                    output.SetValue(null);
                }
            }
            else
            {
                output.SetValue(null);
            }
        }
    }
}
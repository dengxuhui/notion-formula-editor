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

        private void UpdateOutputValue()
        {
            var hasTrueValue = trueInput.TryGetConnectionValue<object>(out var ifTrueValue);
            var hasFalseValue = falseInput.TryGetConnectionValue<object>(out var isFalseValue);
            var hasPredicateValue = predicateInput.TryGetConnectionValue<bool>(out var predicateValue);
            if (!hasPredicateValue)
            {
                return;
            }

            if (predicateValue)
            {
                output.SetValue(hasTrueValue ? ifTrueValue : null);
            }
            else
            {
                output.SetValue(hasFalseValue ? isFalseValue : null);
            }
        }

        protected override void OnConnection(SocketInput input, IOutput output)
        {
            base.OnConnection(input, output);
            output.ValueUpdated += UpdateOutputValue;
            UpdateOutputValue();
        }

        protected override void OnDisconnect(SocketInput input, IOutput output)
        {
            base.OnDisconnect(input, output);
            output.ValueUpdated -= UpdateOutputValue;
            UpdateOutputValue();
        }
    }
}
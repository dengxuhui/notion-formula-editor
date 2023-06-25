using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 小于节点
    /// 只能判断数字，其他判断不符合逻辑
    /// </summary>
    public class SmallerNode : Node
    {
        public SocketInput left;
        public SocketInput right;
        public SocketOutput output;

        public override void Setup()
        {
            base.Setup();
            Register(left);
            Register(right);
            Register(output);
        }
        
        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (left.TryGetConnectionOutput(out var leftOutput) && right.TryGetConnectionOutput(out var rightOutput))
            {
                if (leftOutput.IsNumber() && rightOutput.IsNumber())
                {
                    output.SetValue(leftOutput.GetValue<float>() < rightOutput.GetValue<float>());
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
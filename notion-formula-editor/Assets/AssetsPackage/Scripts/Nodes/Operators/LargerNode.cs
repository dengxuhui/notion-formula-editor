using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 大于节点
    /// 与Notion不同的是，没有比对Boolean值与字符串的大小。
    /// 个人觉得这样的比较没有意义
    /// </summary>
    public class LargerNode : Node
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
            if (left.TryGetConnectionOutput(out var leftOutput) &&
                right.TryGetConnectionOutput(out var rightOutput))
            {
                if (leftOutput.IsNumber() && rightOutput.IsNumber())
                {
                    output.SetValue(leftOutput.GetValue<float>() > rightOutput.GetValue<float>());
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
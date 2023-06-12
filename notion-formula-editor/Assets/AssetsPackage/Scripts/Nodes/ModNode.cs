using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 余数节点
    /// </summary>
    public class ModNode : Node
    {
        //被除数
        public SocketInput dividend;

        //除数
        public SocketInput divisor;

        //结果
        public SocketOutput modResult;

        public override void Setup()
        {
            base.Setup();
            Register(dividend);
            Register(divisor);
            Register(modResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (dividend.TryGetConnectionOutput(out var dividendOutput) &&
                divisor.TryGetConnectionOutput(out var divisorOutput))
            {
                if (dividendOutput.IsNumber() && divisorOutput.IsNumber())
                {
                    modResult.SetValue(dividendOutput.GetValue<float>() % divisorOutput.GetValue<float>());
                }
                else
                {
                    modResult.SetValue(null);
                }
            }
            else
            {
                modResult.SetValue(null);
            }
        }
    }
}
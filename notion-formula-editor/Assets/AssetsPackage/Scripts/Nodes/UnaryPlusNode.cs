using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 转换为number类型
    /// </summary>
    public class UnaryPlusNode : Node
    {
        //输入
        public SocketInput input;

        //输出
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
                if (socketOutput.IsNumber())
                {
                    output.SetValue(socketOutput.GetValue<float>());
                }
                else if (socketOutput.IsBool())
                {
                    output.SetValue(socketOutput.GetValue<bool>() ? 1 : 0);
                }
                else if (socketOutput.IsString())
                {
                    if (float.TryParse(socketOutput.GetValue<string>(), out var result))
                    {
                        output.SetValue(result);
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
            else
            {
                output.SetValue(null);
            }
        }
    }
}
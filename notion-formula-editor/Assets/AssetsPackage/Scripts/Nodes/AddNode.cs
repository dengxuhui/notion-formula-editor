using System;
using RuntimeNodeEditor;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 加法节点，数字与数字加法，字符串与字符串拼接
    /// </summary>
    public class AddNode : Node
    {
        public SocketInput param1;
        public SocketInput param2;
        public SocketOutput addResult;

        public override void Setup()
        {
            base.Setup();
            Register(param1, false);
            Register(param2, false);
            Register(addResult);
        }

        protected override void UpdateNodeValue()
        {
            if (param1.TryGetConnectionOutput(out var param1Output) &&
                param2.TryGetConnectionOutput(out var param2Output))
            {
                if (param1Output.IsString() && param2Output.IsString())
                {
                    addResult.SetValue(param1Output.GetValue<string>() + param2Output.GetValue<string>());
                }
                else if (param2Output.IsNumber() && param2Output.IsNumber())
                {
                    addResult.SetValue(param1Output.GetValue<float>() + param2Output.GetValue<float>());
                }
                else
                {
                    addResult.SetValue(null);
                }
            }
            else
            {
                addResult.SetValue(null);
            }
        }
    }
}
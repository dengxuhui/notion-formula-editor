using NotionFormulaEditor.Datas;
using RuntimeNodeEditor;
using UnityEngine.UI;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 最终输出结果Node
    /// </summary>
    public class ResultNode : Node
    {
        public SocketInput input;
        public Button copyButton;

        public override void Setup()
        {
            base.Setup();
            Register(input, false);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (input.TryGetConnectionOutput(out var output))
            {
                var result = output.GetValue<object>();
                RuntimeDataManager.I.result = result != null ? result.ToString() : string.Empty;
            }
            else
            {
                RuntimeDataManager.I.result = string.Empty;
            }
        }
    }
}
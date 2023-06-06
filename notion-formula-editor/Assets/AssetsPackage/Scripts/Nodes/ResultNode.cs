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

        //当前正在连接中的节点
        private IOutput _connecting;

        public override void Setup()
        {
            base.Setup();
            Register(input, false);
        }

        protected override void OnConnection(SocketInput input, IOutput output)
        {
            base.OnConnection(input, output);
            _connecting = output;
            output.ValueUpdated += UpdateResultFromConnecting;
            UpdateResultFromConnecting();
        }

        protected override void OnDisconnect(SocketInput input, IOutput output)
        {
            base.OnDisconnect(input, output);
            output.ValueUpdated -= UpdateResultFromConnecting;
            _connecting = null;
            UpdateResultFromConnecting();
        }

        private void UpdateResultFromConnecting()
        {
            if (_connecting == null)
            {
                RuntimeDataManager.I.result = string.Empty;
            }
            else
            {
                var result = _connecting.GetValue<object>();
                if (result != null)
                {
                    var strResult = result.ToString();
                    RuntimeDataManager.I.result = strResult;
                }
            }
        }
    }
}
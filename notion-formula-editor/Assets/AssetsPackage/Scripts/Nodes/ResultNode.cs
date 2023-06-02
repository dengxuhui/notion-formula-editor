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
            Register(input);
            OnConnectionEvent += OnConnection;
            OnDisconnectEvent += OnDisconnect;
        }

        private void OnConnection(SocketInput input, IOutput output)
        {
        }

        private void OnDisconnect(SocketInput input, IOutput output)
        {
        }
    }
}
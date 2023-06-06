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
            Register(predicateInput);
            Register(trueInput);
            Register(falseInput);
        }


        protected override void OnConnection(SocketInput input, IOutput output)
        {
            base.OnConnection(input, output);
        }

        protected override void OnDisconnect(SocketInput input, IOutput output)
        {
            base.OnDisconnect(input, output);
        }
    }
}
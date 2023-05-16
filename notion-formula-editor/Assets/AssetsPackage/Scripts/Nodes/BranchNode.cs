using RuntimeNodeEditor;
using UnityEngine;

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
    }
}
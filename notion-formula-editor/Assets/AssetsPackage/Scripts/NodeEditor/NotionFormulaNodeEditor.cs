using RuntimeNodeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotionFormulaEditor
{
    /// <summary>
    /// Notion公式编辑器
    /// </summary>
    public class NotionFormulaNodeEditor : NodeEditor
    {
        public override void StartEditor(NodeGraph graph)
        {
            base.StartEditor(graph);

            Events.OnGraphPointerClickEvent += OnGraphPointerClick;
            Events.OnNodePointerClickEvent += OnNodePointerClick;
            Events.OnConnectionPointerClickEvent += OnNodeConnectionPointerClick;
            Events.OnSocketConnect += OnConnect;

            // Graph.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        private void OnGraphPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnGraphPointerClick");
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Right:
                {
                    var ctx = new ContextMenuBuilder();
                    ctx.Add("nodes/constant", () =>
                    {
                        Graph.Create("Prefabs/Nodes/ConstantNode");
                        CloseContextMenu();
                    });
                    ctx.Add("nodes/operators/if", () =>
                    {
                        Graph.Create("Prefabs/Nodes/BranchNode");
                        CloseContextMenu();
                    });
                    var ctxData = ctx.Build();

                    SetContextMenu(ctxData);
                    DisplayContextMenu();
                }
                    break;
                case PointerEventData.InputButton.Left:
                {
                    CloseContextMenu();
                }
                    break;
            }
        }

        private void OnNodePointerClick(Node node, PointerEventData eventData)
        {
            Debug.Log("OnNodePointerClick");
        }

        private void OnNodeConnectionPointerClick(string connId, PointerEventData eventData)
        {
            Debug.Log("OnNodeConnectionPointerClick");
        }

        /// <summary>
        /// 连接响应
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void OnConnect(SocketInput arg1, SocketOutput arg2)
        {
            Graph.drawer.SetConnectionColor(arg2.connection.connId, Color.green);
        }
    }
}
using NotionFormulaEditor.Config;
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
            Graph.Create(ConfigManager.Get<ResNodes>(1), Vector2.zero);
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
                    var nodeConfigList = ConfigManager.GetGroup<ResNodes>().Configs;
                    for (var i = 0; i < nodeConfigList.Count; i++)
                    {
                        var nodeConfig = nodeConfigList[i];
                        if (!string.IsNullOrEmpty(nodeConfig.Menu))
                        {
                            ctx.Add($"Nodes/{nodeConfig.Menu}", () => { CreateNode(nodeConfig); });
                        }
                    }


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

        private void CreateNode(ResNodes nodeConfig)
        {
            Graph.Create(nodeConfig);
            CloseContextMenu();
        }

        private void DeleteNode(Node node)
        {
            Graph.Delete(node);
            CloseContextMenu();
        }

        private void Duplicate(Node node)
        {
            Graph.Create(node);
            CloseContextMenu();
        }

        private void OnNodePointerClick(Node node, PointerEventData eventData)
        {
            switch (eventData.button)
            {
                //打开节点操作菜单
                case PointerEventData.InputButton.Right:
                {
                    var ctx = new ContextMenuBuilder();
                    var nodeConfig = node.nodeConfig;
                    ctx.Add("Delete",nodeConfig.Deletable > 0, () => { DeleteNode(node); });
                    ctx.Add("Duplicate",nodeConfig.Duplicatable > 0, () => { Duplicate(node); });


                    SetContextMenu(ctx.Build());
                    DisplayContextMenu();
                }
                    break;
            }
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
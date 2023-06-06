using System;
using NotionFormulaEditor.Config;
using RuntimeNodeEditor;
using UnityEngine;

namespace NotionFormulaEditor
{
    /// <summary>
    /// 程序入口
    /// </summary>
    public class Main : MonoBehaviour
    {
        public RectTransform editorHolder;
        public NotionFormulaNodeEditor editor;

        private void Start()
        {
            Application.targetFrameRate = 60;
            CameraManager.I.Startup();
            ConfigManager.I.Startup();
            //创建节点图
            var settings = new NodeGraphSettings
            {
                bgColor = Color.gray,
                connectionColor = Color.yellow,
                graphSize = editorHolder.sizeDelta
            };
            var graph = editor.CreateGraph<NodeGraph>(editorHolder, settings);
            editor.StartEditor(graph);
        }
    }
}
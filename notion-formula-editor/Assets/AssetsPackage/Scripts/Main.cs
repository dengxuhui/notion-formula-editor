using System;
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
            CameraManager.Instance.Startup();
            //创建节点图
            var graph = editor.CreateGraph<NodeGraph>(editorHolder);
            editor.StartEditor(graph);
        }
    }
}
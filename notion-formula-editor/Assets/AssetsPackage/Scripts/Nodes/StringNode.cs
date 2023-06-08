using RuntimeNodeEditor;
using TMPro;
using UnityEngine;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 字符串输入节点
    /// </summary>
    public class StringNode : Node
    {
        /// <summary>
        /// 输入框
        /// </summary>
        public TMP_InputField inputField;

        public SocketOutput stringOutput;

        private void OnInputValueChanged(string value)
        {
            var textHeight = inputField.preferredHeight;
            var curr = PanelRect.sizeDelta;
            PanelRect.sizeDelta = new Vector2(curr.x, 100 + textHeight);
            UpdateNodeValue();
        }

        public override void Setup()
        {
            base.Setup();
            Register(stringOutput);
            inputField.text = "";
            inputField.onValueChanged.AddListener(OnInputValueChanged);
            UpdateNodeValue();
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            stringOutput.SetValue(inputField.text);
        }
    }
}
using System;
using RuntimeNodeEditor;
using TMPro;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 数字节点
    /// </summary>
    public class NumberNode : Node
    {
        //inputField需要设置为只能输入数字
        public TMP_InputField inputField;
        public SocketOutput numberOutput;

        public override void Setup()
        {
            base.Setup();
            Register(numberOutput);
            inputField.text = "0";
            inputField.onValueChanged.AddListener(OnInputValueChanged);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            var value = inputField.text;
            numberOutput.SetValue(float.TryParse(value, out var result) ? result : 0.0f);
        }

        private void OnInputValueChanged(string value)
        {
            UpdateNodeValue();
        }
    }
}
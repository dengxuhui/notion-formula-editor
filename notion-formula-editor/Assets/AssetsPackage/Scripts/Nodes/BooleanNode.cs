using RuntimeNodeEditor;
using UnityEngine.UI;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// bool值节点
    /// </summary>
    public class BooleanNode : Node
    {
        public SocketOutput boolOutput;
        public Toggle toggle;

        public override void Setup()
        {
            base.Setup();
            Register(boolOutput);
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
            UpdateNodeValue();
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            boolOutput.SetValue(toggle.isOn);
        }

        private void OnToggleValueChanged(bool value)
        {
            UpdateNodeValue();
        }
    }
}
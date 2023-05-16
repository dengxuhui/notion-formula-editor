using System.Collections.Generic;
using RuntimeNodeEditor;
using TMPro;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 常量Node
    /// </summary>
    public class ConstantNode : Node
    {
        public SocketOutput output;
        public TMP_Dropdown dropdown;

        public override void Setup()
        {
            base.Setup();
            Register(output);
            dropdown.AddOptions(new List<TMP_Dropdown.OptionData>()
            {
                new(ConstantNodeType.e.ToString()),
                new(ConstantNodeType.pi.ToString()),
                new(ConstantNodeType.boolean_true.ToString()),
                new(ConstantNodeType.boolean_false.ToString()),
            });
            
            dropdown.onValueChanged.AddListener(selected =>
            {
                OnDropdownValueChanged(selected);
            });

            OnConnectionEvent += OnConnection;
            OnDisconnectEvent += OnDisconnect;
        }
        
        public void OnConnection(SocketInput input, IOutput output)
        {
        }

        public void OnDisconnect(SocketInput input, IOutput output)
        {
        }

        private void OnDropdownValueChanged(int selected)
        {
            
        }
    }
}
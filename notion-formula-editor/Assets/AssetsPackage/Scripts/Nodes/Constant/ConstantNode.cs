using NotionFormulaEditor.Config;
using NotionFormulaEditor.Utility;
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

        //选中的配置
        private ResConstant _selectedConfig;
        public ResConstant selectedConfig => _selectedConfig;

        public override void Setup()
        {
            base.Setup();
            Register(output);

            var resConstant = ConfigManager.GetGroup<ResConstant>();
            for (var i = 0; i < resConstant.Configs.Count; i++)
            {
                var config = resConstant.Configs[i];
                dropdown.options.Add(new TMP_Dropdown.OptionData(config.Name));
            }

            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
            dropdown.value = 0;
            _selectedConfig = resConstant.Configs[0];
            UpdateNodeValue();
        }

        protected override void UpdateNodeValue()
        {
            output.SetValue(NodeUtility.ParseConfigValue(_selectedConfig.ValueType, _selectedConfig.Value));
        }

        private void OnDropdownValueChanged(int selected)
        {
            var config = ConfigManager.GetGroup<ResConstant>().Configs[selected];
            _selectedConfig = config;
            UpdateNodeValue();
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace NotionFormulaEditor.Datas
{
    public class RuntimeDataManager : Singleton<RuntimeDataManager>
    {
        #region 事件定义

        public class OnResultChangeHandler : UnityEvent
        {
        }

        #endregion

        public OnResultChangeHandler onResultChange = new OnResultChangeHandler();

        private string _result;

        public string result
        {
            get => _result;
            set
            {
                _result = value;
                onResultChange.Invoke();
            }
        }

        public override void Dispose()
        {
        }
    }
}
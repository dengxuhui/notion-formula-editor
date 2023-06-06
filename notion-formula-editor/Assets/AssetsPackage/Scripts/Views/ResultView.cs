using System;
using NotionFormulaEditor.Datas;
using TMPro;
using UnityEngine;

namespace NotionFormulaEditor.Views
{
    /// <summary>
    /// 结果展示界面
    /// </summary>
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private TMP_Text result;

        private void OnEnable()
        {
            RuntimeDataManager.I.onResultChange.AddListener(RefreshResultContext);
            RefreshResultContext();
        }

        private void OnDisable()
        {
            RuntimeDataManager.I.onResultChange.RemoveListener(RefreshResultContext);
        }

        private void RefreshResultContext()
        {
            result.text = RuntimeDataManager.I.result;
        }
    }
}
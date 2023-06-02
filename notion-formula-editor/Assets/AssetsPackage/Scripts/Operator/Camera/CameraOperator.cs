using System;
using UnityEngine;

namespace NotionFormulaEditor.Operator
{
    /// <summary>
    /// 这部分逻辑主要处理外部调用
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public partial class CameraOperator : MonoBehaviour
    {
        [SerializeField] private float minCameraSize = 3;

        [SerializeField] private float maxCameraSize = 9;

        //跟随范围
        [SerializeField] private RectTransform scopeRect;
        //-----------

        //摄像机
        private Camera _camera;

        //摄像机范围
        private CameraScope _scope;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _scope = new CameraScope();
            _scope.Init(scopeRect, _camera);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotionFormulaEditor
{
    /// <summary>
    /// 相机管理器
    /// </summary>
    public class CameraManager : MonoSingleton<CameraManager>
    {
        //可移动摄像机
        private Camera _movableCamera;

        //固定摄像机
        private Camera _fixedCamera;

        //获取当前相机
        public Camera movableCamera => _movableCamera;

        //固定摄像机
        public Camera fixedCamera => _fixedCamera;

        protected override void Init()
        {
            base.Init();
            SceneManager.activeSceneChanged += OnSceneChanged;
            RefreshCamera();
        }

        public override void Dispose()
        {
            SceneManager.activeSceneChanged -= OnSceneChanged;
            base.Dispose();
        }

        private void OnSceneChanged(Scene current, Scene next)
        {
            RefreshCamera();
        }

        private void RefreshCamera()
        {
            _movableCamera = GameObject.FindWithTag("MovableCamera").GetComponent<Camera>();
            _fixedCamera = GameObject.FindWithTag("FixedCamera").GetComponent<Camera>();
        }
    }
}
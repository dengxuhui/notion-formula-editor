using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotionFormulaEditor
{
    /// <summary>
    /// 相机管理器
    /// </summary>
    public class CameraManager : MonoSingleton<CameraManager>
    {
        //当前相机
        private Camera _current;
        
        //获取当前相机
        public Camera current => _current;
        
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
            _current = Camera.main;
        }
    }
}
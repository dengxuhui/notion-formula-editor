using UnityEngine;

namespace NotionFormulaEditor.Operator
{
    /// <summary>
    /// 摄像机范围定义
    /// </summary>
    public class CameraScope
    {
        //跟随目标
        private RectTransform _scopeRect;

        //摄像机对象
        private Camera _camera;

        // p2.....p3
        // .........
        // p1.....p4
        //
        private Vector2 _p1;
        private Vector2 _p3;

        public void Init(RectTransform scopeRect, Camera camera)
        {
            _camera = camera;
            _scopeRect = scopeRect;
            var centerScreenPoint = RectTransformUtility.WorldToScreenPoint(_camera, _scopeRect.position);
            var rect = _scopeRect.rect;
            _p1 = new Vector2(centerScreenPoint.x - rect.width / 2, centerScreenPoint.y - rect.height / 2);
            _p3 = new Vector2(centerScreenPoint.x + rect.width / 2, centerScreenPoint.y + rect.height / 2);
        }

        public Vector3 ModifyMotion(Vector3 position, Vector3 screenMotion)
        {
            var targetPosition = position + screenMotion;
            //摄像机中心点在屏幕上的坐标
            var camCenterScreenPoint = RectTransformUtility.WorldToScreenPoint(_camera, targetPosition);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_scopeRect, camCenterScreenPoint, _camera,
                out var scopePosition);
            
            if (camCenterScreenPoint.x < _p1.x)
            {
                camCenterScreenPoint.x = _p1.x;
            }

            if (camCenterScreenPoint.x > _p3.x)
            {
                camCenterScreenPoint.x = _p3.x;
            }

            if (camCenterScreenPoint.y < _p1.y)
            {
                camCenterScreenPoint.y = _p1.y;
            }

            if (camCenterScreenPoint.y > _p3.y)
            {
                camCenterScreenPoint.y = _p3.y;
            }

            var tp2 = _camera.ScreenToWorldPoint(camCenterScreenPoint);

            return position - tp2;
        }
    }
}
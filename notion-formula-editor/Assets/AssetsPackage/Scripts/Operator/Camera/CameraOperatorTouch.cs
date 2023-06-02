using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace NotionFormulaEditor.Operator
{
    /// <summary>
    /// 这部分逻辑主要处理内部调用。响应屏幕操作行为
    /// </summary>
    public partial class CameraOperator : MonoBehaviour
    {
        //鼠标中键按下
        private bool _scrollWheelDown;

        //缩放中
        private bool _touchScaleRunning;

        //点击开始位置
        private Vector2 _touchBeginPos;

        //上一次点击的屏幕位置
        private Vector3 _preScreenPoint;

        private void Update()
        {
            //todo 如果是触摸屏，需要支持触摸更新
            UpdateMouse();
        }

        private void UpdateMouse()
        {
            //0：鼠标左键
            //1：鼠标右键
            //2：鼠标中键
            if (Input.GetMouseButtonDown(2))
            {
                _scrollWheelDown = true;
                OnScrollWheelDown();
            }
            else if (_scrollWheelDown && Input.GetMouseButton(2))
            {
                var mouseX = Input.GetAxis("Mouse X");
                var mouseY = Input.GetAxis("Mouse Y");
                var move = mouseX > float.Epsilon
                           || mouseX < float.Epsilon * -1
                           || mouseY > float.Epsilon
                           || mouseY < float.Epsilon * -1;
                OnScrollWheelHold(move);
            }
            else if (Input.GetMouseButtonUp(2))
            {
                _scrollWheelDown = false;
                OnScrollWheelUp();
            }
            else
            {
                //检查缩放
                var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
                ChangeOrthographicSize(scrollWheel * Time.unscaledDeltaTime * 50 * -1);
            }
        }

        private void ChangeOrthographicSize(float delta)
        {
            if (delta > float.Epsilon || delta < float.Epsilon * -1)
            {
                var newSize = _camera.orthographicSize + delta;
                newSize = Mathf.Max(Mathf.Min(newSize, maxCameraSize), minCameraSize);
                _camera.orthographicSize = newSize;
            }
        }

        private void OnScrollWheelDown()
        {
            //计算点击位置，保存点击数据等逻辑
            _preScreenPoint = Input.mousePosition;
        }

        private void OnScrollWheelUp()
        {
        }

        private void OnScrollWheelHold(bool move)
        {
            if (move)
            {
                var currScreenPoint = Input.mousePosition;
                var screenMotion = _camera.ScreenToWorldPoint(_preScreenPoint) -
                                   _camera.ScreenToWorldPoint(currScreenPoint);
                transform.position += screenMotion;
                _preScreenPoint = currScreenPoint;
            }
        }
    }
}
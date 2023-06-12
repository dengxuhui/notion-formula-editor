using System;
using UnityEngine.EventSystems;
using UnityEngine;

namespace RuntimeNodeEditor
{
    public class SocketOutput : Socket, IOutput, IPointerClickHandler, IDragHandler, IEndDragHandler
    {
        public Connection connection;
        private object _value;

        public void SetValue(object value)
        {
            if (_value != value)
            {
                _value = value;
                ValueUpdated?.Invoke();
            }
        }

        public event Action ValueUpdated;

        public T GetValue<T>()
        {
            var val = _value;
            if (val is not T && val != null)
            {
                var tType = typeof(T);
                var vType = _value.GetType();
                if (tType == typeof(bool))
                {
                    if (vType == typeof(float) || vType == typeof(int) || vType == typeof(double))
                    {
                        val = (float)_value > 0.0f;
                    }
                    else if (vType == typeof(string))
                    {
                        val = !string.IsNullOrEmpty(val as string);
                    }
                }
            }

            return (T)val;
        }

        public bool IsString()
        {
            return _value is string;
        }

        public bool IsBool()
        {
            return _value is bool;
        }

        public bool IsNumber()
        {
            return _value is float or int or double;
        }

        public Type GetValueType()
        {
            return _value.GetType();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Events.InvokeOutputSocketClick(this, eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Events.InvokeSocketDragFrom(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            foreach (var item in eventData.hovered)
            {
                var input = item.GetComponent<SocketInput>();
                if (input != null)
                {
                    Events.InvokeOutputSocketDragDropTo(input);
                    return;
                }
            }

            Events.InvokeOutputSocketDragDropTo(null);
        }

        public void Connect(Connection conn)
        {
            connection = conn;
        }

        public void Disconnect()
        {
            connection = null;
        }

        public override bool HasConnection()
        {
            return connection != null;
        }
    }
}
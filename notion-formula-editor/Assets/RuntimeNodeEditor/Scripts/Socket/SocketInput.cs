using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RuntimeNodeEditor
{
    public class SocketInput : Socket, IPointerClickHandler
    {
        public List<Connection> Connections { get; private set; }

        public override void Setup()
        {
            Connections = new List<Connection>();
            base.Setup();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Events.InvokeInputSocketClick(this, eventData);
        }

        public void Connect(Connection conn)
        {
            if (allowMultiConnect || Connections.Count <= 0)
            {
                Connections.Add(conn);
            }
            else
            {
                //调用Graph断开连接
                //先断开所有链接，再连接
                //不允许多连接，Connections一定只有一个
                Events.InvokeForceDisconnect(Connections[0]);
                Connections.Add(conn);
            }
        }

        public void Disconnect(Connection conn)
        {
            Connections.Remove(conn);
        }

        public override bool HasConnection()
        {
            return Connections.Count > 0;
        }

        public bool TryGetConnectionValue<T>(out T result)
        {
            if (Connections.Count > 0)
            {
                result = Connections[0].output.GetValue<T>();
                return true;
            }

            result = default(T);
            return false;
        }
    }
}
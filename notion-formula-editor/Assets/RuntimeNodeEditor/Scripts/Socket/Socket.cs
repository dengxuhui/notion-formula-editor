using UnityEngine;

namespace RuntimeNodeEditor
{
    public abstract class Socket : MonoBehaviour
    {
        public Node OwnerNode => _ownerNode;

        protected ISocketEvents Events => _socketEvents;

        public string socketId;
        public SocketHandle handle;
        public ConnectionType connectionType;
        protected bool allowMultiConnect = true;

        private Node _ownerNode;
        private ISocketEvents _socketEvents;


        public void SetOwner(Node owner, ISocketEvents events, bool allowMultiConnect = true)
        {
            _ownerNode = owner;
            _socketEvents = events;
            this.allowMultiConnect = allowMultiConnect;
            Setup();
        }

        protected virtual void Setup()
        {
        }

        public abstract bool HasConnection();
    }
}
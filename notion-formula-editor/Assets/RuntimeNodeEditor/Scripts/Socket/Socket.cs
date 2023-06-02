using NotionFormulaEditor;
using NotionFormulaEditor.Config;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor
{
    public abstract class Socket : MonoBehaviour
    {
        public Node OwnerNode
        {
            get { return _ownerNode; }
        }

        public ISocketEvents Events
        {
            get { return _socketEvents; }
        }

        /// <summary>
        /// 配置id
        /// </summary>
        public int configId;

        public string socketId;
        public SocketHandle handle;
        public ConnectionType connectionType;
        private Node _ownerNode;
        private ISocketEvents _socketEvents;
        [SerializeField] private TMP_Text textName;


        public void SetOwner(Node owner, ISocketEvents events)
        {
            _ownerNode = owner;
            _socketEvents = events;
            Setup();
        }

        public virtual void Setup()
        {
            var config = ConfigManager.Get<ResSockets>(configId);
            if (config == null)
            {
                Debug.LogErrorFormat($"Socket config not found. configId:{configId}");
            }
            else
            {
                textName.text = config.Context;
            }
        }

        public abstract bool HasConnection();
    }
}
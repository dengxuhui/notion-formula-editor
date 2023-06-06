using NotionFormulaEditor;
using NotionFormulaEditor.Config;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor
{
    public abstract class Socket : MonoBehaviour
    {
        public Node OwnerNode => _ownerNode;

        protected ISocketEvents Events => _socketEvents;

        /// <summary>
        /// 配置id
        /// </summary>
        public int ConfigId => configId;

        [SerializeField] private int configId;
        [SerializeField] private TMP_Text textName;

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
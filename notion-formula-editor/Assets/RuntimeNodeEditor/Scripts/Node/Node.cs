using System;
using System.Collections.Generic;
using NotionFormulaEditor.Config;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor
{
    public abstract class Node : MonoBehaviour
    {
        public string ID { get; private set; }

        public Vector2 Position
        {
            get => _panelRectTransform.anchoredPosition;
        }

        public RectTransform PanelRect
        {
            get => _panelRectTransform;
        }

        public string LoadPath { get; private set; }
        public List<SocketOutput> Outputs { get; private set; }
        public List<SocketInput> Inputs { get; private set; }

        public event Action<SocketInput, IOutput> OnConnectionEvent;
        public event Action<SocketInput, IOutput> OnDisconnectEvent;

        public GameObject draggableBody;

        private NodeDraggablePanel _dragPanel;
        private RectTransform _panelRectTransform;
        private INodeEvents _nodeEvents;
        private ISocketEvents _socketEvents;
        private ResNodes _nodeConfig;
        public ResNodes nodeConfig => _nodeConfig;

        public void Init(INodeEvents nodeEvents, ISocketEvents socketEvents, Vector2 pos, string id, ResNodes config)
        {
            ID = id;
            Outputs = new List<SocketOutput>();
            Inputs = new List<SocketInput>();

            _nodeConfig = config;
            _nodeEvents = nodeEvents;
            _socketEvents = socketEvents;
            _panelRectTransform = gameObject.GetComponent<RectTransform>();
            _dragPanel = draggableBody.AddComponent<NodeDraggablePanel>();
            _dragPanel.Init(this, _nodeEvents);
            SetPosition(pos);
        }

        public virtual void Setup()
        {
            OnConnectionEvent += OnConnection;
            OnDisconnectEvent += OnDisconnect;
        }

        public virtual bool CanMove()
        {
            return true;
        }

        protected void Register(SocketOutput output)
        {
            output.SetOwner(this, _socketEvents);
            Outputs.Add(output);
        }

        protected void Register(SocketInput input)
        {
            input.SetOwner(this, _socketEvents);
            Inputs.Add(input);
        }

        public void Connect(SocketInput input, SocketOutput output)
        {
            OnConnectionEvent?.Invoke(input, output);
        }

        public void Disconnect(SocketInput input, SocketOutput output)
        {
            OnDisconnectEvent?.Invoke(input, output);
        }

        protected virtual void UpdateNodeValue()
        {
        }

        protected virtual void OnConnection(SocketInput input, IOutput output)
        {
            output.ValueUpdated += UpdateNodeValue;
            UpdateNodeValue();
        }

        protected virtual void OnDisconnect(SocketInput input, IOutput output)
        {
            output.ValueUpdated -= UpdateNodeValue;
            UpdateNodeValue();
        }

        public virtual void OnSerialize(Serializer serializer)
        {
        }

        public virtual void OnDeserialize(Serializer serializer)
        {
        }

        public void SetPosition(Vector2 pos)
        {
            _panelRectTransform.localPosition = pos;
        }

        public void SetAsLastSibling()
        {
            _panelRectTransform.SetAsLastSibling();
        }

        public void SetAsFirstSibling()
        {
            _panelRectTransform.SetAsFirstSibling();
        }
    }
}
using System;
using UnityEngine;

namespace RuntimeNodeEditor
{
    [Serializable]
    public class NodeData
    {
        /// <summary>
        /// 配置id
        /// </summary>
        public int configId;
        public string id;
        public SerializedValue[] values;
        public float posX;
        public float posY;
        public string[] inputSocketIds;
        public string[] outputSocketIds;
    }

    [Serializable]
    public class ConnectionData
    {
        public string id;
        public string outputSocketId;
        public string inputSocketId;
    }

    [System.Serializable]
    public class SerializedValue
    {
        public string key;
        public string value;
    }

    public class GraphData
    {
        public NodeData[] nodes;
        public ConnectionData[] connections;
    }
}
using UnityEngine;

namespace NotionFormulaEditor
{
    /// <summary>
    /// Mono单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T mInstance = null;

        public static T I
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = GameObject.FindObjectOfType(typeof(T)) as T;
                    if (mInstance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        mInstance = go.AddComponent<T>();
                        GameObject parent = GameObject.Find("Boot");
                        if (parent == null)
                        {
                            parent = new GameObject("Boot");
                            GameObject.DontDestroyOnLoad(parent);
                        }

                        if (parent != null)
                        {
                            go.transform.parent = parent.transform;
                        }
                    }
                }

                return mInstance;
            }
        }

        public static bool IsNull()
        {
            return mInstance == null;
        }

        /*
         * 没有任何实现的函数，用于保证MonoSingleton在使用前已创建
         */
        public void Startup()
        {
        }

        private void Awake()
        {
            if (mInstance == null)
            {
                mInstance = this as T;
            }

            DontDestroyOnLoad(gameObject);
            Init();
        }

        protected virtual void Init()
        {
        }

        public void DestroySelf()
        {
            Dispose();
            MonoSingleton<T>.mInstance = null;
            UnityEngine.Object.Destroy(gameObject);
        }

        public virtual void Dispose()
        {
        }
    }
}
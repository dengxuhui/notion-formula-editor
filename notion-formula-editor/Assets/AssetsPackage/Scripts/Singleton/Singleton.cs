using System;
using UnityEngine;

namespace NotionFormulaEditor
{
    /// <summary>
    /// 单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        private static T m_instance;

        public static T I
        {
            get
            {
                if (Singleton<T>.m_instance == null)
                {
                    Singleton<T>.m_instance = Activator.CreateInstance<T>();
                    if (Singleton<T>.m_instance != null)
                    {
                        (Singleton<T>.m_instance as Singleton<T>).Init();
                    }
                }

                return Singleton<T>.m_instance;
            }
        }

        public static void Release()
        {
            if (Singleton<T>.m_instance != null)
            {
                Singleton<T>.m_instance = (T)((object)null);
            }
        }

        public virtual void Init()
        {
        }
        
        public void Startup()
        {
        }

        public abstract void Dispose();
    }
}
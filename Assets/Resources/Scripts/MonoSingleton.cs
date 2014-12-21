using UnityEngine;
using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {

    protected static T m_Instance = null;

    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
            }

            return m_Instance;
        }
    }

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this as T;
        }
        else
        {
            if (m_Instance != this as T)
            {
                Destroy(gameObject);
                return;
            }
        }

        Init();
    }

    public virtual void Init() { }
}

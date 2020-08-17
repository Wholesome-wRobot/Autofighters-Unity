using UnityEngine;

namespace AutoFighters
{
    public class EventSystem : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class TimeController : MonoBehaviour
    {
        //シングルトン化
        public static TimeController instance;
        [HideInInspector]
        public float times = 10;//これが制限時間
        [HideInInspector]
        public bool isCount = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else { Destroy(gameObject); }
        }
    }

}

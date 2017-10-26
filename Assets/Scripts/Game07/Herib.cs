using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class Herib : MonoBehaviour
    {
        [SerializeField, Header("ヘリのスピード")]
        private float H_Speed = 3;
        void Update()
        {
            transform.position += transform.up * H_Speed / 2 + -transform.right * H_Speed * 100 * Time.deltaTime;
        }
    }

}

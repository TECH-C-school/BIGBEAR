using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class DestroyField : MonoBehaviour
    {
        [SerializeField, Header("オブジェクトの名前")]
        private string Name01;
        [SerializeField, Header("オブジェクトの名前2つめ")]
        private string Name02;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name == Name01 || collision.gameObject.name == Name02)
            {
                Destroy(collision.gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == Name01 || collision.gameObject.name == Name02)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

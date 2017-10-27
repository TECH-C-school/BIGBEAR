using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class DestroyField : MonoBehaviour
    {
        [SerializeField, Header("タグの名前")]
        private string tagName;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == tagName)
            {
                Destroy(collision.gameObject);
                //Herib.isCreate = false;
            }
        }
    }
}

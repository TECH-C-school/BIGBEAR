using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class Herid : MonoBehaviour
    {
        [SerializeField, Header("ヘリのスピード")]
        private float H_Speed = 3;
        Rigidbody2D rb2d;
        Vector2 move;
        [SerializeField, Header("荷物か爆弾")]
        private GameObject Prefab;
        public static float m_Count_Speed = 5;
        private Vector3 attachPoint;
        //キャンパス情報
        private Canvas canvas;

        void Start()
        {
            canvas = FindObjectOfType<Canvas>();
            StartCoroutine(CreateCatchObj());
            rb2d = GetComponent<Rigidbody2D>();
            move = new Vector2(-H_Speed, 0);
        }

        void Update()
        {
            attachPoint = transform.GetChild(1).position;
            //transform.position += (transform.up * H_Speed) + (-transform.right * H_Speed * 100 * Time.deltaTime);

            rb2d.velocity += move * Time.deltaTime * 50;
        }

        IEnumerator CreateCatchObj()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_Count_Speed);//この下の処理が()内の数値によって動く
                GameObject _catchObj = Instantiate(Prefab, attachPoint, Quaternion.identity);
                _catchObj.name = Prefab.name;
                _catchObj.transform.SetParent(canvas.transform);
            }
        }
    }
}

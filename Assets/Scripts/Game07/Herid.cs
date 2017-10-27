using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class Herid : MonoBehaviour
    {
        [SerializeField, Header("ヘリのスピード")]
        private float H_Speed = 3;
        [SerializeField, Header("荷物")]
        private GameObject Prefab;
        [SerializeField, Header("荷物の生成速度")]
        private float m_Count_Speed = 5;
        private Vector3 attachPoint;
        //キャンパス情報
        private Canvas canvas;

        void Start()
        {
            canvas = FindObjectOfType<Canvas>();
            StartCoroutine(CreateCatchObj());
        }

        void Update()
        {
            attachPoint = transform.GetChild(1).position;
            transform.position += (transform.up * H_Speed / 2) + (-transform.right * H_Speed * 100 * Time.deltaTime);
        }

        IEnumerator CreateCatchObj()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_Count_Speed);
                GameObject _catchObj = Instantiate(Prefab, attachPoint, Quaternion.identity);
                _catchObj.transform.SetParent(canvas.transform);
            }
        }
    }
}

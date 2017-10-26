using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Game07
{
    public class FallItemBase : MonoBehaviour, IStopObject
    {
        [SerializeField]
        float m_fallSpeed = 3.0f;

        Vector3 m_movePos;
        Transform m_transform;

        private void OnEnable()
        {
            m_transform = m_transform ?? GetComponent<Transform>();
            m_movePos = m_transform.position;
        }

        private void Update()
        {
            m_movePos.y -= m_fallSpeed * Time.deltaTime;
            m_transform.position = m_movePos;

            if(m_movePos.y < -3.5f)
            {
                gameObject.SetActive(false);
            }
        }

        public void SetStop(bool enabled)
        {

        }
    }
}
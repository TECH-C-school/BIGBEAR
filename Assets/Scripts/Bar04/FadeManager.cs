using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//public class FadeManager : SingletonMonoBehaviour<FadeManager>
namespace Assets.Scripts.Bar04
{

    public class FadeMamager : MonoBehaviour
    { }
    /*
        public float m_fadeTime = 0.5f;
        public Color m_fadeColor = Color.white;
        [SerializeField]
        Image m_fadeImage;
        CanvasGroup m_canvas;

        GameObject objects;

        void Start()
        {
            objects = GetComponent<GameObject>();
            m_fadeImage.color = m_fadeColor;

            var canvas = objects.GetComponent<GameObject>();


            FadeIn();
        }

        public void FadeIn(System.Action callback = null)
        {
            // 1 to 0
            m_canvas.DOFade(0.0f, m_fadeTime).SetUpdate(true).OnComplete(() => callback?.Invoke());
        }

        public void FadeOut(System.Action callback = null)
        {
            // 0 to 1
            m_canvas.DOFade(1.0f, m_fadeTime).SetUpdate(true).OnComplete(() => callback?.Invoke());
        }

        private void OnDestroy()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

    #if UNITY_EDITOR
        private void Reset()
        {
            m_fadeImage = transform.GetComponentInChildren<Image>();
        }
    #endif
    }
    */

}
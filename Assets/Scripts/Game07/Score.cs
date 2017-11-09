using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game07
{
    public class Score : MonoBehaviour
    {

        void Start()
        {
            GetComponent<Text>().text = GameController.instance.GetScore().ToString();
        }

        void Update()
        {
            GetComponent<Text>().text = GameController.instance.GetScore().ToString();
        }
    }
}

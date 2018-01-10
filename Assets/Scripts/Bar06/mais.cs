using UnityEngine;
using UnityEngine.UI;

public class mais : MonoBehaviour
{

    private Text targetText;

    static public string nume="";


    static public void rirekii(int gou)
    {
        nume ="× " + gou.ToString();
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = nume.ToString();
    }
}
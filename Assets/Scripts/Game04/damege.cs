using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class damege : MonoBehaviour
{

    int armorPoint;
    public int armorPointMax = 5000;

    public int damage;

    //public Text armorText;

    int displayArmorPoint;

    public Image gaugeImage;


    int var;
    // Use this for initialization
    void Start()
    {
        armorPoint = armorPointMax;
        displayArmorPoint = armorPoint;

    }

    // Update is called once per frame
    void Update()
    {

        //armorText.text = armorPoint.ToString();

        //体力加減算
        if (displayArmorPoint != armorPoint)
        {
            displayArmorPoint = (int)Mathf.Lerp(displayArmorPoint, armorPoint, 0.1f);
        }

        //armorText.text = string.Format("{0:0000} / {1:0000}", displayArmorPoint, armorPointMax);

        //
        float percentageArmorpoint = (float)displayArmorPoint / armorPointMax;
        //ゲージ伸縮
        gaugeImage.transform.localScale = new Vector3(1, percentageArmorpoint, 1);

        if (percentageArmorpoint > 0.5f)
        {
            //gaugeImage.color = Color.green;
        }
        else if (percentageArmorpoint > 0.3f)
        {
            //gaugeImage.color = Color.yellow;
        }
        else
        {
            //gaugeImage.color = Color.red;
        }

        if (Input.GetKeyDown("b"))
        {
            var=Random.Range(0, 9);
            Debug.Log("random");
        }
        

        if(var == 5)
        {
            armorPoint -= damage;
            armorPoint = Mathf.Clamp(armorPoint, 0, armorPointMax);
        }

        if (Input.GetKey("v"))
        {
            armorPoint -= damage;
            armorPoint = Mathf.Clamp(armorPoint, 0, armorPointMax);
        }

        if(armorPoint == 0)
        {
            SceneManager.LoadScene("result_04");
            Debug.Log("result");
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "")
        {
            armorPoint -= damage;
            armorPoint = Mathf.Clamp(armorPoint, 0, armorPointMax);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAp : MonoBehaviour {
    public Image gaugeImage;

    int armorPoint;
    int armorPointMax = 5000;
    int damage = 100;
    
    public Text armorText;

    int displayArmorPoint;

	// Use this for initialization
	void Start () {
        armorPoint = armorPointMax;
        displayArmorPoint = armorPoint;
	}
	
	// Update is called once per frame
	void Update () {

        if (displayArmorPoint != armorPoint)
            displayArmorPoint = (int)Mathf.Lerp(displayArmorPoint, armorPoint, 0.1F);

        armorText.text = string.Format("{0:0000} / {1:0000}",displayArmorPoint,armorPointMax);

        float percetageArmorpoint = (float)displayArmorPoint / armorPointMax;

        if(Input.GetKey("a")){
            armorPoint = armorPoint - damage;
            if (armorPoint == 0000)
            {
                damage = 0;
            }
        }

        if (Input.GetKey("h"))
        {
            armorPoint = armorPoint + 1;
        }


        gaugeImage.transform.localScale = new Vector3(percetageArmorpoint, 1, 1);

        



    }


    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "ShotEnemy")
        {
            armorPoint -= damage;
            armorPoint = Mathf.Clamp(armorPoint, 0, armorPointMax);

            float percentageArmorpoint = (float)displayArmorPoint / armorPointMax;

            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pai : MonoBehaviour {
    public Cardstate cardState;

	void Start () {
        cardState = Cardstate.Omote;
        

    }
    private void OnMouseUp()
    {
        Opencard();
    }
    void Opencard()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        cardState = Cardstate.Ura;
    }
}
public enum Cardstate
{
    Omote,Ura
}
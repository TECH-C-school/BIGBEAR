using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSurrender : MonoBehaviour {

    public void Surrender()
    {
        Sprite coverScripts = null;
        var coverPrefab = Resources.Load<GameObject>("Prefabs/Bar06/cover");
        var coverObject = Instantiate(coverPrefab, transform.position, Quaternion.identity);
        Vector3 move = transform.localPosition;
        coverScripts = Resources.Load<Sprite>("Images/Bar/resultbg");
        coverObject.transform.position = new Vector3(0, 0, 0);
    }
}

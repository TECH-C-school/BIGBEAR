using UnityEngine; 
using System.Collections; 
 
public class ExplodeAnim : MonoBehaviour   
{
    float count = 0;

    void Update()
    {

        count += Time.deltaTime;

        if(count > 0.5f)
        {
            Destroy(gameObject);
        }
    }
} 

using UnityEngine;  

using System.Collections;


public class tranFollowMouseForSensors : MonoBehaviour
{
    private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标  
    private Transform _trans;// 目标物体的空间变换组件  
    private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    private Vector3 _vec30ffset;// 偏移  

    void Awake() { _trans = transform; }//_trar?(buzhidao)

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Translate());
        }
    }

    IEnumerator Translate()
    {
        Debug.Log("in onmousedonw");
        // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标   

        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);
        // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）
        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        // 计算目标物体与鼠标物体在世界空间中的偏移量   
        _vec30ffset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);
        // 鼠标左键按下   

        while (Input.GetMouseButton(0))
        {
            Debug.Log("getmouseutton");
            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  
            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  
            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec30ffset;
            // 更新目标物体的世界空间坐标   
            _trans.position = _vec3TargetWorldSpace;
            //等待固定更新  
            yield return new WaitForFixedUpdate();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Game05
{
    [CreateAssetMenu(menuName = "Game05/GameParam")]
    public class GameParam : ScriptableObject
    {
        public int easyNum;
        public int normalNum;
        public int hardNum;
#if UNITY_EDITOR
        
        static void Param()
        {
            var param = CreateInstance<GameParam>();
            string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Prefabs/Game05/" + typeof(GameParam) + ".asset");
            AssetDatabase.CreateAsset(param, path);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}

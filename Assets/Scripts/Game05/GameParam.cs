﻿using System.Collections;
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
        public const string PATH = "Prefabs/Game05/Param";
        private static GameParam _instance;
        public static GameParam Instance {
            get {
                if(_instance == null) {
                    _instance = Resources.Load<GameParam>(PATH);
                }
                if(_instance == null) {
                    Debug.Log(PATH + " Not found");
                }
                return _instance;
            }
        }
        public int easyNum;
        public int normalNum;
        public int hardNum;
        public float easyDuration;
        public float normalDuration;
        public float hardDuration;
        
#if UNITY_EDITOR
        
        static void CreateParam()
        {
            var param = CreateInstance<GameParam>();
            string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Prefabs/Game05/" + typeof(GameParam) + ".asset");
            AssetDatabase.CreateAsset(param, path);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}

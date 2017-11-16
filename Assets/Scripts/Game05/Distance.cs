using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Assets.Scripts.Game05 {
	
	[CreateAssetMenu(menuName = "Game05/ObjDistance")]
	public class Distance : ScriptableObject {
		public const string PATH = "Prefabs/Game05/Distance";
		private static Distance instance;
		public static Distance Instance {
			get {
				if (instance == null) {
					instance = Resources.Load<Distance> (PATH);
				}
				if (instance == null) {
					Debug.Log (PATH + " Not found");
				}
				return instance;
			}
		}
		public float[] DISTANCES = {
			1, 1.25f, 1.5f, 1.75f, 2, 2.25f, 2.5f, 2.75f, 3, 3.25f
		};
		public float[] PERCENT = {
			1.0f, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f, 0.3f, 0.2f, 0.1f
		};
	#if UNITY_EDITOR
		static void CreateParam()
		{
			var param = CreateInstance<Distance>();
			string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Prefabs/Game05/" + typeof(Distance) + ".asset");
			AssetDatabase.CreateAsset(param, path);
			AssetDatabase.SaveAssets();
		}
	#endif
	}
}
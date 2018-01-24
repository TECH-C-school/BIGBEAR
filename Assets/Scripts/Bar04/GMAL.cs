using UnityEngine;

using UnityEngine.SceneManagement;


namespace Assets.Scripts.Bar04
{
    /// <summary>

    /// Awake前にManagerSceneを自動でロードするクラス

    /// </summary>

    public class GMAL { 



        //ゲーム開始時(シーン読み込み前)に実行される

        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

        public static void LoadManagerScene()
        {
            Debug.Log("GMAL.LoadManagerScene が読み込まれました");
            string managerSceneName = "ManagerSceneAutoLoader";



            //ManagerSceneが有効でない時(まだ読み込んでいない時)だけ追加ロードするように

            if (!SceneManager.GetSceneByName(managerSceneName).IsValid())
            {

                SceneManager.LoadScene(managerSceneName, LoadSceneMode.Additive);

            }

        }

        public static void SceneManagerAutoLoader()
        {
            Debug.Log("GMAL.SceneManagerAutoLoader が読み込まれました");
            string managerSceneName = "SceneManagerAutoLoader";



            //ManagerSceneが有効でない時(まだ読み込んでいない時)だけ追加ロードするように

            if (!SceneManager.GetSceneByName(managerSceneName).IsValid())
            {

                SceneManager.LoadScene(managerSceneName, LoadSceneMode.Additive);

            }

        }

    }
}


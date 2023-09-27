using UnityEngine.SceneManagement;

namespace Utils {
    //Wrapper for Unity's SceneManager. Might be overkill, found it very useful.
    public static class SceneUtils {

        //To avoid hardcoding string literals everywhere. Maybe move to its own data class?
        private static int currentSceneIndex;

        public static void Init() {
            currentSceneIndex = 0;
            SceneManager.LoadScene(0);
        }

        public static void LoadNextScene() {
            currentSceneIndex++;
            SceneManager.LoadScene(currentSceneIndex);
        }

    }
}

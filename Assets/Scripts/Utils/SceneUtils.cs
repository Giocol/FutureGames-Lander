﻿using UnityEngine.SceneManagement;

namespace Utils {
    public static class SceneUtils {

        //To avoid hardcoding string literals everywhere. Maybe move to its own data class?
        public static string MainMenuScene => "MainMenu";
        public static string Level1Scene => "SampleScene";


        public static void LoadScene(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

        public static void UnloadScene(string sceneName) {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
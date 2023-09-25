using UnityEngine;
using UnityEngine.SceneManagement;

namespace Init
{
    public class Init
    {
        [RuntimeInitializeOnLoadMethod]
        public static void InitGame()
        {
            //init flow goes here
            /*
            var go = new GameObject();
            go.name = "GameState";
            var gameState = go.AddComponent<GameState>();
            gameState.Initialize();
            */
            SceneManager.LoadScene("MainMenu");
        }
    }
}
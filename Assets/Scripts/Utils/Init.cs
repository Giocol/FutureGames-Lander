using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {
    public class Init {
        [RuntimeInitializeOnLoadMethod]
        public static void InitGame() {
            //init flow goes here
            /*
            var go = new GameObject();
            go.name = "GameState";
            var gameState = go.AddComponent<GameState>();
            gameState.Initialize();
            */
            ScoreboardUtils.Init("scoreboard.json");
            SceneUtils.Init();
        }
    }
}

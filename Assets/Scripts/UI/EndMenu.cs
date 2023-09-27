using UnityEngine;
using Utils;

namespace UI
{
    public class EndMenu : MonoBehaviour
    {
        public void RestartGame() {
            Debug.Log("Restarting...");
            Init.InitGame();
        }

        public void ExitGame() {
            Application.Quit();
        }
    }
}

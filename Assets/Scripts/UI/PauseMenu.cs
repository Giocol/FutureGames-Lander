using UnityEngine;
using Utils;

namespace UI {
    public class PauseMenu : MonoBehaviour{
        public void Resume() {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        public void BackToMainMenu() {
            Time.timeScale = 1;
            Init.InitGame();
        }

        public void ExitGame() {
            Application.Quit();
        }
    }
}

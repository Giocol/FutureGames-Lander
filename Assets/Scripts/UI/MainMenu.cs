using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace UI {
    public class MainMenu : MonoBehaviour {
        public void StartGame() {
            SceneUtils.LoadScene(SceneUtils.Level1Scene);
        }

        public void ExitGame() {
            Application.Quit();
        }
    }

}

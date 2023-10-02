using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using Utils;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace UI {
    public class MainMenu : MonoBehaviour {
        [SerializeField] private GameObject mainMenuContainer;
        [SerializeField] private GameObject scoreboardContainer;
        [SerializeField] private TMP_Text scoreboardText;

        private List<LevelScore> highestScores;

        private void Start() {
            highestScores = ScoreboardUtils.ComputeHighestScorePerLevel(ScoreboardUtils.GetJsonScoreboardFromDisk());
        }

        public void StartGame() {
            SceneUtils.LoadNextScene();
        }

        public void ExitGame() {
            Application.Quit();
        }

        public void ReturnToMainMenu() {
            mainMenuContainer.SetActive(true);
            scoreboardContainer.SetActive(false);
        }

        public void OpenScoreboard() {
            mainMenuContainer.SetActive(false);
            scoreboardContainer.SetActive(true);

            scoreboardText.text = string.Join("\n\n", highestScores.Select(e => $"Level Name: {e.levelName}\tCompletion Time: {e.completionTime}s"));
        }
    }

}

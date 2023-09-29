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
            highestScores = ComputeHighestScorePerLevel(ScoreboardUtils.GetJsonScoreboardFromDisk());
        }

        private List<LevelScore> ComputeHighestScorePerLevel(string jsonScoreboard) {
            Debug.Log(jsonScoreboard);
            string[] stringScoreboardArray = jsonScoreboard.Split('}');

            List<LevelScore> allScores = new List<LevelScore>();

            for(int i = 0; i < stringScoreboardArray.Length - 1; i++ ) { // We don't look at the last element of the stringScoreboard array because it always contains just \n\r
                allScores.Add(JsonUtility.FromJson<LevelScore>(stringScoreboardArray[i] + "}"));
            }

            allScores.Sort((a, b) => a.completionTime.CompareTo(b.completionTime));

            List<LevelScore> highestScores = new List<LevelScore>();
            foreach(LevelScore score in allScores) {
                if(highestScores.All(e => e.levelName != score.levelName)) {
                    highestScores.Add(score);
                }
            }
            return highestScores;
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

            scoreboardText.text = string.Join("\n\n", highestScores.Select(e => $"Level Name: {e.levelName}\tCompletion Time: {e.completionTime}"));
        }
    }

}

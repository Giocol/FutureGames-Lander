using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Utils {
    public static class ScoreboardUtils {

        private static string scoreboardFilePath;

        public static void Init(string scoreboardJsonFileName) {
            ScoreboardUtils.scoreboardFilePath = Application.persistentDataPath + "/"+ scoreboardJsonFileName;
        }

        public static void WriteToScoreboard(string levelName, float score, int index) {
            LevelScore scoreSo = new LevelScore {
                levelName = levelName,
                completionTime = score,
                levelIndex = index
            };

            string jsonToWrite = JsonUtility.ToJson(scoreSo, true);

            StreamWriter writer = new StreamWriter(scoreboardFilePath, true);
            writer.WriteLine(jsonToWrite);

            writer.Close();
        }

        public static string GetJsonScoreboardFromDisk() {
            if(File.Exists(scoreboardFilePath)) {
                StreamReader reader = new StreamReader(scoreboardFilePath);
                return reader.ReadToEnd();
            }
            else {
                return "No scores tracked";
            }
        }

        public static List<LevelScore> ComputeHighestScorePerLevel(string jsonScoreboard) {
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

            highestScores.Sort((a, b) => a.levelIndex.CompareTo(b.levelIndex)); // sort by the level's build index
            return highestScores;
        }

    }
}

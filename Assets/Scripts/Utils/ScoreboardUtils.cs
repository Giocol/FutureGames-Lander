using System.IO;
using UnityEngine;

namespace Utils {
    public static class ScoreboardUtils {

        private static string scoreboardFilePath;

        public static void Init(string scoreboardJsonFileName) {
            ScoreboardUtils.scoreboardFilePath = Application.persistentDataPath + "/"+ scoreboardJsonFileName;
        }

        public static void WriteToScoreboard(string levelName, float score) {
            LevelScore scoreSo = new LevelScore {
                levelName = levelName,
                completionTime = score
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
    }
}

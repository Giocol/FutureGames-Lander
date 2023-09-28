using UnityEngine;

namespace Utils {
    public class ScoreboardUtils {

        public static string scoreboardFileName;

        public static void Init(string scoreboardJsonFileName) {
            ScoreboardUtils.scoreboardFileName = scoreboardJsonFileName;
        }

        public static void WriteToScoreboard(string levelName, float score) {
            LevelScore scoreSo = ScriptableObject.CreateInstance<LevelScore>();
            scoreSo.levelName = levelName;
            scoreSo.completionTime = score;

            string jsonToWrite = JsonUtility.ToJson(scoreSo, true);
        }
    }
}

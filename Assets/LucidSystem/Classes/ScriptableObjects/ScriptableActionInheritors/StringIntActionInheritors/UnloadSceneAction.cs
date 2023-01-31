using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lucid
{
    [CreateAssetMenu(fileName = "Unload Scene Action", menuName = "Actions/Game Flow/Unload Scene Action")]
    public class UnloadSceneAction : StringIntAction
    {
        public override void Execute(string str, int val)
        {
            string levelName = FindObjectOfType<LevelInitializer>().levelProfile.levelName;
            string levelString = $"{levelName}Area{val}";

            if (SceneManager.GetSceneByName(levelString).isLoaded) SceneManager.UnloadSceneAsync(levelString);
        }
    }
}

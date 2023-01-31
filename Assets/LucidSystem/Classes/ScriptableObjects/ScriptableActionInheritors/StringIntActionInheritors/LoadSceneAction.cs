using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lucid
{
    [CreateAssetMenu(fileName = "Load Scene Action", menuName = "Actions/Game Flow/Load Scene Action")]
    public class LoadSceneAction : StringIntAction
    {
        public override void Execute(string str, int val)
        {
            string levelName = FindObjectOfType<LevelInitializer>().levelProfile.levelName;
            string levelString = $"{levelName}Area{val}";

            if (SceneManager.GetSceneByName(levelString).isLoaded == false) SceneManager.LoadSceneAsync(levelString, LoadSceneMode.Additive);
        }
    }
}

using UnityEngine;

namespace Lucid
{
    [CreateAssetMenu(fileName = "New Level Profile", menuName = "Data Storage/Level Profile")]
    public class LevelProfile : ScriptableObject
    {
        public string levelName;
    }
}

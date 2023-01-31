using UnityEngine;

namespace Lucid.Breakout
{
    public class GenerateBlockGrid : MonoBehaviour
    {
        [SerializeField] int gridWidth;
        [SerializeField] int gridRows;
        [SerializeField] GameObject blockPrefab;
        [SerializeField] Vector2 spacingWAndH;
        [SerializeField] Vector2 topLeftPoint;

        private void Start()
        {
            GenerateGrid(gridWidth, gridRows, topLeftPoint, spacingWAndH, blockPrefab);
        }

        private void GenerateGrid(int width, int rows, Vector2 start, Vector2 spacing, GameObject prefab)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    float offsetX = start.x + (j * spacing.x);
                    float offsetY = start.y - (i * spacing.y);
                    Vector3 genPoint = new Vector3(offsetX, 1.05f, offsetY);
                    Instantiate(prefab, genPoint, Quaternion.identity);
                }
            }
        }
    }
}

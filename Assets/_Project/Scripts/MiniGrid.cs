using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateTTT
{
    public class MiniGrid : Singleton<MiniGrid>
    {
        public int[,] gridState = new int[3, 3]; // 0: empty, 1: X, 2: O

        public GameObject[,] cells = new GameObject[3, 3];

        public List<GameObject> miniGridObject;

        public List<Sprite> PlayerSprites;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridState[i, j] = 0;
                }
            }

            int cellCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = miniGridObject[cellCount].gameObject;
                    cellCount++;
                }
            }
        }

        public void UpdateMiniGrid(int x, int y, int player)
        {
            cells[x, y].GetComponent<Image>().sprite = PlayerSprites[player];
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class SubGridController : MonoBehaviour
{
    public int[,] gridState = new int[3, 3]; // 0: empty, 1: X, 2: O
    public bool isWon = false;
    public int winner = 0; // 0: no winner, 1: X, 2: O

    // Reference to the cells (these should be set in the editor or dynamically)
    public List<Cell> cellList;
    public GameObject[,] cells = new GameObject[3, 3];
    public GameObject whiteSquare;
    public GameObject winObject;
    public List<Sprite> winSymbol;

    private void Start()
    {
        // Initialize grid state to empty
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
                cells[i, j] = cellList[cellCount].gameObject;
                cellCount++;
            }
        }
    }

    // Method to handle player move
    public bool MakeMove(int x, int y, int player)
    {
        if (gridState[x, y] == 0 && !isWon)
        {
            gridState[x, y] = player;
            UpdateCellVisual(x, y, player);
            CheckWinCondition();
            return true;
        }

        return false;
    }

    // Update the visual representation of the cell
    private void UpdateCellVisual(int x, int y, int player)
    {
        // Assuming each cell has a Text or SpriteRenderer to show X or O
        if (player == 1)
        {
            cells[x, y].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("X");
        }
        else
        {
            cells[x, y].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("O");
        }
    }

    // Method to check for win condition
    private void CheckWinCondition()
    {
        // Check rows, columns, and diagonals for a win
        for (int i = 0; i < 3; i++)
        {
            if (gridState[i, 0] == gridState[i, 1] && gridState[i, 1] == gridState[i, 2] && gridState[i, 0] != 0)
                SetWin(gridState[i, 0]);
            if (gridState[0, i] == gridState[1, i] && gridState[1, i] == gridState[2, i] && gridState[0, i] != 0)
                SetWin(gridState[0, i]);
        }

        if (gridState[0, 0] == gridState[1, 1] && gridState[1, 1] == gridState[2, 2] && gridState[0, 0] != 0)
            SetWin(gridState[0, 0]);
        if (gridState[0, 2] == gridState[1, 1] && gridState[1, 1] == gridState[2, 0] && gridState[0, 2] != 0)
            SetWin(gridState[0, 2]);
    }

    private void SetWin(int player)
    {
        isWon = true;
        winner = player;
        whiteSquare.SetActive(true);
        winObject.SetActive(true);
        winObject.GetComponent<SpriteRenderer>().sprite = winSymbol[player];
        // Optionally, update visuals for the sub-grid to indicate the win
    }
}
using System;
using System.Collections.Generic;
using UltimateTTT;
using UnityEngine;

public class MainBoardController : Singleton<MainBoardController>
{
    public List<SubGridController> SubGridsList;
    public SubGridController[,] subGrids = new SubGridController[3, 3]; // Attach sub-grids in editor or dynamically

    public int[,] mainGridState = new int[3, 3]; // Tracks the winner of each sub-grid
    public bool isGameOver = false;

    private void Start()
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                subGrids[i, j] = SubGridsList[count];
                count++;
            }
        }
        // Initialize the main grid state
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                mainGridState[i, j] = 0;
            }
        }
    }

    // Method to make a move on a sub-grid
    public void MakeMove(int subGridX, int subGridY, int cellX, int cellY, int player)
    {
        if (!isGameOver && subGrids[subGridX, subGridY].MakeMove(cellX, cellY, player))
        {
            if (subGrids[subGridX, subGridY].isWon)
            {
                Debug.Log("1");
                mainGridState[subGridX, subGridY] = subGrids[subGridX, subGridY].winner;
                MiniGrid.Instance.UpdateMiniGrid(subGridX, subGridY, player);
                CheckMainGridWinCondition();
                StartCoroutine(CameraController.Instance.JumpToGrid(cellX,cellY));
            }
            else
            {
                StartCoroutine(CameraController.Instance.JumpToGrid(cellX,cellY));
                Debug.Log("2");
            }
        }
        else
        {
            if (isGameOver == false)
            {
                StartCoroutine(CameraController.Instance.JumpToGrid(cellX,cellY));
                Debug.Log("3");
            }
        }
    }

    // Method to check the win condition for the main grid
    private void CheckMainGridWinCondition()
    {
        for (int i = 0; i < 3; i++)
        {
            if (mainGridState[i, 0] == mainGridState[i, 1] && mainGridState[i, 1] == mainGridState[i, 2] && mainGridState[i, 0] != 0)
                EndGame(mainGridState[i, 0]);
            if (mainGridState[0, i] == mainGridState[1, i] && mainGridState[1, i] == mainGridState[2, i] && mainGridState[0, i] != 0)
                EndGame(mainGridState[0, i]);
        }
        if (mainGridState[0, 0] == mainGridState[1, 1] && mainGridState[1, 1] == mainGridState[2, 2] && mainGridState[0, 0] != 0)
            EndGame(mainGridState[0, 0]);
        if (mainGridState[0, 2] == mainGridState[1, 1] && mainGridState[1, 1] == mainGridState[2, 0] && mainGridState[0, 2] != 0)
            EndGame(mainGridState[0, 2]);

    }

    private void EndGame(int winner)
    {
        isGameOver = true;
        CameraController.Instance.CenterCam();
        Debug.Log("Player " + winner + " wins!");
        // Trigger any end game UI, animations, etc.
    }
}

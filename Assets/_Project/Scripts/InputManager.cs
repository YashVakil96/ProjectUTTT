using UltimateTTT;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public MainBoardController mainBoardController;
    private int currentPlayer = 1;
    public bool firstMove;
    public int lastSubGridX;
    public int lastSubGridY;


    void Update()
    {
        if (mainBoardController.isGameOver)
        {
            return;
        }

        // Handle mouse clicks or touches
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Cell cell = hit.collider.GetComponent<Cell>();
                if (cell != null && !cell.IsOccupied)
                {
                    if (!firstMove)
                    {
                        mainBoardController.MakeMove(cell.SubGridX, cell.SubGridY, cell.CellX, cell.CellY,
                            currentPlayer);
                        cell.OccupyCell(currentPlayer);
                        SwitchPlayer();
                        lastSubGridX = cell.CellX;
                        lastSubGridY = cell.CellY;
                        firstMove = true;
                    }
                    else if (lastSubGridX == cell.SubGridX && lastSubGridY == cell.SubGridY &&
                             !mainBoardController.subGrids[lastSubGridX, lastSubGridY].isWon)
                    {
                        mainBoardController.MakeMove(cell.SubGridX, cell.SubGridY, cell.CellX, cell.CellY,
                            currentPlayer);
                        cell.OccupyCell(currentPlayer);
                        SwitchPlayer();
                        lastSubGridX = cell.CellX;
                        lastSubGridY = cell.CellY;
                    }
                    else if (mainBoardController.subGrids[lastSubGridX, lastSubGridY].isWon)
                    {
                        if (!mainBoardController.subGrids[cell.SubGridX, cell.SubGridY].isWon)
                        {
                            mainBoardController.MakeMove(cell.SubGridX, cell.SubGridY, cell.CellX, cell.CellY,
                                currentPlayer);
                            cell.OccupyCell(currentPlayer);
                            SwitchPlayer();
                            lastSubGridX = cell.CellX;
                            lastSubGridY = cell.CellY;
                        }
                        else
                        {
                            Debug.Log("Invalid Move");
                        }
                    }
                    else
                    {
                        Debug.Log("Invalid Move");
                    }
                }
            }
            else
            {
                Debug.Log("Noting hit");
            }
        }
    }

    void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        UIManager.Instance.ChangeCurrentPlayerImage(currentPlayer);
    }
}
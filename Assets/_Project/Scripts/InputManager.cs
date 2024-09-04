using UnityEngine;

public class InputManager : MonoBehaviour
{
    public MainBoardController mainBoardController;
    private int currentPlayer = 1;

    void Update()
    {
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
                    Debug.Log(cell);
                    Debug.Log(cell.GetComponent<Cell>());
                    Debug.Log(cell.GetComponent<BoxCollider2D>());
                    mainBoardController.MakeMove(cell.SubGridX, cell.SubGridY, cell.CellX, cell.CellY, currentPlayer);
                    cell.OccupyCell(currentPlayer);
                    SwitchPlayer();
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
    }
}
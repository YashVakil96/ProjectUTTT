using UnityEngine;

public class Cell : MonoBehaviour
{
    public int SubGridX;
    public int SubGridY;
    public int CellX;
    public int CellY;
    public bool IsOccupied = false;

    public void OccupyCell(int player)
    {
        IsOccupied = true;
        // Update visual based on player (X or O)
        if (player == 1)
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("X");
        else
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("O");
    }
}
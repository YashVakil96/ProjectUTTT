using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int SubGridX;
    public int SubGridY;
    public int CellX;
    public int CellY;
    public bool IsOccupied = false;
    public MMF_Player cellRotation;

    public void Start()
    {
        cellRotation.Initialization();
    }

    public void OccupyCell(int player)
    {
        StartCoroutine(AnimateCell(player));
    }

    IEnumerator AnimateCell(int player)
    {
        cellRotation.PlayFeedbacks();
        yield return new WaitForSeconds(1f);
        IsOccupied = true;
        // Update visual based on player (X or O)
        if (player == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("X");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("O");
        }
    }
}
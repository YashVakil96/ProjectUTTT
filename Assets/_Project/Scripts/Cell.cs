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
        Debug.Log("0");
        StartCoroutine(AnimateCell(player));
        Debug.Log("1");
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
            Debug.Log("2");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("O");
            Debug.Log("2");
        }
    }
}
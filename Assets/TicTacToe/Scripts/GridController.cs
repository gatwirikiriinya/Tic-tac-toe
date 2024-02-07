using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public GameObject _mCellPrefab;

    private Cell[] _mCells = new Cell[9];

    public GameObject strikePrefab;

    private void ShowStrike(Vector3 position, Quaternion rotation)
    {
        Instantiate(strikePrefab, position, rotation);
    }


    public void Build(GameController main)
    {
        for (int i = 0; i <= 8; i++)
        {
            GameObject newCell = Instantiate(_mCellPrefab, transform);
            _mCells[i] = newCell.GetComponent<Cell>();
            _mCells[i].mMain = main;
        }
    }

    public bool CheckForWinner()
    {
        // Horizontal win check
        for (int i = 0; i < 9; i += 3)
        {
            if (CheckValues(i, i + 1) && CheckValues(i, i + 2))
            {
                // Calculate position for horizontal strike
                Vector3 strikePosition = (_mCells[i].transform.position + _mCells[i + 2].transform.position) / 2f;
                Quaternion strikeRotation = Quaternion.identity; // No rotation needed for horizontal win
                ShowStrike(strikePosition, strikeRotation);
                return true;
            }
        }

        // Vertical win check
        for (int i = 0; i < 3; i++)
        {
            if (CheckValues(i, i + 3) && CheckValues(i, i + 6))
            {
                // Calculate position for vertical strike
                Vector3 strikePosition = (_mCells[i].transform.position + _mCells[i + 6].transform.position) / 2f;
                Quaternion strikeRotation = Quaternion.Euler(0f, 0f, 90f); // Rotate 90 degrees for vertical win
                ShowStrike(strikePosition, strikeRotation);
                return true;
            }
        }

        // Diagonal win check
        if (CheckValues(0, 4) && CheckValues(0, 8))
        {
            // Calculate position for diagonal strike (top-left to bottom-right)
            Vector3 strikePosition = (_mCells[0].transform.position + _mCells[8].transform.position) / 2f;
            Quaternion strikeRotation = Quaternion.Euler(0f, 0f, -45f); // Rotate -45 degrees for diagonal win
            ShowStrike(strikePosition, strikeRotation);
            return true;
        }
        if (CheckValues(2, 4) && CheckValues(2, 6))
        {
            // Calculate position for diagonal strike (top-right to bottom-left)
            Vector3 strikePosition = (_mCells[2].transform.position + _mCells[6].transform.position) / 2f;
            Quaternion strikeRotation = Quaternion.Euler(0f, 0f, 45f); // Rotate 45 degrees for diagonal win
            ShowStrike(strikePosition, strikeRotation);
            return true;
        }

        return false;
    }
    private  bool CheckValues(int firstIndex, int secondIndex)
    {
        string firstValue = _mCells[firstIndex].mLabel.text;
        string secondValue = _mCells[secondIndex].mLabel.text;

        if (firstValue == "" || secondValue == "")
            return false;

        if (firstValue == secondValue) return true;

        else return false;
    }

    public void ResetGrid()
    {
        foreach (Cell cell in _mCells)
        {
            cell.mLabel.text = ""; // Clear the text
            cell.mButton.interactable = true; // Enable button interaction
        }
    }

}

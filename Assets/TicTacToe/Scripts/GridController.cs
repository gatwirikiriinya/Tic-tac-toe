using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public GameObject _mCellPrefab;

    private Cell[] _mCells = new Cell[9];

    public GameObject[] verticalStrikes;
    public GameObject[] horizontalStrikes;
    public GameObject[] diagonalStrikes;

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
                ActivateHorizontalStrike(i / 3);
                return true;
            }
        }

        // Vertical win check
        for (int i = 0; i < 3; i++)
        {
            if (CheckValues(i, i + 3) && CheckValues(i, i + 6))
            {
                ActivateVerticalStrike(i);
                return true;
            }
        }

        // Diagonal win check
        if (CheckValues(0, 4) && CheckValues(0, 8))

        {
            ActivateDiagonalStrike(0); // Top-left to bottom-right
            return true;
        }

        if (CheckValues(2, 4) && CheckValues(2, 6))
        {
            ActivateDiagonalStrike(1); // Top-right to bottom-left
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

    private void ActivateVerticalStrike(int column)
    {
        verticalStrikes[column].SetActive(true);

    }
    private void ActivateHorizontalStrike(int row)
    {
        horizontalStrikes[row].SetActive(true);
    }

    private void ActivateDiagonalStrike(int type)
    {
        if (type == 0) // Top-left to bottom-right
        {
            for (int i = 0; i < 3; i++)
            {
                diagonalStrikes[0].SetActive(true);
            }
        }
        else // Top-right to bottom-left
        {
            for (int i = 0; i < 3; i++)
            {
                diagonalStrikes[1].SetActive(true);
            }
        }
    }

    public void ResetGrid()
    {
        foreach (Cell cell in _mCells)
        {
            cell.mLabel.text = ""; // Clear the text
            cell.mButton.interactable = true; // Enable button interaction
        }

        foreach (GameObject strike in verticalStrikes)
        {
            strike.SetActive(false); // Deactivate vertical strikes
        }

        foreach (GameObject strike in horizontalStrikes)
        {
            strike.SetActive(false); // Deactivate horizontal strikes
        }

        foreach (GameObject strike in diagonalStrikes)
        {
            strike.SetActive(false); // Deactivate diagonal strikes
        }
    }

}

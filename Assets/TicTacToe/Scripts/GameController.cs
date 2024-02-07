using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
    public GridController _mGrid;

    public TextMeshProUGUI topText;

    private bool mXTurn = true;

    private int mTurnCount = 0;

    private bool gameEnded = false;

    public GameObject resetButton;

    void Awake()
    {
        _mGrid.Build(this);
        UpdateTurnText();


    }

    public void Switch()

    {
        if (gameEnded) return;

        mTurnCount++;

       bool hasWinner =  _mGrid.CheckForWinner();

        if (hasWinner)
        {
            Debug.Log("Winner!");
            gameEnded = true;
            topText.text = $"Player {GetTurnCharacter()} wins!";
            resetButton.SetActive(true);
        }
        else if(mTurnCount >= 9) {
            gameEnded = true;
            topText.text = "It's a draw!";
            resetButton.SetActive(true);

        }
        else
        {
            mXTurn = !mXTurn;
            UpdateTurnText();
        }

    }

    public string GetTurnCharacter()
    {
        if(mXTurn)
        {
            return "X";
        }
        else
        {
            return "O";
        }
    }

    private void UpdateTurnText()
    {
        topText.text =$"Player {GetTurnCharacter()}'s turn";
    }

    public void ResetGame()
    {
        mXTurn = true;
        mTurnCount = 0;
        gameEnded = false;
        topText.text = "Player X's turn";
        resetButton.SetActive(false);
        _mGrid.ResetGrid();
    }
}

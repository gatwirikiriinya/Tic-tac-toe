using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Cell : MonoBehaviour
{

    public TextMeshProUGUI mLabel;
    public Button mButton;
    public GameController mMain;
    public Color xColor = Color.red;
    public Color oColor = Color.blue;

    public void Fill()
    {

        mButton.interactable = false;

        mLabel.text = mMain.GetTurnCharacter();

        mMain.Switch();

        if (mMain.GetTurnCharacter() == "X")
            mLabel.color = oColor;
        if (mMain.GetTurnCharacter() == "O")
            mLabel.color = xColor;


    }

}

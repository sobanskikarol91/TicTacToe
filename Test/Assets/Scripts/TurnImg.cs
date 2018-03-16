using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnImg : MonoBehaviour
{
    [SerializeField]
    Text text;
    string turnTxt = "Turn: ";

    public void UpdateText(PLAYER currentPlayer)
    {
        text.text = turnTxt + currentPlayer.ToString();
    }

}

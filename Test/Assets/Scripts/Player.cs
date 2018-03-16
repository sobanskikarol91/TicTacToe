using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    public Text scoreTxt;

    int points;
    public int Points { get { return points; } set { points = value; scoreTxt.text = points.ToString(); } }
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    PLAYER playerNr;

    bool hisTurn;
    public bool HisTurn { get { return hisTurn; } set { hisTurn = value; ChooseTile(); } }

    protected abstract void ChooseTile();

    public PLAYER GetPlayerNr()
    {
        return playerNr;
    }

    public Sprite GetPlayerSprite()
    {
        return sprite;
    }
}

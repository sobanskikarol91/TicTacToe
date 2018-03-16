using UnityEngine;
using System.Collections;

public class Computer : Player
{
    TicTacToe ticTacToe;

    private void Start()
    {
        ticTacToe = GameManager.instance.TicTacToe;
    }

    protected override void ChooseTile()
    {

    }
}

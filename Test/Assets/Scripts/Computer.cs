using UnityEngine;
using System.Collections;

public class Computer : Player
{
    TicTacToe ticTacToe;
    public float delayMove;

    private void Start()
    {
        delayMove = GameSettings.instance.computerDelayMove;
        ticTacToe = GameManager.instance.TicTacToe;
    }

    protected override void ChooseTile()
    {
        StartCoroutine(DelayMove());
    }

    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(delayMove);
        TileController randomTile = RandomTile();
        randomTile.PlayerChoseTile();
    }

    TileController RandomTile()
    {
        ticTacToe = GameManager.instance.TicTacToe;
        TileController[] tilesToUse = ticTacToe.ReturnNotUsedTitles().ToArray();
        int index = Random.Range(0, tilesToUse.Length);
        return tilesToUse[index];
    }
}

using UnityEngine;
using System.Collections;

public class TicTacToe : MonoBehaviour
{
    public TileController[] tc;

    int roundNr = 0;
    const int maxRounds = 9;
    const int length = 3; //  columns or rows amount


    bool CheckColumns(PLAYER nr)
    {
        for (int i = 0; i < length; i++)
            if (CheckColumn(i, nr))
            {
                return true;
            }

        return false;
    }

    bool CheckColumn(int col, PLAYER nr)
    {

        return (tc[0 + col].PlayerNr == nr &&
    tc[3 + col].PlayerNr == nr &&
     tc[6 + col].PlayerNr == nr);

    }

    bool CheckRows(PLAYER nr)
    {
        for (int i = 0; i < length; i++)
            if (CheckRow(i, nr))
            {
                return true;
            }


        return false;
    }

    bool CheckRow(int row, PLAYER nr)
    {
        int offset = length * row;

        return (tc[0 + offset].PlayerNr == nr &&
        tc[1 + offset].PlayerNr == nr &&
        tc[2 + offset].PlayerNr == nr);
    }

    public TTT_STATES CheckWinConditions()
    {
        PLAYER nr = GameManager.instance.CurrentPlayer.GetPlayerNr();
        roundNr++;

        if (CheckRows(nr) || CheckColumns(nr) || CheckDiagonals(nr))
            return TTT_STATES.WIN;
        else if (roundNr == maxRounds)
            return TTT_STATES.DRAW;
        else
            return TTT_STATES.NONE;
    }

    bool CheckDiagonals(PLAYER nr)
    {
        return tc[0].PlayerNr == nr && tc[4].PlayerNr == nr && tc[8].PlayerNr == nr ||
         tc[2].PlayerNr == nr && tc[4].PlayerNr == nr && tc[6].PlayerNr == nr;
    }

    public void Restart()
    {
        roundNr = 0;

        foreach (TileController t in tc)
            t.Restart();
    }
}

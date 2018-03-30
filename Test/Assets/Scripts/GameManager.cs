using UnityEngine;
using System.Linq;

[RequireComponent(typeof(GameSettings), typeof(TicTacToe))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TicTacToe TicTacToe { get; private set; }
    Player[] players;
    MenuManager menuManager;
    public Player CurrentPlayer { get; private set; }

    public TurnImg turnImg;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        TicTacToe = GetComponent<TicTacToe>();
        menuManager = GetComponent<MenuManager>();
        StartGame();
    }

    void StartGame()
    {
        GetPlayers();
        ChooseFirstPlayer();
        UpdateTurnImg();
    }

    void GetPlayers()
    {
        players = GetComponents<Player>();

        if (players.Length < 1)
            Debug.LogError("need 2 players ");
    }

    void ChooseFirstPlayer()
    {
        int nr = Random.Range(0, players.Length);
        CurrentPlayer = players[nr];
        players[nr].HisTurn = true;
    }

    bool IsGameOver()
    {
        return players.Any(t => t.Points > GameSettings.instance.maxPoints);
    }

    public void UpdateTurnImg()
    {
        turnImg.UpdateText(CurrentPlayer.GetPlayerNr());
    }

    public void ChangePlayers()
    {
        CurrentPlayer.HisTurn = false;

        if (CurrentPlayer.GetPlayerNr() == players[0].GetPlayerNr())
            CurrentPlayer = players[1];
        else
            CurrentPlayer = players[0];

        CurrentPlayer.HisTurn = true;
        UpdateTurnImg();
    }

    public void PlayerChoseTile()
    {
        TTT_STATES result = TicTacToe.CheckWinConditions();

        switch (result)
        {
            case TTT_STATES.NONE:
                {
                    ChangePlayers();
                    break;
                }
            case TTT_STATES.WIN:
                {
                    CurrentPlayer.Points++;
                    menuManager.Win(CurrentPlayer.GetPlayerNr());
                    break;
                }
            case TTT_STATES.DRAW:
                {
                    menuManager.Draw();
                    break;
                }
        }
    }

    public void NextRound()
    {
        TicTacToe.Restart();
        StartGame();
    }

    public bool isHumanTurn()
    {
        return CurrentPlayer.GetPlayerNr() == PLAYER.P;
    }
}

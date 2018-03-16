using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameOverText;
    [SerializeField]
    string winTxt = " Wins!";
    [SerializeField]
    string drawTxt = "Draw!";

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void Draw()
    {
        ShowPanel(true);
        gameOverText.text = drawTxt;
    }

    public void Win(PLAYER winner)
    {
        ShowPanel(true);
        gameOverText.text = winner + winTxt; 
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        ShowPanel(false);
        GameManager.instance.NextRound();
    }

    void ShowPanel(bool state)
    {
        gameOverPanel.SetActive(state);
    }
}

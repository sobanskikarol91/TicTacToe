using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    Image image;
    public bool IsChoosen { get; private set; }

    public Sprite defaultSprite;
    public PLAYER PlayerNr { get; set; }

    private void Awake()
    {
        PlayerNr = PLAYER.NONE;
        image = GetComponent<Image>();
    }


    public void HumanClickTile()
    {
        if (GameManager.instance.isHumanTurn())
            PlayerChoseTile();
    }

    public void PlayerChoseTile()
    {
        if (IsChoosen) return;
        IsChoosen = true;
        Player player = GameManager.instance.CurrentPlayer;
        image.sprite = player.GetPlayerSprite();
        PlayerNr = player.GetPlayerNr();

        GameManager.instance.PlayerChoseTile();
    }

    public void Restart()
    {
        image.sprite = defaultSprite;
        IsChoosen = false;
        PlayerNr = PLAYER.NONE;
    }
}

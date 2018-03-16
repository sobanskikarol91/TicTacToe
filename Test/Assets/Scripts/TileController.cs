using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    Image image;
    bool isChoosen;

    public Sprite defaultSprite;
    public PLAYER PlayerNr { get; set; }

    private void Start()
    {
        PlayerNr = PLAYER.NONE;
        image = GetComponent<Image>();
    }

    public void PlayerChoseTile()
    {
        if (isChoosen) return;

        isChoosen = true;
        Player player = GameManager.instance.CurrentPlayer;

        image.sprite = player.GetPlayerSprite();
        PlayerNr = player.GetPlayerNr();

        GameManager.instance.PlayerChoseTile();
    }

    public void Restart()
    {
        image.sprite = defaultSprite;
        isChoosen = false;
        PlayerNr = PLAYER.NONE;
    }
}

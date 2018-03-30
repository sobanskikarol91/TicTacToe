using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;
    public int maxPoints = 3;
    public float computerDelayMove = 3;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}

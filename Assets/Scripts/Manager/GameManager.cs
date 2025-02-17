using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isPlayerInGame = false;

    private void Awake()
    {
        Instance = this;
    }

    public bool IsMove()
    {
        return isPlayerInGame;
    }
}

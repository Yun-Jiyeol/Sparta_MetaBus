using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isPlayerInGame = false;
    public List<GameObject> Havecollider;
    //모든 맵의 콜라이더를 가지고 있는 것들(미니게임의 방해됨)

    private void Awake()
    {
        Instance = this;
    }

    public bool IsMove()
    {
        return isPlayerInGame;
    }
    public void StartMinigame()
    {
        foreach (GameObject gameObject in Havecollider)
        {
            gameObject.SetActive(false);
        }
    }
    public void EndMinigame()
    {
        foreach (GameObject gameObject in Havecollider)
        {
            gameObject.SetActive(true);
        }
    }
}

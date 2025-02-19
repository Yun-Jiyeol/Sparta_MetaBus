using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isPlayerInGame = false;
    public List<GameObject> Havecollider;
    //��� ���� �ݶ��̴��� ������ �ִ� �͵�(�̴ϰ����� ���ص�)

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isPlayerInGame = false;
    public List<GameObject> Havecollider;
    public PlayerInput playerInput;
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
        playerInput.enabled = false;
        Invoke("InvokeStartMinigame", 1f);
    }
    void InvokeStartMinigame()
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
        Invoke("InvokeEndMinigame", 0.3f);
    }
    void InvokeEndMinigame()
    {
        playerInput.enabled = true;
    }
}

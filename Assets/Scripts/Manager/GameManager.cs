using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isPlayerInGame = false;
    public List<GameObject> Havecollider;
    public PlayerInput playerInput;
    //��� ���� �ݶ��̴��� ������ �ִ� �͵�(�̴ϰ����� ���ص�)

    public float PlayerHP = 100; //���� ü��
    public float PlayerMaxHP = 100; //�ִ� ü��
    public float PlayerAttack = 20; //�ִ� ü��

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
            if (gameObject !=null)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void EndMinigame()
    {
        foreach (GameObject gameObject in Havecollider)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(true);
            }
        }
        Invoke("InvokeEndMinigame", 0.3f);
    }
    void InvokeEndMinigame()
    {
        playerInput.enabled = true;
    }
}

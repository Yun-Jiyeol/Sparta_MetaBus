using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlappyPlane : MonoBehaviour
{
    //1. UI ����
    //2. �÷��̾�(�����) �ʱ�ȭ �۾�(rigidbody�¿���)
    //3. ȭ��, ������ ��ȯ(�̵�)

    public GameObject BackGround;
    public GameObject Player;
    public GameObject ObstaclePosition;
    public GameObject Obstacle;

    public GameObject StartUI;
    public GameObject GameUI;
    public GameObject EndUI;
    public TextMeshProUGUI scoreText;
    int score = 0;

    MiniGameManager miniGameManager;
    public bool isStart;
    bool startSpawn = true;
    public bool isDead = false;
    float moveSpeed = 3f;
    float spawncool = 3f; //3�ʸ��� ��ֹ� ����

    private void Awake()
    {
        miniGameManager = FindObjectOfType<MiniGameManager>();
    }
    private void Start()
    {
        isStart = miniGameManager.isRestart;

        SetStartUI(); //UI�ʱ�ȭ
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        if (isStart) //���۵� ��
        {
            if (score >= 10)
            {
                miniGameManager.Success();
            }
            if (isDead) //�׾��ٸ�
            {
                SetEndUI();
                CancelInvoke("SpawnWall");

                if (Input.GetMouseButtonDown(0)) //Ŭ�� ��
                {
                    miniGameManager.RestartGame();
                }
                return;
            }

            SetGameUI(); //UI����

            MoveEntity(); //�� �̵�

            if (startSpawn)
            {
                startSpawn = false; //�ѹ��� ����
                InvokeRepeating("SpawnWall", 1f, spawncool);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //Ŭ�� ��
            {
                isStart = true;
            }
        }
    }
    void MoveEntity()
    {
        BackGround.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }
    void SpawnWall()
    {
        GameObject go = Instantiate(Obstacle, ObstaclePosition.transform);
        go.transform.SetParent(BackGround.transform);
    }
    public void GameOver()
    {
        isDead = true;
    }

    void SetStartUI()
    {
        StartUI.SetActive(true);
        GameUI.SetActive(false);
        EndUI.SetActive(false);
    }
    void SetGameUI()
    {
        StartUI.SetActive(false);
        GameUI.SetActive(true);
        EndUI.SetActive(false);
    }
    void SetEndUI()
    {
        StartUI.SetActive(false);
        GameUI.SetActive(false);
        EndUI.SetActive(true);
    }
    public void AddScore()
    {
        if (!isDead)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}

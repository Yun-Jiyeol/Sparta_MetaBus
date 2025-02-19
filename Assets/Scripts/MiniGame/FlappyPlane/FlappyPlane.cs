using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlappyPlane : MonoBehaviour
{
    //1. UI 조정
    //2. 플레이어(비행기) 초기화 작업(rigidbody온오프)
    //3. 화면, 함정의 소환(이동)

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
    float spawncool = 3f; //3초마다 장애물 스폰

    private void Awake()
    {
        miniGameManager = FindObjectOfType<MiniGameManager>();
    }
    private void Start()
    {
        isStart = miniGameManager.isRestart;

        SetStartUI(); //UI초기화
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        if (isStart) //시작될 시
        {
            if (score >= 10)
            {
                miniGameManager.Success();
            }
            if (isDead) //죽었다면
            {
                SetEndUI();
                CancelInvoke("SpawnWall");

                if (Input.GetMouseButtonDown(0)) //클릭 시
                {
                    miniGameManager.RestartGame();
                }
                return;
            }

            SetGameUI(); //UI변경

            MoveEntity(); //벽 이동

            if (startSpawn)
            {
                startSpawn = false; //한번만 실행
                InvokeRepeating("SpawnWall", 1f, spawncool);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //클릭 시
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

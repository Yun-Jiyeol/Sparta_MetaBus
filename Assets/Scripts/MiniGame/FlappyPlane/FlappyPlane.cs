using System.Collections;
using System.Collections.Generic;
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

    MiniGameManager miniGameManager;
    bool isStart;
    bool startSpawn = true;
    bool isDead = false;
    float moveSpeed = 3f;
    float backgroundmove = 64f;
    float spawncool = 3f; //3초마다 장애물 스폰

    private void Awake()
    {
        miniGameManager = FindObjectOfType<MiniGameManager>();
    }
    private void Start()
    {
        isStart = miniGameManager.isRestart;
    }
    private void Update()
    {
        if (isStart) //시작될 시
        {
            if (!isDead) //죽었다면
            {
                return;
            }
            MoveEntity(); //벽 이동

            if (startSpawn)
            {
                startSpawn = false; //한번만 실행
                InvokeRepeating("SpawnWall", 3f, spawncool);
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
        BackGround.transform.position -= new Vector3(moveSpeed, 0, 0);
    }
    void SpawnWall()
    {
        GameObject go = Instantiate(Obstacle);
        go.transform.SetParent(BackGround.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7) //레이어로 확인 백그라운드일 시
        {
            collision.transform.position += new Vector3(backgroundmove, 0, 0);
        }
        if(collision.gameObject.layer == 8) //장애물일 시
        {
            Destroy(collision.gameObject);
        }
    }
}

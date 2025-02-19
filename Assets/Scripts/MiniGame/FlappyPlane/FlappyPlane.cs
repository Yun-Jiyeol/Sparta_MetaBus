using System.Collections;
using System.Collections.Generic;
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
    }
    private void Update()
    {
        if (isStart) //���۵� ��
        {
            if (isDead) //�׾��ٸ�
            {
                CancelInvoke("SpawnWall");
                if (Input.GetMouseButtonDown(0)) //Ŭ�� ��
                {
                    miniGameManager.RestartGame();
                }
                return;
            }

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
}

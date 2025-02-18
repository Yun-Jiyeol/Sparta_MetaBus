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
    bool isStart;
    bool startSpawn = true;
    bool isDead = false;
    float moveSpeed = 3f;
    float backgroundmove = 64f;
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
            if (!isDead) //�׾��ٸ�
            {
                return;
            }
            MoveEntity(); //�� �̵�

            if (startSpawn)
            {
                startSpawn = false; //�ѹ��� ����
                InvokeRepeating("SpawnWall", 3f, spawncool);
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
        BackGround.transform.position -= new Vector3(moveSpeed, 0, 0);
    }
    void SpawnWall()
    {
        GameObject go = Instantiate(Obstacle);
        go.transform.SetParent(BackGround.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7) //���̾�� Ȯ�� ��׶����� ��
        {
            collision.transform.position += new Vector3(backgroundmove, 0, 0);
        }
        if(collision.gameObject.layer == 8) //��ֹ��� ��
        {
            Destroy(collision.gameObject);
        }
    }
}

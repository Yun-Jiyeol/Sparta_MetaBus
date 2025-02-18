using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameManager : MonoBehaviour
{
    public Transform spawntransform; //��ȯ ��ġ
    public GameObject ChangeScene; //���� ������ �� ȭ�� ������
    public GameObject Minigame; //�̴ϰ���
    public PlayerInput playerInput;
    public MissionController missionController;

    public bool isRestart = false;

    private void Awake()
    {
        spawntransform = GameObject.Find("Main Camera").transform;
        //spawntransform = Transform.Find("Main Camera");
        playerInput = FindObjectOfType<PlayerInput>();
        missionController = FindObjectOfType<MissionController>();
    }

    void Start()
    {
        transform.position = new Vector3(
            spawntransform.position.x, spawntransform.position.y,0);

        ChangeScene.SetActive(true);
        
        playerInput.enabled = false; //�̴ϰ��ӽ� �÷��̾� ����

        Invoke("SpawnMinigame", 1f); //ȭ���� ���� �� �̴ϰ��� ��ȯ
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerInput.enabled = true; //�÷��̾� �̵� ����
            Destroy(gameObject); //�̴ϰ��� ����
        }
    }
    public void Success()
    {
        missionController.IsSuccess();
    }

    void SpawnMinigame()
    {
        GameObject go = Instantiate(Minigame);
        go.transform.SetParent(transform);
    }

    public void RestartGame()
    {
        Transform ThisGame = transform.Find("FlappyPlane");
        if (ThisGame != null) { 
            Destroy(ThisGame);
        }
        isRestart = true;
        SpawnMinigame();
    }
}

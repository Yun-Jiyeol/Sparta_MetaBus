using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameManager : MonoBehaviour
{
    public Transform spawntransform; //��ȯ ��ġ
    public GameObject ChangeScene; //���� ������ �� ȭ�� ������
    public GameObject Minigame; //�̴ϰ���
    public MissionController missionController;


    public bool isRestart = false;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        spawntransform = GameObject.Find("Main Camera").transform;
        missionController = FindObjectOfType<MissionController>();
    }

    void Start()
    {
        transform.position = new Vector3(
            spawntransform.position.x, spawntransform.position.y,0);

        ChangeScene.SetActive(true);
        
        Invoke("SpawnMinigame", 1f); //ȭ���� ���� �� �̴ϰ��� ��ȯ
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.EndMinigame();
            Destroy(gameObject); //�̴ϰ��� ����
        }
    }
    public void Success()
    {
        missionController.IsSuccess();
    }

    void SpawnMinigame()
    {
        gameManager.StartMinigame();
        GameObject go = Instantiate(Minigame, this.transform);
        go.transform.SetParent(transform);
    }

    public void RestartGame()
    {
        GameObject ThisGame = GameObject.Find("FlappyPlane(Clone)");
        if (ThisGame != null) { 
            Destroy(ThisGame);
        }
        isRestart = true;
        SpawnMinigame();
    }
}

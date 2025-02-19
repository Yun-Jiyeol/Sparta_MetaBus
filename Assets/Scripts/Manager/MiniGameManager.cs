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

    bool isescape = false;
    public bool isRestart = false;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        spawntransform = GameObject.Find("Main Camera").transform;
        if (spawntransform == null)
        {
            Debug.Log("spawntransform�� �����ϴ�.");
        }
        missionController = FindObjectOfType<MissionController>();
        if (missionController == null)
        {
            Debug.Log("missionControllerr�� �����ϴ�.");
        }
    }

    void Start()
    {
        transform.position = new Vector3(
            spawntransform.position.x, spawntransform.position.y,0);

        gameManager.StartMinigame();
        Instantiate(ChangeScene, this.transform);

        Invoke("SpawnMinigame", 1f); //ȭ���� ���� �� �̴ϰ��� ��ȯ
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isescape)
        {
            isescape = true;
            Instantiate(ChangeScene, this.transform);
            Invoke("EscapeGame", 1f);
        }
    }

    void EscapeGame()
    {
        gameManager.EndMinigame();
        Destroy(gameObject); //�̴ϰ��� ����
    }
    public void Success()
    {
        missionController.IsSuccess();
    }

    void SpawnMinigame()
    {
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

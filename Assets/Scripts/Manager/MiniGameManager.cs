using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameManager : MonoBehaviour
{
    public Transform spawntransform; //소환 위치
    public GameObject ChangeScene; //씬을 변경할 때 화면 가리개
    public GameObject Minigame; //미니게임
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
            Debug.Log("spawntransform가 없습니다.");
        }
        missionController = FindObjectOfType<MissionController>();
        if (missionController == null)
        {
            Debug.Log("missionControllerr가 없습니다.");
        }
    }

    void Start()
    {
        transform.position = new Vector3(
            spawntransform.position.x, spawntransform.position.y,0);

        gameManager.StartMinigame();
        Instantiate(ChangeScene, this.transform);

        Invoke("SpawnMinigame", 1f); //화면을 가린 후 미니게임 소환
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
        Destroy(gameObject); //미니게임 삭제
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

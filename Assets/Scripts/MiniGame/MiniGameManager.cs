using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameManager : MonoBehaviour
{
    public Transform spawntransform; //소환 위치
    public GameObject ChangeScene; //씬을 변경할 때 화면 가리개
    public GameObject Minigame; //미니게임
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
        
        Invoke("SpawnMinigame", 1f); //화면을 가린 후 미니게임 소환
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.EndMinigame();
            Destroy(gameObject); //미니게임 삭제
        }
    }
    public void Success()
    {
        missionController.IsSuccess();
    }

    void SpawnMinigame()
    {
        gameManager.StartMinigame();
        GameObject go = Instantiate(Minigame);
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

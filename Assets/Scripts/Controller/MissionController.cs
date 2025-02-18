using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private bool istrigger = false;
    private bool isClear = false; //미니게임을 성공했는가

    public GameObject minigame; //실행시 진행될 미니게임

    public GameObject manual; //트리거가 발동될 때 플레이어에게 매뉴얼을 보인다

    [SerializeField] private List<GameObject> deleteifSuccess; //미니게임 성공시 삭제될 것

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            Instantiate(minigame);
        }
    }

    public void IsSuccess() //미니게임 성공시 불러온다
    {
        foreach (GameObject i in deleteifSuccess) //성공 시 삭제
        {
            Destroy(i);
        }
        isClear = true;
        istrigger = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && !isClear) //플레이어일 시
        {
            istrigger = true;
            manual.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !isClear) //플레이어일 시
        {
            istrigger = false;
            manual.SetActive(false);
        }
    }
}

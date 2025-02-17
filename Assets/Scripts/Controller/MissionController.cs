using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private bool istrigger = false;

    public GameObject minigame; //실행시 진행될 미니게임

    public GameObject manual; //트리거가 발동될 때 플레이어에게 매뉴얼을 보인다

    [SerializeField] private List<GameObject> deleteifSuccess; //미니게임 성공시 삭제될 것

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            Debug.Log("트리거 안에 있음: ");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6) //플레이어일 시
        {
            istrigger = true;
            manual.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //플레이어일 시
        {
            istrigger = false;
            manual.SetActive(false);
        }
    }
}

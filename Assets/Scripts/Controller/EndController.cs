using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    private bool istrigger = false;
    public GameObject manual;
    public GameObject player;
    public GameObject EndScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            //게임 앤딩 만들기
            GameObject go = Instantiate(EndScene, player.transform);
            go.transform.SetParent(player.transform);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //플레이어일 시
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

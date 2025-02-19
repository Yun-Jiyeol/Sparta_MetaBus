using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StairController : MonoBehaviour
{
    private bool istrigger = false;

    public GameObject SceneChanger;
    public GameObject manual;
    public GameObject OpenMap; //열릴 맵
    public GameObject CloseMap; //닫힐 맵
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            //화면가리게 온오프
            //1초후다음맵 생성과 이번맵 삭제
            Instantiate(SceneChanger,this.transform);
            Invoke("ChangeMap", 1f);
        }
    }

    void ChangeMap()
    {
        OpenMap.SetActive(true);
        Destroy(CloseMap);
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

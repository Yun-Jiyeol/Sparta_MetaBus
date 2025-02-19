using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool istrigger = false;
    private bool isOpen = false;

    public GameObject manual;
    public GameObject OpenTile; //열렸을 때
    public GameObject CloseTile; //닫혔을 때
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            if (isOpen) //열렸을 때에 누르면 닫힌다
            {
                CloseDoor();
                isOpen = false;
            }
            else
            {
                OpenDoor();
                isOpen=true;
            }
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

    void OpenDoor()
    {
        OpenTile.SetActive(true);
        CloseTile.SetActive(false);
    }
    void CloseDoor()
    {
        OpenTile.SetActive(false);
        CloseTile.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool istrigger = false;
    private bool isOpen = false;

    public GameObject manual;
    public GameObject OpenTile; //������ ��
    public GameObject CloseTile; //������ ��
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            if (isOpen) //������ ���� ������ ������
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
        if (collision.gameObject.layer == 6) //�÷��̾��� ��
        {
            istrigger = true;
            manual.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //�÷��̾��� ��
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

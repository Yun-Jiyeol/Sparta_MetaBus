using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseNPC : MonoBehaviour
{
    public bool isPlayerNear = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //플레이어일 시
        {
            isPlayerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //플레이어일 시
        {
            isPlayerNear = false;
        }
    }
}

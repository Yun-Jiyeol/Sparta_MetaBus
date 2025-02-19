using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    float backgroundmove = 64f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd : " + collision.name);

        if (collision.CompareTag("BackGround")) //레이어로 확인 백그라운드일 시
        {
            collision.transform.position += new Vector3(backgroundmove, 0, 0);
        }
        if (collision.CompareTag("Obstacle")) //장애물일 시
        {
            Destroy(collision.gameObject);
        }
    }
}

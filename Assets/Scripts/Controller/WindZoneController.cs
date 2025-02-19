using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneController : MonoBehaviour
{
    public float WindX = 0f;
    public float WindY = 0f;

    Vector3 windMove = new Vector3(0, 0,0);

    private void Start()
    {
        windMove = new Vector3(WindX, WindY,0);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //플레이어일 시
        {
            collision.transform.position += windMove;
        }
    }
}

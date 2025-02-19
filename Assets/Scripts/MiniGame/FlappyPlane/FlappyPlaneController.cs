using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlappyPlaneController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;

    public FlappyPlane flappyPlane;

    bool isFlap = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (flappyPlane.isStart)
        {
            _rigidbody.isKinematic = false;

            if (Input.GetMouseButtonDown(0)) //클릭 시
            {
                isFlap = true;
            }
        }
        else
        {
            _rigidbody.isKinematic = true;
        }
    }
    private void FixedUpdate()
    {
        if (flappyPlane.isDead) return;

        Vector3 velocity = _rigidbody.velocity;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)//함정 레이어
        {
            animator.SetBool("IsDead", true);
            flappyPlane.GameOver();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) //레이어로 확인 백그라운드일 시
        {
            flappyPlane.AddScore();
        }
    }
}

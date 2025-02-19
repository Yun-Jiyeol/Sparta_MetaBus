using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected AnimationHandler animationHandler;

    [Range(1f, 20f)][SerializeField] private float speed = 5;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected void Movement(Vector2 direction)
    {
        direction = direction * Speed;
        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    private void Rotate()
    {
        if(movementDirection.x == 0)
        {
            return;
        }

        bool isLeft = (movementDirection.x < 0);

        characterRenderer.flipX = isLeft;
    }
}

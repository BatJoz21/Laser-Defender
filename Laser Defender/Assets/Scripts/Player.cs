using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Attribute n Value")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;

    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Vector2 delta;
    private Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move(rawInput);
    }

    //Movement
    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    private void Move(Vector2 val)
    {
        delta = val * moveSpeed* Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    //Firing
    private void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.IsFiring = value.isPressed;
        }
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}

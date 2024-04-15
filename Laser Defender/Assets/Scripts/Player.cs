using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Attribute n Value")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    private Vector2 rawInput;
    private Vector3 delta;

    void Update()
    {
        PlayerMovement(rawInput);
    }

    //Movement
    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    private void PlayerMovement(Vector2 val)
    {
        delta = val;
        rb.velocity = new Vector3(delta.x * moveSpeed * Time.deltaTime, delta.y * moveSpeed * Time.deltaTime, delta.z * moveSpeed * Time.deltaTime);
    }
}

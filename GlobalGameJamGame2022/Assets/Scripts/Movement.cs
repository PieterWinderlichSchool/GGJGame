using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;
    private Vector2 movementDirection;
    [SerializeField] private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontalMovement, verticalMovement);

        //rigidBody.AddForce(movementDirection.normalized * movementSpeed * Time.deltaTime, ForceMode2D.Force);
        rigidBody.velocity = movementDirection.normalized * movementSpeed;
    }
}

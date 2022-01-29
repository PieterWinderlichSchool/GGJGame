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

        PlayerRotation();
    }

    void PlayerRotation()
	{

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}

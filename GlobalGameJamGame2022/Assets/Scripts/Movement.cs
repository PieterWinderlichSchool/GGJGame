using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;
    private Vector2 movementDirection;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform objectToRotate;
    [SerializeField] private GameObject Sword;
    [SerializeField] private CombatRangedScript gunScript;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private List<Image> hearthImages = new List<Image>();


	void FixedUpdate()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll >= 0.1f)
		{
            Sword.SetActive(false);
            gunScript.enabled = true;
            //Enable Gun
        }
        else if(scroll <= -0.1f)
		{
            Sword.SetActive(true);
            gunScript.enabled = false;
            //Enable sword
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        if(horizontalMovement < 0)
		{
            spriteRenderer.flipX = false;
		}
        else if(horizontalMovement > 0)
		{
            spriteRenderer.flipX = true;
        }

        movementDirection = new Vector2(horizontalMovement, verticalMovement);

        //rigidBody.AddForce(movementDirection.normalized * movementSpeed * Time.deltaTime, ForceMode2D.Force);
        rigidBody.velocity = movementDirection.normalized * movementSpeed;

        PlayerRotation();

        if(Input.GetKeyDown(KeyCode.R))
		{
            SetHearts();
		}
    }

    void PlayerRotation()
	{

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        objectToRotate.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void SetHearts()
	{
        float _maxHealth = maxHealth;
        _maxHealth -= 0.5f;
        for (int i = 0; i < hearthImages.Count; i++)
		{
            if(currentHealth <= _maxHealth)
			{
                hearthImages[i].color = Color.black;
			}
            else if(currentHealth >= _maxHealth)
			{
                hearthImages[i].color = Color.white;
            }
            _maxHealth -= 0.5f;
		}
	}
}

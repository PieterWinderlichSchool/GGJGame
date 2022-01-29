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
	[SerializeField] private List<Transform> objectToRotate = new List<Transform>();
	[SerializeField] private GameObject Sword;
	[SerializeField] private CombatRangedScript gunScript;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Animator animator;
	[SerializeField] private float currentHealth;
	[SerializeField] private float maxHealth;
	[SerializeField] private List<Image> hearthImages = new List<Image>();
	[SerializeField] private Transform shooterDrone;

	public static Movement Player;
	private void Awake()
	{
		Player = this;
	}

	private void Update()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		if (scroll >= 0.1f)
		{
			Sword.SetActive(false);
			gunScript.enabled = true;
			//Enable Gun
		}
		else if (scroll <= -0.1f)
		{
			Sword.SetActive(true);
			gunScript.enabled = false;
			//Enable sword
		}
	}

	void FixedUpdate()
	{
		horizontalMovement = Input.GetAxisRaw("Horizontal");
		verticalMovement = Input.GetAxisRaw("Vertical");

		if(horizontalMovement != 0 || verticalMovement != 0)
		{
			animator.SetBool("isWalking", true);
		}
		else if(horizontalMovement == 0 && verticalMovement == 0)
		{
			animator.SetBool("isWalking", false);
		}

		if (horizontalMovement < 0)
		{
			spriteRenderer.flipX = false;
		}
		else if (horizontalMovement > 0)
		{
			spriteRenderer.flipX = true;
		}

		movementDirection = new Vector2(horizontalMovement, verticalMovement);

		rigidBody.velocity = movementDirection.normalized * movementSpeed;

		PlayerRotation();

		shooterDrone.position = Vector3.Slerp(shooterDrone.position, objectToRotate[1].position, Time.deltaTime * 3);
	}

	void PlayerRotation()
	{

		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		for (int i = 0; i < objectToRotate.Count; i++)
		{
			objectToRotate[i].rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		}
	}

	public void SetHearts()
	{
		float _maxHealth = maxHealth;
		_maxHealth -= 0.5f;
		for (int i = 0; i < hearthImages.Count; i++)
		{
			if (currentHealth <= _maxHealth)
			{
				hearthImages[i].color = Color.black;
			}
			else if (currentHealth >= _maxHealth)
			{
				hearthImages[i].color = Color.white;
			}
			_maxHealth -= 0.5f;
		}
	}
	public void RemoveHealth(float damageTaken)
	{
		currentHealth -= damageTaken;
		SetHearts();
	}
	public void AddHealth(float damageTaken)
	{
		currentHealth += damageTaken;
		SetHearts();
	}
}

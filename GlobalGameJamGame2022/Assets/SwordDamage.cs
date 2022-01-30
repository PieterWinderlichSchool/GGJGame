using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("EnemyHurtbox"))
		{
			Destroy(collision.gameObject.transform.parent.gameObject);
		}
	}
}

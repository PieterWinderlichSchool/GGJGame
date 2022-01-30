using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("PlayerCollider"))
		{
			StartCoroutine(DealDamage());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("PlayerCollider"))
		{
			StopCoroutine(DealDamage());
		}
	}
	private IEnumerator DealDamage()
	{
		while(true)
		{
			Movement.Player.RemoveHealth(0.5f);
			yield return new WaitForSeconds(1);
		}
	}
}

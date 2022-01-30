using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			StartCoroutine(DealDamage());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			StopCoroutine(DealDamage());
		}
	}
	private IEnumerator DealDamage()
	{
		Movement.Player.RemoveHealth(0.5f);
		yield return new WaitForSeconds(1);
	}
}

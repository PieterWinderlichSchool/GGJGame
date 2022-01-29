using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
	[SerializeField] private Coins coins;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Coins"))
		{
			coins.changeCoins(1);
			collision.gameObject.SetActive(false);
		}
	}
}

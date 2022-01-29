using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRangedScript : MonoBehaviour
{

	public float Damage;

	public float ProjectileSpeedInterval;

	[SerializeField] private float shootDelay = 1f;

	public GameObject projectileToFire;

	[SerializeField] private List<BulletBehaviour> bullets;
	[SerializeField] private Transform rotationObject;
	[SerializeField] private bool canShoot = true;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && canShoot)
		{
			StartCoroutine(FireProjectile());
		}
	}

	public IEnumerator FireProjectile()
	{
		canShoot = false;
		for (int i = 0; i < bullets.Count; i++)
		{
			if (!bullets[i].gameObject.activeInHierarchy)
			{
				bullets[i].gameObject.SetActive(true);
				bullets[i].transform.position = transform.position;
				bullets[i].transform.eulerAngles = rotationObject.eulerAngles;
				//StartCoroutine(bullets[i].MoveProjectile(ProjectileSpeedInterval));
				break;
			}
		}
		yield return new WaitForSeconds(shootDelay);
		canShoot = true;
		StopCoroutine(FireProjectile());
	}
}

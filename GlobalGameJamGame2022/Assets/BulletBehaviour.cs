using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

	public float bulletSpeed;

	private void OnEnable()
	{
		Invoke("DisableBullet", 10f);
	}

	private void FixedUpdate()
	{
		transform.position += transform.up * Time.deltaTime * bulletSpeed;
	}

	public IEnumerator MoveProjectile(float waitTime)
	{
		Invoke("DisableBullet", 10f);
		while (true)
		{
			transform.position += transform.up * Time.deltaTime * bulletSpeed;
			//if (transform.position.x > 100f||transform.position.x < -100f)
			//{
			//    StopCoroutine(MoveProjectile(waitTime));
			//    //Destroy(this.gameObject);
			//    gameObject.SetActive(false);
			//    yield break;
			//}
			yield return new WaitForSeconds(waitTime);
		}


	}

	public void DisableBullet()
	{
		StopCoroutine(MoveProjectile(0));
		gameObject.SetActive(false);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformMelee : MonoBehaviour
{
    [SerializeField] private Animator swordAnimator;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			swordAnimator.SetBool("canAttack", true);
		}
	}

	public void DisableAttack()
	{
		swordAnimator.SetBool("canAttack", false);
	}
}

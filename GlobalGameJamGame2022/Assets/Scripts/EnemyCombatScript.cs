using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatScript : MonoBehaviour
{

    public float FireSpeed;

    public List<GameObject> projectileList;

    public GameObject player;
	// Start is called before the first frame update

	private void Start()
	{
        player = Movement.Player.gameObject;
	}
	public IEnumerator ShootProjectile()
    {
        
        int index = 0;
       
        while (true)
        {
            if (index >= projectileList.Count)
            {
                index = 0;
            }

            projectileList[index].SetActive(true);
            EnemyProjectileBehaviour enemyBullet = projectileList[index].GetComponent<EnemyProjectileBehaviour>();
            enemyBullet.StartCoroutine(enemyBullet.MoveProjectile(player));
          
            index++;
            yield return new WaitForSeconds(FireSpeed); 
        }
        
    }
    
}

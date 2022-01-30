using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatScript : MonoBehaviour
{

    public float FireSpeed;

    public List<EnemyProjectileBehaviour> projectileList;

    public GameObject player;

    public Coroutine routine;
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

            projectileList[index].gameObject.SetActive(true);
            //EnemyProjectileBehaviour enemyBullet = projectileList[index].GetComponent<EnemyProjectileBehaviour>();
            projectileList[index].thisRoutine = projectileList[index].StartCoroutine(projectileList[index].MoveProjectile(player));

            index++;
            yield return new WaitForSeconds(FireSpeed);
        }

    }

}
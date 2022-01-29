using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float bulletSpeed;


    
    public IEnumerator MoveProjectile(float waitTime)
    {
        while(true)
        {
            transform.position += new Vector3(bulletSpeed,0,0);
            if (transform.position.x > 100f||transform.position.x < -100f)
            {
                StopCoroutine(MoveProjectile(waitTime));
                Destroy(this.gameObject);
                yield break;
            }
            yield return new WaitForSeconds(waitTime);
        }
        
       
    }
       
}

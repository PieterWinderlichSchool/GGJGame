using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShopTrigger : MonoBehaviour
{
    public Animator warningAnimator;
    public Animator shopAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopAnimator.SetBool("isClosed", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopAnimator.SetBool("isClosed", true);
            warningAnimator.SetBool("isClosed", true);
        }
    }

    public void OpenWarning()
    {
        warningAnimator.SetBool("isClosed", false);
    }
}

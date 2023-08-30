using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBoss : MonoBehaviour
{
    public GameObject redHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sphere") || collision.collider.CompareTag("BouncedBullet"))
        {
            hitActive();
            Debug.Log("Hit");
            Destroy(gameObject); // Destroy the Blue enemy

            // Make sure you have a reference to the PlayerUltimate script
            PlayerUltimate.CollectPower(50); // Add power points to the player's ultimate ability
            Invoke("hitDisable()", 0f);
            PlayerPause.kills+= 1;
        }

    }
    private void hitActive()
    {
        redHit.SetActive(true);
    }
    private void hitDisable()
    {
        Debug.Log("HitDis");
        redHit.SetActive(false);
    }
}

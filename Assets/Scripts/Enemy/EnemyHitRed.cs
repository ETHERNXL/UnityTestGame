using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitRed : MonoBehaviour
{
    public GameObject redHit;

    private void Start()
    {
        redHit.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sphere"))
        {
            hitActive();
            Debug.Log("Hit");
            Destroy(gameObject); // Destroy the Blue enemy
            Debug.Log("Kill");

            // Make sure to have a reference to the PlayerUltimate script
            PlayerUltimate.CollectPower(15); // Add power points to the player's ultimate ability
            Invoke("hitDisable()", 0f);
            PlayerPause.kills += 1;
        }
    }
    private void hitActive()
    {
        redHit.SetActive(true);
    }
    private void hitDisable()
    {
        redHit.SetActive(false);
    }
}

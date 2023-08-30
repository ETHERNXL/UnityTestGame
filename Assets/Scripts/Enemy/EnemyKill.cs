using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public GameObject bulletPrefab;

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // Set any other bullet properties here

        // Invoke bullet collision handling
        CollisionManager.instance.HandleBulletCollision(bullet.GetComponent<Collider>());
    }
}

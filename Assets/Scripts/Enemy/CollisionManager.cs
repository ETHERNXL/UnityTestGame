using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager instance;

    public delegate void BulletCollisionHandler(Collider bulletCollider);
    public event BulletCollisionHandler OnBulletCollision;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleBulletCollision(Collider bulletCollider)
    {
        if (OnBulletCollision != null)
        {
            OnBulletCollision(bulletCollider);
        }
    }
}

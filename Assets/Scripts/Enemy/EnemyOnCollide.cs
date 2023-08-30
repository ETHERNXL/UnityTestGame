using UnityEngine;

public class EnemyOnCollide : MonoBehaviour
{

    private void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == "Red(Clone)" || collision.gameObject.name == "Blue(Clone)") )
        {

        }
        else if (collision.gameObject.name == "projectilePrefab(Clone)" || collision.gameObject.name == "projectilePrefab")
        {
            Debug.Log("Special event happened!");
        }
        else
        {
            Debug.Log("Bullet HIT SMTH");
            Destroy(gameObject);
        }
    }
}

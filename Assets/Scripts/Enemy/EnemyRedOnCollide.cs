using UnityEngine;

public class EnemyRedOnCollide : MonoBehaviour
{

    private void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Red Collision" + collision.collider);
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Red HIT Player");
            Destroy(gameObject);
            PlayerHealthDisplay.health -= 15;
        }
        else if((collision.gameObject.name == "Blue") || (collision.gameObject.name == "Red"))
        {
            Debug.Log("Red HIT SMT");
        }
        else if((collision.gameObject.name == "SkyBox") || (collision.gameObject.name == "Box"))
        {

        }
        else if((collision.gameObject.name == "Pillar") || (collision.gameObject.name == "Wall") || (collision.gameObject.name == "Center") || (collision.gameObject.name == "Floor"))
        {
            Debug.Log("Red HIT Arena");
            Destroy(gameObject, 6f);
        }
    }
}

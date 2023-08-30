using UnityEngine;

public class Oncollide : MonoBehaviour
{
    public float maxHealth = 100;
    float adjustedChance = 0;
    float randomValue = 0;
    float currentHealth = 1;
    public GameObject Sphere;
    private Rigidbody sphereRigidbody; // Reference to the Rigidbody component of the Sphere
    private GameObject nearestEnemy; // Reference to the nearest enemy GameObject
    public float detectionRadius = 10f; // Radius to search for enemies with "Red" or "Blue" tag
    public float launchForce = 10f; // Force to launch the sphere towards the enemy

    private void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>(); // Get the Rigidbody component of this GameObject
    }

    void Update()
    {
        // Update currentHealth based on your game logic
        //currentHealth = PlayerHealthDisplay.health;
        float normalizedHealth = currentHealth / maxHealth;
        adjustedChance = normalizedHealth;
        randomValue = Random.value;

        FindNearestEnemyWithTag();
    }

    void FindNearestEnemyWithTag()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Red"); // Find all GameObjects with "Red" tag
        GameObject[] blueEnemies = GameObject.FindGameObjectsWithTag("Blue"); // Find all GameObjects with "Blue" tag

        GameObject[] allEnemies = new GameObject[enemies.Length + blueEnemies.Length];
        enemies.CopyTo(allEnemies, 0);
        blueEnemies.CopyTo(allEnemies, enemies.Length);

        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < nearestDistance && distanceToEnemy <= detectionRadius)
            {
                nearestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                Debug.Log(nearestEnemy + "Enemy");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Adjusted Chance: " + adjustedChance);
        Debug.Log("Random Value: " + randomValue);
        Debug.Log("Who it hit" + collision.gameObject.name);

        if (nearestEnemy != null && collision.gameObject == nearestEnemy && randomValue >= adjustedChance)
        {
 
            // Launch the Sphere towards the position of the nearest enemy
            if (sphereRigidbody != null)
            {
                Debug.Log("Normal event happened!");
                Sphere.gameObject.tag = "BouncedBullet";
                Debug.Log("BouncedBullet" + Sphere.gameObject.tag);
                Vector3 launchDirection = nearestEnemy.transform.position - transform.position;
                sphereRigidbody.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
                setFlag();
            }
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
    public void setFlag()
    {
        OnCollideHeal.healFlag = true;
        Debug.Log("Heal Flag Method" + OnCollideHeal.healFlag);
    }
}

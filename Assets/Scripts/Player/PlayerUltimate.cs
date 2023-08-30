using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    public static int maxPower = 100;
    public int ultimatePowerThreshold = 100;
    public float ultimateRadius = 5f; // Radius to consider for ultimate ability
    public LayerMask destroyableObjectsLayer;

    public static int currentPower = 50;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && currentPower >= ultimatePowerThreshold)
        {
            UseUltimateAbility();
        }
    }

    public void UseUltimateAbility()
    {
        if(currentPower >= ultimatePowerThreshold) { 
        Collider[] destroyableObjects = Physics.OverlapSphere(transform.position, ultimateRadius, destroyableObjectsLayer);

        foreach (Collider objCollider in destroyableObjects)
        {
            Debug.Log("Detected object: " + objCollider.gameObject.name);

                if (objCollider.CompareTag("Red") && objCollider.gameObject.layer == LayerMask.NameToLayer("whatIsRed"))
                {
                    Destroy(objCollider.gameObject);
                }
                else if (objCollider.CompareTag("Blue") && objCollider.gameObject.layer == LayerMask.NameToLayer("whatIsBlue"))
                {
                    Destroy(objCollider.gameObject);
                }
                else if (objCollider.CompareTag("Missile")&& objCollider.gameObject.layer == LayerMask.NameToLayer("whatIsBlue"))
                {
                    Destroy(objCollider.gameObject);
                }
        }

        currentPower = 0; // Reset power after using ultimate ability
        }
    }

    public static void CollectPower(int amount)
    {
        Debug.Log("Power");
        if (currentPower + amount >= 100)
        {
            currentPower = 100;
            Debug.Log("Full power");
        }
        else
        {
            currentPower += amount;
            Debug.Log(amount);
        }
    }
    
    public static void MinusPower(int amount)
    {
        Debug.Log("Minus Power");
        if(currentPower - amount <= 0)
        {
            currentPower = 0;
            Debug.Log("No Power");
        }
        else
        {
            currentPower -= amount;
            Debug.Log(amount);
        }
    }

    public static int GetPower()
    {
        return currentPower;
    }
}

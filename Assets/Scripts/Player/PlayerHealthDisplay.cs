using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{

    public static int health = 100; // Start at 100
    public int maxHealth = 100;
    public int power = 50;
    public int maxPower = 100;

    public Text healthText;
    public Text PowerText;

    private bool isIncreasingHealth = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(IncreaseHealthOverTime());
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = health + " HP";
        PowerText.text = PlayerUltimate.GetPower() + "/100";
    }

    IEnumerator IncreaseHealthOverTime()
    {
        Debug.Log("Increasing health coroutine started.");

        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            if (health < maxHealth)
            {
                Debug.Log("Increasing health by 1.");
                health += 1;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour {

    #region Singleton

    public static EnemyEyes instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    public GameObject player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    private GameObject Player;
    private Vector3 offset;
    private GameObject Booststatus;
    private bool BoostTrigger;
   
    

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        offset = transform.position - Player.transform.position;
        Booststatus = GameObject.Find("Status");
        BoostTrigger = false;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Player.transform.position + offset;

        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;
        ParticleSystem.MainModule mainModule = GetComponent<ParticleSystem>().main;

        if (BoostTrigger == false)
        {
            mainModule.simulationSpeed = 50;
            if(Input.GetMouseButton(0))
            {
                mainModule.simulationSpeed = 10;
            }
        }
        if (BoostTrigger == true)
        {
            mainModule.simulationSpeed = 500;
        }

    }
}

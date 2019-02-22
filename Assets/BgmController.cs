using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour {

    private GameObject Booststatus;
    private bool SlowTrigger;
    private AudioSource audiosouce;
    private GameObject Player;

    // Use this for initialization
    void Start ()
    {
        Booststatus = GameObject.Find("Status");
        Player = GameObject.Find("Player");
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        SlowTrigger = Booststatus.GetComponent<BoostStatus>().Slow;
        audiosouce = GetComponent<AudioSource>();
       

        if (SlowTrigger == true)
        {
            audiosouce.volume = 0.5f;
        }
        else if(SlowTrigger == false)
        {
            audiosouce.volume = 1.0f;
        }

        if (Player.GetComponent<PlayerController>().isEnd == true)
        {
            audiosouce.volume = 0.3f;
        }

	}
}

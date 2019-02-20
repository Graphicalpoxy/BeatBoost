using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour {

    private GameObject Booststatus;
    private bool BoostTrigger;
    private float pitch;

    // Use this for initialization
    void Start ()
    {
        Booststatus = GameObject.Find("BoostStatus");
        pitch = GetComponent<AudioSource>().pitch;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (Input.GetMouseButton(0))
        {
            GetComponent<AudioSource>().pitch = 0.5f;
        }
        else
        {
            GetComponent<AudioSource>().pitch = 1.0f;
        }

	}
}

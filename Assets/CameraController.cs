using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    private GameObject Player;
    private Vector3 offset;
    private GameObject Booststatus;
    private bool BoostTrigger;
    private float time;
    private Vector3 dif = new Vector3(0,0,0);

    private bool SlowTrigger;
    private float Slowtime;
    private bool MinBoost;
    private float Minboosttime;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        offset = transform.position - Player.transform.position;
        Booststatus = GameObject.Find("Status");
        BoostTrigger = false;
        Minboosttime = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {

        dif.x = Input.GetAxis("Horizontal") * -2;
        dif.y = Input.GetAxis("Vertical") * -2;

        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;
        SlowTrigger = Booststatus.GetComponent<BoostStatus>().SlowTrigger;
        MinBoost = Booststatus.GetComponent<BoostStatus>().MinBoost;
        Slowtime = Booststatus.GetComponent<BoostStatus>().SlowTime;

        if (BoostTrigger == false)
        {
            transform.position = Player.transform.position + offset + dif;
            GetComponent<RippleEffect>().enabled = false;
            time = 0;

            if (SlowTrigger == true)
            {
                if (Input.GetMouseButtonDown(0))
                CameraShakeManager.Instance.Play("Camera Shakes/Ambient");
            }
            
            if (Slowtime < 0)
            {
                CameraShakeManager.Instance.Play("Camera Shakes/Impact");
            }
            if (Input.GetMouseButtonUp(0))
            {
                CameraShakeManager.Instance.Play("Camera Shakes/Impact");
            }



        }
        else if (BoostTrigger == true)
        {
            transform.position = Player.transform.position + offset;
            CameraShakeManager.Instance.Play("Camera Shakes/Default");

            time += Time.deltaTime;
            if (time < 5.0f)
            {
                GetComponent<RippleEffect>().enabled = true;
            }
            else if (time >= 5.0f)
            {
                GetComponent<RippleEffect>().enabled = false;
            }
        }
    }
}

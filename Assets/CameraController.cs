using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;    // namespace の指定をわすれずに！

public class CameraController : MonoBehaviour {

    private GameObject Player;
    private Vector3 offset;
    private GameObject Booststatus;
    private bool BoostTrigger;
    private float time;

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
        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;

        if (BoostTrigger == false)
        {
            transform.position = Player.transform.position + offset;
            GetComponent<RippleEffect>().enabled = false;
            time = 0;
        }
        else if (BoostTrigger == true)
        {
            transform.DOShakePosition(2f);

            time += Time.deltaTime;
            if (time < 2.0f)
            {
                GetComponent<RippleEffect>().enabled = true;
            }
            else if (time >= 2.0f)
            {
                GetComponent<RippleEffect>().enabled = false;
            }
        }
    }
}

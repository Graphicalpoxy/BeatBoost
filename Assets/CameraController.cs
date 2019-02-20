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
    private Vector3 dif = new Vector3(0,0,0);

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

        dif.x = Input.GetAxis("Horizontal") * -2;
        dif.y = Input.GetAxis("Vertical") * -2;

        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;

        if (BoostTrigger == false)
        {
            transform.position = Player.transform.position + offset + dif;
           

            GetComponent<RippleEffect>().enabled = false;
            time = 0;
        }
        else if (BoostTrigger == true)
        {
            transform.position = Player.transform.position + offset;
            transform.DOShakeRotation(0f);

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

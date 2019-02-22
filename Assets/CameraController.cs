using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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

    public bool isPlayButtonDown;
    private bool isEndCamera;


    private GameObject Menu;
   

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        offset = transform.position - Player.transform.position;
        Booststatus = GameObject.Find("Status");
        BoostTrigger = false;
        Minboosttime = 0;
        isPlayButtonDown = false;

        
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        isEndCamera = Player.GetComponent<PlayerController>().isEnd;

        if (isPlayButtonDown == true && isEndCamera == false)
        {
            transform.DORotate(new Vector3(5, 0, 0), 1);
            
           
        }
        if (isEndCamera == true)
        {
            transform.DORotate(new Vector3(5, 180, 0), 1);
            transform.DOMove(new Vector3(0, 5, -15), 1);
        }


        if (isEndCamera == false)
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

    public void GetMyPlayButtonDown()
    {
        this.isPlayButtonDown = true;
        Debug.Log("スタートボタン");

    }

    public void GetMyPlayButtonUP()
    {
        this.isPlayButtonDown = false;
    }

}

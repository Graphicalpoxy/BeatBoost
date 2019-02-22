using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public bool ResumuTrigger;
    public bool TitleTrigger;
    public GameObject ResumuButton;
    public GameObject TitleButton;
    public GameObject PauseMenu;
    private GameObject MainCamera;
    private GameObject Player;


    // Use this for initialization
    void Start ()
    {
        MainCamera = GameObject.Find("MainCamera");
        Player = GameObject.Find("Player");
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(MainCamera.GetComponent<CameraController>().isPauseButtonDown == true)
        {
            PauseMenu.SetActive(true);
            
        }

        if (ResumuTrigger == true)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            ResumuTrigger = false;
        }
        if (TitleTrigger == true)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            TitleTrigger = false;
            Player.GetComponent<PlayerController>().isEnd = true;
        }

    }

    public void ResumuButtonDown()
    {
        ResumuTrigger = true;
    }
    public void ResumuButtonUp()
    {
        ResumuTrigger = false;
    }
    public void TitleButtomDown()
    {
        TitleTrigger = true;
    }
    public void TitleButtomUp()
    {
        TitleTrigger = false;
    }


}

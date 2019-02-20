using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageController : MonoBehaviour {
    private GameObject BoostStatus;

    private float Slowtime;
    
    public Image Meter;
    public Image BoostMeter;
    private float Gemstuck;


    // Use this for initialization
    void Start ()
    {
        BoostStatus = GameObject.Find("Status");
       
        Meter = GameObject.Find("Slowgage").GetComponent<Image>();
        BoostMeter = GameObject.Find("Boostgage").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Slowtime = BoostStatus.GetComponent<BoostStatus>().SlowTime;
        Gemstuck = BoostStatus.GetComponent<BoostStatus>().Gemstuck;

        Meter.fillAmount = Slowtime / 2;
        BoostMeter.fillAmount = Gemstuck / 4;

        Debug.Log("UI"+ BoostMeter.fillAmount);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostStatus : MonoBehaviour {

    public int Gemstuck = 0;
    public bool Boost;
    private float BoostTime;

    public bool SlowTrigger;
    public bool Slow;
    public float SlowTime;

    public bool MinBoost;

    // Use this for initialization
    void Start ()
    {
        Boost = false;
        SlowTrigger = true;
        Slow = false;
        SlowTime = 2.0f;

        MinBoost = false;
    }
	
	// Update is called once per frame
	void Update ()
    {


       if (SlowTime == 2.0f)
        {
            SlowTrigger = true;
        }


       if(SlowTrigger == true)
        {
            if(Input.GetMouseButton(0))
            {
                SlowTime -= Time.deltaTime;

                if (SlowTime >= 0)
                {
                    Slow = true;
                }
                else if (SlowTime < 0)
                {
                    Slow = false;
                    SlowTrigger = false;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Slow = false;
                SlowTrigger = false;
            }
        }
       else if (SlowTrigger == false)
        {
            MinBoost = true;

            SlowTime += Time.deltaTime;
            if (SlowTime >= 2.0f)
            {
                SlowTime = 2.0f;
                MinBoost = false;
            }
        }



	if(Boost == true)
        {
            BoostTime += Time.deltaTime;
            if(BoostTime > 5.0f)
            {
                Boost = false;
                BoostTime = 0;
                Gemstuck = 0;
            }
        }
	}

    public void stuck()
    {
        Debug.Log(Gemstuck);
        if (Gemstuck < 4)
        {
            Gemstuck++;
        }

        if (Gemstuck == 4)
        {
            Boost = true;
 
        }
    }
}

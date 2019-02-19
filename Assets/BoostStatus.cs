using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostStatus : MonoBehaviour {

    int i = 0;
    public bool Boost;
    private float BoostTime;

    // Use this for initialization
    void Start ()
    {
        Boost = false;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(Boost);

	if(Boost == true)
        {
            BoostTime += Time.deltaTime;
            if(BoostTime > 5.0f)
            {
                Boost = false;
                BoostTime = 0;
                i = 0;
            }
        }
	}

    public void stuck()
    {
        Debug.Log(i);
        if (i < 4)
        {
            i++;
        }

        if (i == 4)
        {
            Boost = true;
 
        }
    }
}

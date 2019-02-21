using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ExCamera : MonoBehaviour {

  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CameraShakeManager.Instance.Play("Camera Shakes/Impact");
        }
    }
}

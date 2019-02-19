using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float Fspeed = 10.0f;
    public float speed ;
    private GameObject Status;
    public bool isEnd;
    private bool BoostTrigger; 

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Status = GameObject.Find("Status");
        isEnd = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        rb.AddForce(x, y, 0);

        BoostTrigger = Status.GetComponent<BoostStatus>().Boost;
        if (BoostTrigger == false)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else if (BoostTrigger == true)
        {
            GetComponent<BoxCollider>().enabled = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            Status.GetComponent<BoostStatus>().stuck();
            Destroy(other);
        }

        if (other.gameObject.tag == "Barrier")
        {
            isEnd = true;
            Debug.Log("おわり");
        }

        
    }

}

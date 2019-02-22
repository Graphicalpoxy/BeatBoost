using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float Fspeed = 10.0f;
    public float speed ;
    private GameObject Booststatus;
    public bool isEnd;
    private bool BoostTrigger;
    public GameObject InverseRange;
    private float time;
    public Vector3 defaultScale;

    private bool Slow;

    private Vector3 newAngle = new Vector3(0,0,0);


    private GameObject MainCamera;
    private bool isPlayButtom;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Booststatus = GameObject.Find("Status");
        isEnd = true;
        InverseRange.SetActive(false);
        time = 0;
        defaultScale = InverseRange.transform.localScale;

        MainCamera = GameObject.Find("MainCamera");       
        isPlayButtom = false; 

    }
	
	// Update is called once per frame
	void Update ()
    {
        isPlayButtom = MainCamera.GetComponent<CameraController>().isPlayButtonDown;
        if (isPlayButtom == true)
        {
            isEnd = false;
        }
        if (isEnd == false)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(x * speed, y * speed, 0);

            newAngle.x = -30 * y;
            newAngle.z = -30 * x;
            transform.localEulerAngles = newAngle;

            BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;

            Slow = Booststatus.GetComponent<BoostStatus>().Slow;

            if (BoostTrigger == false)
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            else if (BoostTrigger == true)
            {
                GetComponent<BoxCollider>().enabled = false;
            }

            if (Slow == true)
            {
                InverseRange.SetActive(true);

                InverseRange.transform.localScale += new Vector3(2, 1, 1);
            }
            if (Slow == false)
            {
                InverseRange.SetActive(false);
                InverseRange.transform.localScale = defaultScale;

            }
        }
        else if(isEnd == true)
        {
            transform.position = new Vector3(0, 0, 0);
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            Booststatus.GetComponent<BoostStatus>().stuck();
            Destroy(other);
            GetComponentInChildren<ParticleSystem>().Play();
        }

        if (other.gameObject.tag == "Barrier")
        {
            isEnd = true;
            Debug.Log("おわり");
        }

        
    }

}

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

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Booststatus = GameObject.Find("Status");
        isEnd = false;
        InverseRange.SetActive(false);
        time = 0;
        defaultScale = InverseRange.transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        rb.AddForce(x, y, 0);

        newAngle.x = -3 * y;
        newAngle.z = -3 * x;
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
            
                InverseRange.transform.localScale += new Vector3(2  ,1, 1);
        }
        if (Slow == false)
        {
            InverseRange.SetActive(false);
            InverseRange.transform.localScale = defaultScale;
            
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

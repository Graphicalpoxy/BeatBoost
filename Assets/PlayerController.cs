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
    public GameObject InverseRange;
    private float time;
    public Vector3 defaultScale;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Status = GameObject.Find("Status");
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

        BoostTrigger = Status.GetComponent<BoostStatus>().Boost;
        if (BoostTrigger == false)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else if (BoostTrigger == true)
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        if (Input.GetMouseButton(0))
        {
            InverseRange.SetActive(true);
            time += Time.deltaTime;

           if(time < 2.0f)
            {
                InverseRange.transform.localScale += new Vector3(2  ,1, 1);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            InverseRange.SetActive(false);
            InverseRange.transform.localScale = defaultScale;
            time = 0;
        }




    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            Status.GetComponent<BoostStatus>().stuck();
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

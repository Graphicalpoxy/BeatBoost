using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour {

    public GameObject barrierPrefab;
    public GameObject Player;
    private float time;
    private GameObject Booststatus;
    
    private bool BoostTrigger;
    private bool GenEnd;



    // Use this for initialization
    void Start ()
    {
        time = 0;
        Booststatus = GameObject.Find("Status");
       
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;
        GenEnd = Player.GetComponent<PlayerController>().isEnd;

        if (GenEnd == false)
        {
            if (BoostTrigger == false)
            {
                time += Time.deltaTime;
                if (time > 3)
                {
                    time = 0;
                    int offsetX = Random.Range(-50, 50);
                    int offsetY = Random.Range(-50, 50);


                    GameObject barrier = Instantiate(barrierPrefab) as GameObject;
                    barrier.transform.position = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + 500);
                }
            }
            if (BoostTrigger == true)
            {
                time += Time.deltaTime;
                if (time > 0.3f)
                {
                    time = 0;
                    int offsetX = Random.Range(-50, 50);
                    int offsetY = Random.Range(-50, 50);


                    GameObject barrier = Instantiate(barrierPrefab) as GameObject;
                    barrier.transform.position = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + 500);
                }
            }
        }

	}
    


}

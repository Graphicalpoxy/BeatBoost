using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierController2 : MonoBehaviour
{

    public float rotspeed;
    public float speedZ;
    private float time;
    private float actime;
    public Material normal;
    public Material slow;
    public Material Boost;
    private bool ScoreTrigger;
    private GameObject Booststatus;
    private bool BoostTrigger;
    private bool Slow;
    private bool MinBoost;

    private float Slowtime;

    private GameObject Player;
    private bool BarEnd;

    // Use this for initialization
    void Start()
    {
        this.transform.Rotate(new Vector3(0, 0, 0));
        time = 0;
        actime = 0;
        RenderSettings.skybox = normal;
        ScoreTrigger = false;
        Booststatus = GameObject.Find("Status");

        Player = GameObject.Find("Player");

        Slowtime = 2.0f;



    }

    // Update is called once per frame
    void Update()
    {
        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;
        BarEnd = Player.GetComponent<PlayerController>().isEnd;

        Slow = Booststatus.GetComponent<BoostStatus>().Slow;
        MinBoost = Booststatus.GetComponent<BoostStatus>().MinBoost;

        if (BarEnd == false)
        {

            if (BoostTrigger == false)
            {

                if (Slow == true)
                {

                    this.transform.Rotate(new Vector3(0, 0, rotspeed / 5));
                    this.transform.Translate(0, 0, speedZ / 5);
                    RenderSettings.skybox = slow;

                }
                else if (MinBoost == false)
                {
                if (Slow == false)
                    {

                        this.transform.Rotate(new Vector3(0, 0, rotspeed));
                        this.transform.Translate(0, 0, speedZ);
                        RenderSettings.skybox = normal;

                    }
                }
                else if (MinBoost == true)
                {
                    this.transform.Rotate(new Vector3(0, 0, rotspeed));
                    this.transform.Translate(0, 0, speedZ * 2);
                    RenderSettings.skybox = normal;
                }
            }

            if (BoostTrigger == true)
            {
                this.transform.Rotate(new Vector3(0, 0, rotspeed));
                this.transform.Translate(0, 0, speedZ * 30);
                RenderSettings.skybox = Boost;
            }


            if (this.transform.position.z < 0)
            {

                if (ScoreTrigger == false)
                {
                    GameObject.Find("Canvas").GetComponent<TextController>().ScoreUP();
                    ScoreTrigger = true;
                }
            }


            if (this.transform.position.z < -50)
            {
                Destroy(this.gameObject);
                ScoreTrigger = false;
            }

        }
            if (BarEnd == true)
            {
                Destroy(this.gameObject);
            }
        
    }

}

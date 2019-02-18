using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierController : MonoBehaviour {

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

    private GameObject Player;
    private bool BarEnd;

    // Use this for initialization
    void Start ()
    {
        this.transform.Rotate ( new Vector3(0, 0, 0));
        time = 0;
        actime = 0;
        RenderSettings.skybox = normal;
        ScoreTrigger = false;
        Booststatus = GameObject.Find("Status");

        Player = GameObject.Find("Player");
        


    }

    // Update is called once per frame
    void Update()
    {
        BoostTrigger = Booststatus.GetComponent<BoostStatus>().Boost;
        BarEnd = Player.GetComponent<PlayerController>().isEnd;

        if (BarEnd == false)
        {

            if (BoostTrigger == false)
            {

                if (Input.GetMouseButton(0))
                {
                    time += Time.deltaTime;
                    Debug.Log("osu ");
                    if (time > 0 && time < 2)

                    {
                        this.transform.Rotate(new Vector3(0, 0, rotspeed / 5));
                        this.transform.Translate(0, 0, speedZ / 5);
                        RenderSettings.skybox = slow;
                        Debug.Log("スロー");
                    }

                    else if (time > 2.0f)
                    {
                        actime += Time.deltaTime;
                        if (actime < 1.0f)
                        {
                            this.transform.Rotate(new Vector3(0, 0, rotspeed));
                            this.transform.Translate(0, 0, speedZ * 2);
                            RenderSettings.skybox = normal;
                            Debug.Log("ミニブースト");
                        }

                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    actime += Time.deltaTime;
                    if (actime < 1.0f)
                    {
                        this.transform.Rotate(new Vector3(0, 0, rotspeed));
                        this.transform.Translate(0, 0, speedZ * 2);
                        RenderSettings.skybox = normal;
                        Debug.Log("ミニブースト");
                    }
                }

                else
                {

                    this.transform.Rotate(new Vector3(0, 0, rotspeed));
                    this.transform.Translate(0, 0, speedZ);
                    RenderSettings.skybox = normal;
                    Debug.Log("ノーマル");
                    time = 0;
                    actime = 0;
                }

            }

            if (BoostTrigger == true)
            {
                this.transform.Rotate(new Vector3(0, 0, rotspeed));
                this.transform.Translate(0, 0, speedZ * 10);
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
            }
        }

        if (BarEnd == true)
        {
            Destroy(this.gameObject);
        }
    }










    public void Normal()
    {
        this.transform.Rotate(new Vector3(0, 0, rotspeed));
        this.transform.Translate(0, 0, speedZ);
        RenderSettings.skybox = normal;
        Debug.Log("ノーマル");

    }

    public void Slow()
    {
        this.transform.Rotate(new Vector3(0, 0, rotspeed / 5));
        this.transform.Translate(0, 0, speedZ / 5);
        RenderSettings.skybox = slow;
        Debug.Log("スロー");
    }

    public void minBoost()
    {
        this.transform.Rotate(new Vector3(0, 0, rotspeed));
        this.transform.Translate(0, 0, speedZ * 2);
        RenderSettings.skybox = normal;
        Debug.Log("身にブースと");
    }
}

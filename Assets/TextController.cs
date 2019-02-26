using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public int score;
    private GameObject scoretext;
    private GameObject gameovertext;
    private GameObject player;
   

    // Use this for initialization
    void Start () {

        score = 0;
        scoretext = GameObject.Find("ScoreText");

        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //scoretext.GetComponent<Text>().text = score.ToString();

        bool isEnd = player.GetComponent<PlayerController>().isEnd;
        if(isEnd == true)
        {
            score = 0;
             
        }

	}

    public void ScoreUP()
    {
        
        score ++;
        scoretext.GetComponent<Text>().text = score.ToString();
        scoretext.GetComponent<Animator>().SetTrigger("ScoreUP");
      
    }
    public void ScoreUP2()
    {

        score = score + 5;
        scoretext.GetComponent<Text>().text = score.ToString();
        scoretext.GetComponent<Animator>().SetTrigger("ScoreUP");

    }


}

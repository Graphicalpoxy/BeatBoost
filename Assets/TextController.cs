using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    int score;
    private GameObject scoretext;
    private GameObject gameovertext;
    private GameObject player;
   

    // Use this for initialization
    void Start () {

        score = 0;
        scoretext = GameObject.Find("ScoreText");
        gameovertext = GameObject.Find("GameOverText");
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //scoretext.GetComponent<Text>().text = score.ToString();

        bool gameover = player.GetComponent<PlayerController>().isEnd;
        if(gameover == true)
        {
            gameovertext.GetComponent<Text>().text = ("GameOver");
        }

	}

    public void ScoreUP()
    {
        
        score ++;
        scoretext.GetComponent<Text>().text = score.ToString();
        scoretext.GetComponent<Animator>().SetTrigger("ScoreUP");
      
    }
}

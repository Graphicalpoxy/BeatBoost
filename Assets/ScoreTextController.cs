﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {

    int score;

    // Use this for initialization
    void Start ()
    {
        score = 0;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = score.ToString();
    }

    public void ScoreUP()
    {

        score = score + 1;

    }
}

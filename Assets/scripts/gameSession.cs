using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//using UnityEngine.SceneManagement;

public class gameSession : MonoBehaviour {

    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool AutoPlay;
    //TextMeshProUGUI score;

    private void Awake()
    {
       /* 
        Scene sc = SceneManager.GetActiveScene();
        Debug.Log("active scene: " + sc.name);
       */

        int gameStatusCount = FindObjectsOfType<gameSession>().Length;

        //Debug.Log(gameStatusCount);

        if(gameStatusCount>1)
        {
            //Debug.Log("inside if");
            //Debug.Log("destroyed: " + gameObject.name);
            Destroy(gameObject);
        }
        else
        {
           // Debug.Log("inside else");
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //score = FindObjectOfType<TextMeshProUGUI>();
        //score.text = currentScore.ToString();

        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        Time.timeScale = gameSpeed;
	}

    public void totalScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
        //score.text = currentScore.ToString();
    }

    public void reset()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return AutoPlay;
    }
}

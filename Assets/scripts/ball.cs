using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    [SerializeField] paddle paddle1;
    [SerializeField] float xPushVelocity = 2f;
    [SerializeField] float yPushVelocity = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomVelocity = 0.1f;

   // [SerializeField] GameObject leftWallobj;

    bool isLaunched = false;

    Vector2 paddleToBallVector;
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
   // paddle myPaddle;

    // Use this for initialization
    void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();

        //myPaddle = FindObjectOfType<paddle>();
        //paddleToBallVector = transform.position - myPaddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isLaunched==false)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isLaunched = true;
            myRigidbody2D.velocity = new Vector2(xPushVelocity, yPushVelocity);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        //Vector2 paddlePos = new Vector2(myPaddle.transform.position.x, myPaddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = new Vector2(UnityEngine.Random.Range(0f, randomVelocity), UnityEngine.Random.Range(0f, randomVelocity));
        if(isLaunched==true /*&& gameObject!=leftWallobj*/)
        {
            //GetComponent<AudioSource>().Play();

            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocity;
        }
    }
    
}

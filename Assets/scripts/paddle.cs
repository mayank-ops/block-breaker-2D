using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {

    [SerializeField] float screenWidthinUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    // Use this for initialization

    gameSession session;
    ball myball;
	void Start ()
    {
        session = FindObjectOfType<gameSession>();
        myball = FindObjectOfType<ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log((Input.mousePosition.x/Screen.width) * screenWidthinUnits);
        //float currentMousepos = ((Input.mousePosition.x / Screen.width) * screenWidthinUnits);//mouse position in unity world units
        //Vector2 paddlePos = new Vector2(currentMousepos, transform.position.y);

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX);
        transform.position = paddlePos;
	}

    private float GetXpos()
    {
        if(session.IsAutoPlayEnabled())
        {
            return myball.transform.position.x;
        }
        else
        {
            return ((Input.mousePosition.x / Screen.width) * screenWidthinUnits);
        }
    }
}

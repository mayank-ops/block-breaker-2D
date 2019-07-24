using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoScript : MonoBehaviour {

    [SerializeField] GameObject sparkle;
    [SerializeField] AudioClip myaudioclip;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("mouse(0) pressed");
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            Debug.Log("mouse(0) released");                   
        }
        else if(Input.GetButtonDown("Submit"))
        {
            Debug.Log("space presssed");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.Log("down arrow pressed");
            GameObject obj = Instantiate(sparkle, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(myaudioclip, Camera.main.transform.position);
            Destroy(obj, 1f);
        }
    }
}

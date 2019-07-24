using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparkleVFX;
   // [SerializeField] int maxHits = 0;
    [SerializeField] Sprite[] hitSprites;

    int currHits = 0;
    int maxHits = 0;
    level mylevel;
    gameSession session;
    SpriteRenderer mySprite;

    private void Start()
    {
        mylevel = FindObjectOfType<level>();
        session = FindObjectOfType<gameSession>();
        mySprite = GetComponent<SpriteRenderer>();
        maxHits = hitSprites.Length + 1;

        if(tag=="Breakable")
        {
            mylevel.countOfBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            currHits++;
            if(currHits>=maxHits)
            {
                DestroyBlock();
            }
            else
            {
                //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                mySprite.sprite = hitSprites[currHits - 1];
            }
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        mylevel.countOfRemainingBlocks();
        session.totalScore();
        TriggerSparkleVFX();
        Destroy(gameObject);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(sparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}

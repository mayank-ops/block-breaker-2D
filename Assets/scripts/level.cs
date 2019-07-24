using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {

    [SerializeField] int blockCount;
    screenLoader nextScene;

    private void Start()
    {
        nextScene = FindObjectOfType<screenLoader>();
    }

    public void countOfBlocks()
    {
        blockCount++;
    }

    public void countOfRemainingBlocks()
    {
        blockCount--;
        if(blockCount<=0)
        {
            nextScene.LoadNextScene();
        }
    }
}

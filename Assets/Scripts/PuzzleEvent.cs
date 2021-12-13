using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEvent : MonoBehaviour
{
    void Start()
    {
        GameController.puzzleCount = 0;
    }

    void Update()
    {
        if (GameController.stage == 1)
        {
            GameController.puzzleMaxCount = 2;
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Box" && Col.gameObject.GetComponent<Box>().destination == false)
        {
            GameController.puzzleCount++;
            Col.GetComponent<Box>().setDestination(transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private GameObject canvas;
    
    void Awake()
    {
        canvas = GameObject.FindWithTag("HUD");
    }
    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            canvas.GetComponent<UIController>().Caught();
        }
    }
}

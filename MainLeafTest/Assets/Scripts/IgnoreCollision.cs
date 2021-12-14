using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public string Tag;

    void OnCollisionEnter(Collision Col)
    {
        if(gameObject.tag == "Wall")
        {
            if (Col.gameObject.tag == Tag)
            {
                Physics.IgnoreCollision(Col.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            }
        }
    }

    void OnCollisionStay(Collision Col)
    {
        if(gameObject.name.Contains("Box"))
        {
            if (Col.gameObject.tag == "Wall")
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GameObject.FindWithTag("Player").GetComponent<Collider>(), false);
            }
        }
    }


    void OnCollisionExit(Collision Col)
    {
        if (gameObject.name.Contains("Box"))
        {
            if (Col.gameObject.tag == "Wall")
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GameObject.FindWithTag("Player").GetComponent<Collider>());
            }
        }
    }
}
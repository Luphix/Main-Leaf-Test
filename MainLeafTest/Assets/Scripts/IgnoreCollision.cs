using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public string Tag;

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == Tag)
        {
            Physics.IgnoreCollision(Col.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject box;
    public GameObject Player;
    private Vector3 boxOffset;
    private Rigidbody rb;
    public bool destination = false;
    private Vector3 destinPos;
    private Vector3 pullDirection;
    private float pullSpeed;

    void Start()
    {
        boxOffset = box.transform.position;
        rb = box.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    
    void FixedUpdate()
    {
        if(destination == false)
        {
            if (Player)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                box.transform.position = new Vector3(Player.transform.position.x + boxOffset.x, box.transform.position.y, Player.transform.position.z + boxOffset.z);
                if (!Input.GetMouseButton(0))
                {
                    Player = null;
                }
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }

  

    public void setDestination(Vector3 vet)
    {
        destinPos = vet;
        destination = true;
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        box.transform.position = vet;
    }

    public void setOffset()
    {

        boxOffset = box.transform.position - Player.transform.position;
        rb.Sleep();
    }
}

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

    void Awake()
    {
        if(GameController.concludedStages >= 1)
        {
            destination = true;
            if (box.name == "Box1")
            {
                box.transform.position = new Vector3(-0.184f, -1.55f, 4.71f);
            }
            else if(box.name == "Box2")
            {
                box.transform.position = new Vector3(-0.184f, -0.098f, 4.71f);
            }
        }
    }

    void Start()
    {
        boxOffset = box.transform.position;
        rb = box.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    
    void FixedUpdate()
    {
        

        if (destination == false)
        {
            if (Player)
            {
                if (box.transform.position.x >= -0.19f && box.transform.position.z >= -2.37f && !(box.transform.position.x > -0.11f && box.transform.position.z > 0.92f))
                {
                    box.transform.position = new Vector3(Player.transform.position.x + boxOffset.x, box.transform.position.y, Player.transform.position.z + boxOffset.z);

                }
                else
                {

                    if (box.transform.position.x < -0.19f)
                    {
                        box.transform.position = new Vector3(-0.18f, box.transform.position.y, box.transform.position.z);
                    }
                    if (box.transform.position.z < -2.37f)
                    {
                        box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, -2.36f);
                    }
                    if(box.transform.position.x > -0.11f && box.transform.position.x <= -0.08f && box.transform.position.z > 0.92f)
                    {
                        box.transform.position = new Vector3(-0.12f, box.transform.position.y, box.transform.position.z);
                    }
                    if (box.transform.position.x > -0.08f && box.transform.position.z > 0.92f)
                    {
                        box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, 0.9f);
                    }
                }
               

                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                
                if (!Input.GetMouseButton(0))
                {
                    Player = null;
                }
            }
            else
            {
                if (box.transform.position.x < -0.19f)
                {
                    box.transform.position = new Vector3(-0.18f, box.transform.position.y, box.transform.position.z);
                }
                if (box.transform.position.z < -2.37f)
                {
                    box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, -2.36f);
                }
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

  

    public void setDestination(Vector3 vet)
    {
        destinPos = vet;
        destination = true;
        rb.velocity = Vector3.zero;
        rb.Sleep();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        box.transform.position = vet;
    }

    public void setOffset()
    {

        boxOffset = box.transform.position - Player.transform.position;
        rb.Sleep();
    }
}

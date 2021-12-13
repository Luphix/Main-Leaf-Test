using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] private Vector3 camOffset;

    [Range(0.01f, 1.0f)] public float smoothFactor;

    private bool rotateAroundPlayer = true;

    private float rotationSpeed = 5f;

    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        playerTransform.gameObject.GetComponent<PlayerController>().cam = gameObject.transform;
    }
    void Start()
    {
        camOffset = transform.position - playerTransform.position;
        
    }


    void LateUpdate()
    {
        if (playerTransform)
        {
            if (!GameController.gameIsPaused)
            {
                if (GameController.stage == 1)
                {
                    if (rotateAroundPlayer)
                    {
                        Quaternion camTurn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

                        camOffset = camTurn * camOffset;
                    }

                    Vector3 novaPos = playerTransform.position + camOffset;

                    transform.position = Vector3.Slerp(transform.position, novaPos, smoothFactor);

                    transform.LookAt(new Vector3(playerTransform.position.x, playerTransform.position.y + 1, playerTransform.position.z));
                }
                else if (GameController.stage == 2)
                {
                    if (GameController.stagePart == 1)
                    {
                        if (playerTransform.position.z >= 0)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(-4, 5, (playerTransform.position.z / 3)), 0.1f);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(-4, 5, (playerTransform.position.z / 4)), 0.1f);
                        }
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(45, 90 , 0), 0.1f);

                    }
                    else if (GameController.stagePart == 2)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 70, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(-5, 4, 6 + (playerTransform.position.z - 4) / 2), 0.1f);
                    }

                }

            }
        }
       
        
    }
}

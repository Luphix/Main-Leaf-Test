using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Vector3 camOffset;
    [Range(0.01f, 1.0f)] public float smoothFactor;
    [SerializeField] private float rotationSpeed = 5f;

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
        if(playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerTransform = player.transform;
            playerTransform.gameObject.GetComponent<PlayerController>().cam = gameObject.transform;
        }
        if (playerTransform)
        {
            if (!GameController.gameIsPaused)
            {
                //Camera orbital controlada pelo mouse:

                if (GameController.stage == 1)  
                {
                    Quaternion camTurnX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
                    camOffset = camTurnX * camOffset;
                    Vector3 novaPos = playerTransform.position + camOffset;
                    transform.position = Vector3.Slerp(transform.position, novaPos, smoothFactor);
                    transform.LookAt(new Vector3(playerTransform.position.x, playerTransform.position.y + 1, playerTransform.position.z));
                }

                //Camera fixa conforme o progresso na fase:

                else if (GameController.stage == 2)
                {
                    if (GameController.stagePart == 1) //Parte 1: posição Z da Camera varia de -1 a 1 enquanto a posição Z do jogador varia de -3 a 4
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
                    else if (GameController.stagePart == 2) //Parte 2: posição Z da Camera varia de 6 a 14 enquanto a posição Z do jogador varia de 4 a 20
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 70, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(-6, 4, 6 + (playerTransform.position.z - 4) / 2), 0.1f);
                    }
                    else if (GameController.stagePart == 3) //Parte 3: posição Z da Camera varia de 22 a 30 enquanto a posição Z do jogador varia de 20 a 36
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 70, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(-6, 4, 22 + (playerTransform.position.z - 20) / 2), 0.1f);
                    }
                    else if (GameController.stagePart == 4) //Parte 4: posição Z da Camera varia de 38 a 46 enquanto a posição Z do jogador varia de 36 a 52
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 70, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(-6, 4, 38 + (playerTransform.position.z - 36) / 2), 0.1f);
                    }
                    else if (GameController.stagePart == 5) //Parte 5: posição Z da Camera varia de 54 a 62 enquanto a posição Z do jogador varia de 52 a 68
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 70, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(-6, 4, 54 + (playerTransform.position.z - 52) / 2), 0.1f);
                    }
                    else if (GameController.stagePart == 6) //Parte 6: posição Z da Camera varia de 70 a 80 enquanto a posição Z do jogador varia de 68 a 84
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(45, 90, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(-4, 5, 70 + (playerTransform.position.z - 68) / 1.6f), 0.1f);
                    }
                    else if (GameController.stagePart == 7) //Parte 7: posição Z da Camera varia de 70 a 80 enquanto a posição Z do jogador varia de 68 a 84
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(30, 90, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 5, 70 + (playerTransform.position.z - 68) / 1.6f), 0.1f);
                    }
                    else if (GameController.stagePart == 8) //Parte 8: posição Z da Camera varia de 70 a 80 enquanto a posição Z do jogador varia de 68 a 84
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(45, 90, 0), 0.1f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(18, 5, 70 + (playerTransform.position.z - 68) / 1.6f), 0.1f);
                    }

                }

            }
        }
    }
}

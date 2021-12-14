using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Text actionTx;
    private Animator anim;
    private Rigidbody rb;
    private float moveSpeed = 1;
    public Transform cam;
    private float jumpVar = -9f;
    private GameObject interact;

    void Awake()
    {
        if(GameObject.FindWithTag("Player") && (GameObject.FindWithTag("Player") != gameObject))
        {
            Destroy(gameObject);
        }
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        actionTx.text = "";
        cam = GameObject.FindWithTag("MainCamera").transform;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        if (anim.GetFloat("Jump") > -9f)
        {
            anim.SetFloat("Jump", jumpVar);
            jumpVar -= 0.3f * 60f * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        anim.SetFloat("WalkingSpeed", GameController.playerMoveSpeed);

        

        if (!GameController.playerBusy)
        {
            #region Botão de Ação

            if (Input.GetMouseButton(0))
            {
                if (interact && interact.tag == "Box")
                {
                    if (actionTx.text == "Grab")
                    {
                        if (interact.GetComponent<Box>().Player == null)
                        {
                            anim.SetFloat("Forward", 0f);
                            interact.GetComponent<Box>().Player = gameObject;
                            interact.GetComponent<Box>().setOffset();

                            //Códigos para mover as caixas somente para frente e para trás (empurrar e puxar) e não para as diagonais ou para os lados:

                            if ((transform.position.z - interact.transform.position.z) < -0.7f)
                            {
                                if (Mathf.Abs(transform.position.z - interact.transform.position.z) < 0.96f)
                                {
                                    interact.transform.parent.position += new Vector3(0, 0, 0.03f);    //Código para ajustar o offset da caixa para não empurrar o jogador para trás
                                    interact.GetComponent<Box>().setOffset();
                                }

                                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
                            }
                            else if (transform.position.z - interact.transform.position.z > 0.7f)
                            {
                                if (Mathf.Abs(transform.position.z - interact.transform.position.z) < 0.96f)
                                {
                                    interact.transform.parent.position += new Vector3(0, 0, -0.03f);
                                    interact.GetComponent<Box>().setOffset();
                                }
                               
                                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
                            }
                            else if (transform.position.x - interact.transform.position.x > 0.7f)
                            {
                                if (Mathf.Abs(transform.position.x - interact.transform.position.x) < 0.96f)
                                {
                                    interact.transform.parent.position += new Vector3(-0.03f, 0, 0);
                                    interact.GetComponent<Box>().setOffset();
                                }
                               
                                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                            }
                            else if (transform.position.x - interact.transform.position.x < -0.7f)
                            {
                                if (Mathf.Abs(transform.position.x - interact.transform.position.x) < 0.96f)
                                {
                                    interact.transform.parent.position += new Vector3(0.03f, 0, 0);
                                    interact.GetComponent<Box>().setOffset();
                                }
                              
                                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                            }
                        }
                    }
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                if (interact && interact.tag == "Box" && interact.GetComponent<Box>().Player == gameObject)
                {
                    interact.GetComponent<Box>().Player = null;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (interact && interact.tag == "Box")
                {
                    if (actionTx.text == "Climb")
                    {
                        if (anim.GetBool("OnGround"))
                        {
                            StartCoroutine("Climb");                          
                        }
                    }
                }
            }

            //Código para mover-se livremente após largar a caixa, não só para frente e para trás:

            if (((interact && interact.gameObject.tag == "Box" && interact.GetComponent<Box>().Player == null) || !interact))
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }

            #endregion


            #region Movimento


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (interact && interact.tag == "Box" && interact.GetComponent<Box>().Player == gameObject)
                {
                    anim.SetFloat("Forward", Mathf.Lerp(anim.GetFloat("Forward"), moveSpeed * 0.6f, GameController.playerMoveAcceleration * 0.1f));   //Aceleração suave ao iniciar o movimento   
                }
                else if (anim.GetBool("OnGround") && anim.GetFloat("Jump") < 0f)
                {
                    anim.SetFloat("Forward", Mathf.Lerp(anim.GetFloat("Forward"), moveSpeed, GameController.playerMoveAcceleration * 0.1f));   //Aceleração suave ao iniciar o movimento   
                }
                else
                {
                    transform.Translate(Vector3.forward * 0.05f);
                }

            }
            else
            {
                anim.SetFloat("Forward", Mathf.Lerp(anim.GetFloat("Forward"), 0, GameController.playerMoveAcceleration * 0.1f));   //Desaceleração suave ao parar o movimento                                                          
            }


            if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("OnGround"))
            {
                rb.velocity = Vector3.zero;
                anim.SetFloat("Forward", 0f);
                anim.SetBool("OnGround", false);
                rb.velocity += Vector3.up * 5f * GameController.playerJumpHeight;

                anim.SetFloat("Jump", 5f);
                jumpVar = 5f;
            }

            #endregion


            #region Controle de Direção


            if (Input.GetKey(KeyCode.D))
            {
                transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y + 90, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y - 90, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y + 180, 0);
                    }
                    else
                    {
                        transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y - 135, 0);
                    }

                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y + 135, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y + 180, 0);
                }
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y, 0);
                    }
                    else
                    {
                        transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y - 45, 0);
                    }

                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y + 45, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, cam.localRotation.eulerAngles.y, 0);
                }

            }


            #endregion
        }

        #region Ajuste de Parte da Fase

        if (GameController.stage == 2)
        {
            if(transform.position.z < 4)
            {
                GameController.stagePart = 1;
            }
            else if(transform.position.z >= 4 && transform.position.z < 20)
            {
                GameController.stagePart = 2;
            }
            else if (transform.position.z >= 20 && transform.position.z < 36)
            {
                GameController.stagePart = 3;
            }
            else if (transform.position.z >= 36 && transform.position.z < 52)
            {
                GameController.stagePart = 4;
            }
            else if (transform.position.z >= 52 && transform.position.z < 68)
            {
                GameController.stagePart = 5;
            }
            else if (transform.position.z >= 68 && transform.position.x < 3)
            {
                GameController.stagePart = 6;
            }
            else if (transform.position.z >= 68 && transform.position.x >= 3 && transform.position.x < 20)
            {
                GameController.stagePart = 7;
            }
            else if (transform.position.z >= 68 && transform.position.x >= 20)
            {
                GameController.stagePart = 8;
            }
        }

        #endregion

    }

    #region Co-rotina para Escalar Caixa

    IEnumerator Climb()
    {
        GameController.playerBusy = true;
        rb.useGravity = false;
        interact = null;
        actionTx.text = "";
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        anim.SetFloat("Forward", 0f);
        anim.SetBool("OnGround", false);
        anim.SetFloat("Jump", 5f);
        jumpVar = 5.5f;
        while(transform.position.y < 1.6f)
        {
            transform.position += Vector3.up * 0.1f * 60f * Time.deltaTime;
            transform.position += Vector3.forward * 0.05f * 60f * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (transform.position.z < 4.5f)
        {
            transform.position += Vector3.forward * 0.1f * 60f * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        rb.useGravity = true;
        while (!anim.GetBool("OnGround"))
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        GameController.playerBusy = false;
    }

    #endregion

    #region Funções de Contato

    void OnCollisionEnter(Collision Col)
    {
        if(Col.gameObject.tag == "Floor" && anim.GetBool("OnGround") == false)
        {
            anim.SetBool("OnGround", true);
        }

        if(Col.gameObject.tag == "Death")
        {
            Time.timeScale = 1.0f;
            GameController.gameIsPaused = false;
            GameController.resetScene();
            transform.position = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "End")
        {
            GameController.loadScene("Stage" + (GameController.stage + 1));
            if(GameController.stage == 3)
            {
                Destroy(GameObject.FindWithTag("MainCamera"));
                Destroy(GameObject.FindWithTag("HUD"));
                Destroy(gameObject);
            }
            transform.position = Vector3.zero;
        }

        if(Col.gameObject.tag == "Box")
        {
            interact = Col.gameObject;
            if(Col.gameObject.GetComponent<Box>().destination == false)
            {
                actionTx.text = "Grab";
            }
            else if(GameController.concludedStages >= 1)
            {
                actionTx.text = "Climb";
            }
        }

        if (Col.gameObject.tag == "Floor" && anim.GetBool("OnGround") == false)
        {
            anim.SetBool("OnGround", true);
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject == interact)
        {
            if(interact.GetComponent<Box>().Player == gameObject)
            {
                interact.GetComponent<Box>().Player = null;
            }
            interact = null;
            actionTx.text = "";
        }
    }

    #endregion


}

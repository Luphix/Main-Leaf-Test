using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int enemyType;
    
    private Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if(enemyType == 1)
        {
            transform.localPosition = new Vector3(-1.52f, 0, 1.52f);
        }
    }


    void FixedUpdate()
    {
        if(enemyType == 1)
        {
            anim.SetFloat("Forward", GameController.enemiesMoveSpeed * 0.5f);
            if((transform.localPosition.z >= 1.5f && transform.localPosition.x <= -1.5f) || ((transform.localPosition.x > -1.5f && transform.localPosition.x < 1.5f) && transform.localPosition.z >= 1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if((transform.localPosition.z <= -1.5f && transform.localPosition.x >= 1.5f) || ((transform.localPosition.x > -1.5f && transform.localPosition.x < 1.5f) && transform.localPosition.z <= -1.5f))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if ((transform.localPosition.z >= 1.5 && transform.localPosition.x >= 1.5f) || ((transform.localPosition.z > -1.5f && transform.localPosition.z < 1.5f) && transform.localPosition.x >= 1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if((transform.localPosition.z <= -1.5f && transform.localPosition.x <= -1.5f) || ((transform.localPosition.z > -1.5f && transform.localPosition.z < 1.5f) && transform.localPosition.x <= -1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
 
        }
    }


}

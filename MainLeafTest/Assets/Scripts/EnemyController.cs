using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int enemyType;
    private bool enemyStopped = false;
    private bool changeState = true;
    private Animator anim;

    void Awake()
    {
        StartCoroutine("change");
    }

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if(enemyType == 1)
        {
            transform.localPosition = new Vector3(-1.52f, 0, 1.52f);
        }
        else if(enemyType == 2)
        {
            transform.localPosition = new Vector3(-1.52f, 0, -2.7f);
        }
        else if (enemyType == 3)
        {
            transform.localPosition = new Vector3(-1.52f, 0, 2.7f);
        }
        else if (enemyType == 3)
        {
            transform.localPosition = new Vector3(-1.2f, 0, 1.2f);
        }

    }

    IEnumerator change()
    {
        while (changeState)
        {
            if (enemyStopped)
            {
                yield return new WaitForSeconds(GameController.enemiesStoppedDuration * 60f * Time.deltaTime);
            }
            else
            {
                yield return new WaitForSeconds(GameController.enemiesWalkingDuration * 60f * Time.deltaTime);
            }
            enemyStopped = !enemyStopped;
        }
    }

    void FixedUpdate()
    {
        if (!enemyStopped)
        {
            anim.SetFloat("Forward", Mathf.Lerp(anim.GetFloat("Forward"), GameController.enemiesMoveSpeed * 0.5f, 0.1f));
        }
        else
        {
            anim.SetFloat("Forward", Mathf.Lerp(anim.GetFloat("Forward"), 0, 0.1f));
        }

        EnemyRot();

    }

    void EnemyRot()
    {
        if (enemyType == 1)
        {
            if ((transform.localPosition.z >= 1.5f && transform.localPosition.x <= -1.5f) || ((transform.localPosition.x > -1.5f && transform.localPosition.x < 1.5f) && transform.localPosition.z >= 1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if ((transform.localPosition.z <= -1.5f && transform.localPosition.x >= 1.5f) || ((transform.localPosition.x > -1.5f && transform.localPosition.x < 1.5f) && transform.localPosition.z <= -1.5f))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if ((transform.localPosition.z >= 1.5 && transform.localPosition.x >= 1.5f) || ((transform.localPosition.z > -1.5f && transform.localPosition.z < 1.5f) && transform.localPosition.x >= 1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if ((transform.localPosition.z <= -1.5f && transform.localPosition.x <= -1.5f) || ((transform.localPosition.z > -1.5f && transform.localPosition.z < 1.5f) && transform.localPosition.x <= -1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if(enemyType == 2 || enemyType == 3)
        {
            if ((transform.localPosition.z >= 2.7f && transform.localPosition.x <= -1.5f) || ((transform.localPosition.x > -1.5f && transform.localPosition.x < 1.5f) && transform.localPosition.z >= 2.7f))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if ((transform.localPosition.z <= -2.7f && transform.localPosition.x >= 1.5f) || ((transform.localPosition.x > -1.5f && transform.localPosition.x < 1.5f) && transform.localPosition.z <= -2.7f))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if ((transform.localPosition.z >= 2.7f && transform.localPosition.x >= 1.5f) || ((transform.localPosition.z > -2.7f && transform.localPosition.z < 2.7f) && transform.localPosition.x >= 1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if ((transform.localPosition.z <= -2.7f && transform.localPosition.x <= -1.5f) || ((transform.localPosition.z > -2.7f && transform.localPosition.z < 2.7f) && transform.localPosition.x <= -1.5f))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        else if (enemyType == 4)
        {
            if ((transform.localPosition.z >= 1 && transform.localPosition.x <= -1) || ((transform.localPosition.x > -1 && transform.localPosition.x < 1) && transform.localPosition.z >= 1))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if ((transform.localPosition.z <= -1 && transform.localPosition.x >= 1) || ((transform.localPosition.x > -1 && transform.localPosition.x < 1) && transform.localPosition.z <= -1))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if ((transform.localPosition.z >= 1 && transform.localPosition.x >= 1) || ((transform.localPosition.z > -1 && transform.localPosition.z < 1) && transform.localPosition.x >= 1))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if ((transform.localPosition.z <= -1 && transform.localPosition.x <= -1) || ((transform.localPosition.z > -1 && transform.localPosition.z < 1) && transform.localPosition.x <= -1))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (enemyType == 5)
        {
            if ((transform.localPosition.z >= 4 && transform.localPosition.x <= -6) || ((transform.localPosition.x > -6 && transform.localPosition.x < 6) && transform.localPosition.z >= 4))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if ((transform.localPosition.z <= -4 && transform.localPosition.x >= 6) || ((transform.localPosition.x > -6 && transform.localPosition.x < 6) && transform.localPosition.z <= -4))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if ((transform.localPosition.z >= 4 && transform.localPosition.x >= 6) || ((transform.localPosition.z > -4 && transform.localPosition.z < 4) && transform.localPosition.x >= 6))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if ((transform.localPosition.z <= -4 && transform.localPosition.x <= -6) || ((transform.localPosition.z > -4 && transform.localPosition.z < 4) && transform.localPosition.x <= -6))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }


}

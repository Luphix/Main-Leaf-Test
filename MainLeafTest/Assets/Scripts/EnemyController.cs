using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int enemyStart;
    private bool enemyStopped = false;
    private bool changeState = true;
    private Animator anim;
    public float xMaxPos;
    public float zMaxPos;

    void Awake()
    {
        StartCoroutine("change");
    }

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if(enemyStart == 1)
        {
            transform.localPosition = new Vector3(-(xMaxPos + 0.02f), 0, zMaxPos + 0.02f);
        }
        else if(enemyStart == 2)
        {
            transform.localPosition = new Vector3(xMaxPos + 0.02f, 0, -(zMaxPos + 0.02f));
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

        if ((transform.localPosition.z >= zMaxPos && transform.localPosition.x <= -xMaxPos) || ((transform.localPosition.x > -xMaxPos && transform.localPosition.x < xMaxPos) && transform.localPosition.z >= zMaxPos))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if ((transform.localPosition.z <= -zMaxPos && transform.localPosition.x >= xMaxPos) || ((transform.localPosition.x > -xMaxPos && transform.localPosition.x < xMaxPos) && transform.localPosition.z <= -zMaxPos))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if ((transform.localPosition.z >= zMaxPos && transform.localPosition.x >= xMaxPos) || ((transform.localPosition.z > -zMaxPos && transform.localPosition.z < zMaxPos) && transform.localPosition.x >= xMaxPos))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if ((transform.localPosition.z <= -zMaxPos && transform.localPosition.x <= -xMaxPos) || ((transform.localPosition.z > -zMaxPos && transform.localPosition.z < zMaxPos) && transform.localPosition.x <= -xMaxPos))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }



}

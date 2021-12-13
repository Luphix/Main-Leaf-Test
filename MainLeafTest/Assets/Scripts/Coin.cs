using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject effect;

    void FixedUpdate()
    {
        transform.Rotate(0f, 1f, 0f);
    }

    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            GameController.coins += 1;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

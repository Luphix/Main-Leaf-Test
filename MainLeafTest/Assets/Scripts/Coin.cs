using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject effect;
    public int value;

    void FixedUpdate()
    {
        transform.Rotate(0f, 3f, 0f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", GameController.coinColorByValue[value - 1]);
    }

    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            GameController.coins += value;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

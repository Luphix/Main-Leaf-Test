using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    public ParticleSystem ps;

    void Update()
    {
        if(ps && !ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}

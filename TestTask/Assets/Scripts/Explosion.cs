using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private ParticleSystem explosion;
    
    private void Start()
    {
        explosion = (ParticleSystem)GetComponent(typeof(ParticleSystem));
    }

    private void Update()
    {
        
    }
}

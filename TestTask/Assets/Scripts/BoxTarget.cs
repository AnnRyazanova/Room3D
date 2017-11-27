using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTarget : MonoBehaviour
{
    void Start ()
    {
        
    }

    void Update()
    {
        
    }

    public void Destroy()
    {
        StartCoroutine(Die());
    }
    

    private IEnumerator Die()
    {
        this.transform.Rotate(-70, 0, 0);

        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.5f);

        Destroy(this.gameObject);
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTarget : MonoBehaviour
{

    private float angle = 23f;

    void Start ()
    {
        
    }

    void Update()
    {
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), angle * Time.deltaTime);
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

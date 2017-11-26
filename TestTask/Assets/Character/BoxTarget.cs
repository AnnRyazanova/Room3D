using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTarget : MonoBehaviour {
    
	void Start ()
    {
		
	}

    void Update()
    {

    }

    public void Destroy()
    {
        //Destroy(this.gameObject);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-70, 0, 0);
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    
}

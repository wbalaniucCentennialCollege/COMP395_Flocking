using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

    public int numberOfBoids = 50;
    public GameObject boid;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < numberOfBoids; i++)
        {
            Instantiate(boid, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
        }	
	}
}

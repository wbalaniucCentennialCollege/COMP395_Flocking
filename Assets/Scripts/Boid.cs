using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    // Public variables

    // Private variables
    private Rigidbody rb;
    private List<GameObject> neighbours;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.value, Random.value, Random.value);
        neighbours = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 alignmentVec = Vector3.zero;
        Vector3 cohesionVec = Vector3.zero;
        Vector3 seperationVec = Vector3.zero;

        foreach (GameObject o in neighbours)
        {
            if(o.gameObject != this.gameObject)
            {
                // Alignment
                alignmentVec += o.GetComponent<Rigidbody>().velocity;

                // Cohesion
                cohesionVec += o.transform.position;

                // Separation
                seperationVec += this.transform.position - o.transform.position;
            }
        }

        // Combine everything
        alignmentVec /= neighbours.Count;
        alignmentVec.Normalize();

        cohesionVec /= neighbours.Count;
        cohesionVec = new Vector3(cohesionVec.x - this.transform.position.x, cohesionVec.y - this.transform.position.y, cohesionVec.z - this.transform.position.z);
        cohesionVec.Normalize();

        seperationVec *= -1;
        seperationVec.Normalize();

        Vector3 v = rb.velocity; 
        v += alignmentVec + cohesionVec + seperationVec;
        v.Normalize();
        rb.velocity = v;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boid")
        {
            neighbours.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boid")
        {
            neighbours.Remove(other.gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class oncollisionactivategrav : MonoBehaviour {
    public Collider col;
    void Start()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
    }
    /*Droppin the FLop
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        { 
            other.attachedRigidbody.useGravity = true;
        }
    }
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            GetComponent<Rigidbody>().useGravity = true;
            //GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}

//old weird droppin floppies
/*
 * using UnityEngine;
using System.Collections;

public class oncollisionactivategrav : MonoBehaviour {
    public Collider col;
    void Start()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = true;

    }

    // Update is called once per frame
    void Update () {
	
	}
}
*/
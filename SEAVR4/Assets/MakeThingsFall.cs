using UnityEngine;
using System.Collections;

public class MakeThingsFall : MonoBehaviour
{
    public Collider col;
    void Start()
    {
        //col = GetComponent<Collider>();
        //col.isTrigger = true;
    }
    void OnColliderEnter(Collider other)
    {
        if(other.gameObject.tag != "Unmoveable")
        {
           // if (other.attachedRigidbody)
                other.attachedRigidbody.useGravity = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
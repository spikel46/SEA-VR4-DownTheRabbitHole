using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    bool inHand; 

    public Transform sphere;

    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("You are holding down the trigger222.");
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("You have activated TouchDown on trigger.");
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("You have activated TouchUp on trigger.");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("You are holding Press on the trigger.");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("You have activated PressDown on trigger.");
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("You have activated PressUp on trigger.");
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //!!!!!! reset ball position
            sphere.transform.position = Vector3.zero;
            sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    void OnTriggerStay (Collider col)
    {
        if (col.gameObject.tag != "Unmoveable" && col.gameObject.tag != "GameController" )
        {
            //Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay");
            if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger) && inHand == false)
            {
                //Debug.Log("You have collided with " + col.name + " while holding down Touch");
                col.attachedRigidbody.isKinematic = true;
                inHand = true;
                col.gameObject.transform.SetParent(gameObject.transform);
            }
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                //Debug.Log("You have released Touch while colliding with " + col.name);
                col.gameObject.transform.SetParent(null);
                col.attachedRigidbody.isKinematic = false;
                inHand = false;

                tossObject(col.attachedRigidbody);
            }
        }
    }

    void tossObject(Rigidbody rigidBody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);

        }
        else
        {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;
        }
    }
}

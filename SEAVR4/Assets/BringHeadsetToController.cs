using UnityEngine;
using System.Collections;

public class BringHeadsetToController : MonoBehaviour {

    public SteamVR_TrackedObject[] devices = new SteamVR_TrackedObject[2];
    public SteamVR_Controller.Device[] device = new SteamVR_Controller.Device[2];
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //if (TeleportScriptHead.levelup)
        //{
            GameObject[] hand = GameObject.FindGameObjectsWithTag("GameController");
            Debug.Log(hand.Length);
            for (int i = 0; i < hand.Length; i++)
            {
                devices[i] = hand[i].GetComponent<SteamVR_TrackedObject>();
                device[i] = SteamVR_Controller.Input((int)devices[i].index);
            }
            if (device[0].GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || device[1].GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Button press");
            }
            //TeleportScriptHead.levelup = false;
        //}

	}
}

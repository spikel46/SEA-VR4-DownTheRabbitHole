using UnityEngine;
using System.Collections;

public class Clicking : MonoBehaviour {

    int deviceIndexLeft;
    int deviceIndexRight;
    // Use this for initialization
    void Start()
    {
        deviceIndexLeft = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        deviceIndexRight = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
        if (deviceIndexLeft != -1)
        {
            Debug.Log("Found Left");
        }
        if (deviceIndexRight != -1)
        {
            Debug.Log("Found Right");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (deviceIndexLeft != -1 && SteamVR_Controller.Input(deviceIndexLeft).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            SteamVR_Controller.Input(deviceIndexLeft).TriggerHapticPulse(1000);
        }
        if (deviceIndexRight != -1 && SteamVR_Controller.Input(deviceIndexRight).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            SteamVR_Controller.Input(deviceIndexRight).TriggerHapticPulse(1000);
        }
    }
}

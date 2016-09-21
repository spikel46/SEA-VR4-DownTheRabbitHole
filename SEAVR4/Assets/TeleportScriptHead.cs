using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportScriptHead : MonoBehaviour {

    public AudioClip impact;
    AudioSource audio;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Headset")
        {
            Debug.Log("From Head");
            if ((PlayerPrefs.GetInt("test") == 1) && SceneManager.GetActiveScene().buildIndex == 2)
                SceneManager.LoadScene(4); //become a 4

            else {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if(col.gameObject.tag == "GameController")
        {
            Debug.Log("From Controller");
            audio.PlayOneShot(impact, 0.7F);
        }
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Exit");
        if (col.gameObject.tag == "GameController")
        {
            // trackedObj = gameObject.GetComponent<SteamVR_TrackedObject>();
            //device = SteamVR_Controller.Input((int)trackedObj.index);
            //if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            //{
               // backwards = true;
                Debug.Log("Exit Trigger");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //}
        }
    }
// Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 3)
            PlayerPrefs.SetInt("test", 1);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WebCamStream : MonoBehaviour {
    WebCamTexture webcamTexture;
    // Use this for initialization
    void Start()
    {
        webcamTexture = new WebCamTexture();
        Renderer render = GetComponent<Renderer>();
        webcamTexture.Play();
        render.material.mainTexture = webcamTexture;
    }

    // Update is called once per frame
    void Update () {
        if (webcamTexture.isPlaying)
        {
            Debug.Log("Live");
        }
	}
}

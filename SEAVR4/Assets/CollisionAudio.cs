using UnityEngine;
using System.Collections;

public class CollisionAudio : MonoBehaviour {

    public AudioClip impact;
    AudioSource audio;
    public float speed = 0;
    Vector3 lastPosition = Vector3.zero;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {

        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collider)
    {

        if (collider.gameObject.tag != "MainCamera")
        {
            FixedUpdate();
            audio.volume = speed + 0.5F;
            audio.PlayOneShot(impact, 0.7F);
        }
    }
}
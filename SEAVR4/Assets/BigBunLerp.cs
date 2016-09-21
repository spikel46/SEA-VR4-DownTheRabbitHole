using UnityEngine;
using System.Collections;

public class BigBunLerp : MonoBehaviour {
    
    private Vector3 newPosition;

	void Awake () {
        newPosition = transform.position;
	}
	
	void Update () {
        PositionChanging();
	}

    void PositionChanging()
    {
        Vector3 positionA = new Vector3(0, -60, 0); //first
        Vector3 positionB = new Vector3(0, 0, 1); //second pos

        newPosition = positionB;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }
}

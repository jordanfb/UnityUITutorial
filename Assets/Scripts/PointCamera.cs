using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCamera : MonoBehaviour {

    Quaternion startLoc;
    Quaternion goalLoc;
    private float lerpTime = 0;
    [SerializeField]
    private float time = 1;

    // Use this for initialization
    void Start () {
        goalLoc = transform.rotation;
	}
	
    public void SetTarget(Vector3 pos)
    {
        // aim the camera at the pos
        startLoc = transform.rotation;
        Vector3 dpos = pos - transform.position;
        goalLoc = Quaternion.LookRotation(dpos, Vector3.up);
        lerpTime = 0;
    }

	// Update is called once per frame
	void Update () {
        lerpTime += Time.deltaTime / time;
        transform.rotation = Quaternion.Lerp(startLoc, goalLoc, lerpTime / time);
	}
}

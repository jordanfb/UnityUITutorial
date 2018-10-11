using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCamera : MonoBehaviour {

    Quaternion startLoc;
    Quaternion goalLoc;
    private float lerpTime = 0;
    [SerializeField]
    private float time = 1;
    private Vector3 goalPos;

    // Use this for initialization
    void Start () {
        goalLoc = transform.rotation;
	}
	
    public void SetTarget(Vector3 pos)
    {
        // aim the camera at the pos
        if (pos == goalPos)
        {
            return; // don't set it because you're already heading there
        }
        goalPos = pos;
        startLoc = transform.rotation;
        Vector3 dpos = pos - transform.position;
        goalLoc = Quaternion.LookRotation(dpos, Vector3.up);
        lerpTime = 0;
    }

	// Update is called once per frame
	void Update () {
        lerpTime += Time.deltaTime / time;
        // this is using the "smootherstep" from https://chicounity3d.wordpress.com/2014/05/23/how-to-lerp-like-a-pro/
        float t = lerpTime * lerpTime * lerpTime * (lerpTime * (6f * lerpTime - 15f) + 10f);
        transform.rotation = Quaternion.Lerp(startLoc, goalLoc, t);
	}
}

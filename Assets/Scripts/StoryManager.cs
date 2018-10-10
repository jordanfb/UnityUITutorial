using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    [SerializeField]
    List<Transform> worldPositions;
    int i = 0;

    [SerializeField]
    PointCamera pointCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            pointCamera.SetTarget(worldPositions[i].position);
            i++;
        }
	}
}

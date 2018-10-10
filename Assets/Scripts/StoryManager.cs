using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    [Header("World Positions")]
    [SerializeField]
    List<string> worldPositionNames;
    [SerializeField]
    List<Transform> worldPositions;
    [SerializeField]
    List<worldLocations> worldEnums;

    [Space]
    [Header("Characters")]
    [SerializeField]
    string[] characterNames;
    [TextArea]
    [SerializeField]
    string[] characterDescriptions;
    [SerializeField]
    worldLocations[] characterPositions;
    float[] characterLikes;


    int i = 0;

    [SerializeField]
    PointCamera pointCamera;

	// Use this for initialization
	void Start () {

    }

    public void ResetGame()
    {
        characterLikes = new float[characterNames.Length];
    }

    public void LookAtLocation()
    {

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            pointCamera.SetTarget(worldPositions[i].position);
            i++;
            i %= worldPositions.Count;
        }
	}

    public enum worldLocations
    {
        CAR, HOSPITAL, HOUSE, PARK, STORE, OFFICE
    }
}

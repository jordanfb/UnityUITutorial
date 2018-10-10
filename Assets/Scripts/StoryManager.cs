using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    /*
     * How does this game work?
     * You have two weeks. Or something like that.
     * 
     * Start the game by entering your name. Then press start.
     * 
     * Every day you choose a place to go.
     * Every day you encounter a random character. So you see every character? Or is it totally random?
     * You gain skills of certain types at certain places.
     * You gain a random amount of skill each day to a certain extent.
     * 
     * Then at the end, you ask someone you've met on a date. If your skills match up to what they like they say yes, then you have the win text for them.
     * If they don't like you then they say no :(
     * 
     * Skills are: Hearts, Smarts, Charm, Money, Fun, Boldness, Creativity
     * Money, Sloth, Strength, Public Service, Stupidity, ???
     * because why not.
     */

    [SerializeField]
    PointCamera pointCamera;

    [Header("World Positions")]
    [SerializeField]
    List<Location> locations;
    [SerializeField]
    List<Transform> worldPositions; // the camera targets for the respective locations.

    [Space]
    [Header("Characters")]
    [SerializeField]
    List<Character> characters;

    int numDaysPerGame = 14; // this is going to be set by a setter function probably!

    // variables for the current game
    string playerName;
    int daysLeft;
    List<Character> seenCharacters; // the characters the player has seen at all
    int[] playerStats; // the player stats all start at 0.

    // getters and setters
    public int NumDaysPerGame
    {
        get
        {
            return numDaysPerGame;
        }

        set
        {
            if (value > 0) // only set the value if it's greater than 0.
                numDaysPerGame = value;
        }
    }
    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    // Use this for initialization
    void Start () {
        // set the camera positions for the locations because it's a simple way to do it.
        // Don't do this if you're actually making a game folks, instead, look up the correct way to do this on Google.
        // This may involve making a custom editor? That's not too bad actually.
        for (int i = 0; i < locations.Count; i++)
        {
            locations[i].cameraTarget = worldPositions[i].position;
        }
        ResetGame();
    }

    public void ResetGame()
    {
        playerStats = new int[7];
        seenCharacters = new List<Character>();
        daysLeft = NumDaysPerGame;
    }

    public void LookAtLocation(worldLocations loc)
    {
        Location l = GetLocationFromEnum(loc);
        pointCamera.SetTarget(l.cameraTarget);
    }

    public Location GetLocationFromEnum(worldLocations loc)
    {
        for (int i = 0; i < locations.Count; i++)
        {
            // get the world location for this enum. Probably should use a dictionary, but those aren't serializable by unity out of the box
            if (locations[i].worldLocationEnumValue == loc)
            {
                return locations[i];
            }
        }
        Debug.LogError("Unable to find location from enum: " + loc);
        return null; // this should never happen as long as all of the locs are setup, but bugs happen!
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset game!");
            ResetGame();
        }
	}

    public enum worldLocations
    {
        CAR, HOSPITAL, HOUSE, PARK, STORE, OFFICE, SEWER
    }
}

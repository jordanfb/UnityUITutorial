﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
     * house car park store office hospital sewers
     * Money (office, store), Sloth (car, house), Strength (sewers, store), Fun (park, sewers), 
     * Fruit (store, park), Disease (hospital, office, sewers), Sleep (house)
     * Money Sloth Strength Fun Fruit Disease Sleep
     * 
     * because why not.
     */

    [SerializeField]
    private StatsUI statsUI;
    [SerializeField]
    private GameObject startGameUIParent;
    [SerializeField]
    private GameObject locationSelectUI;
    [SerializeField]
    private Text dayEventText;
    [SerializeField]
    private Text dayLocationText;
    [SerializeField]
    private GameObject dayEventParent;

    [Space]
    [Header("Final day UI")]
    [SerializeField]
    private GameObject finalDayUIParent;
    [SerializeField]
    private GameObject askCharacterButtonPrefab;
    [SerializeField]
    private Transform askCharacterButtonParent;
    private List<GameObject> askButtons = new List<GameObject>();

    [Space]
    [Header("Result UI")]
    [SerializeField]
    private GameObject resultUIParent;
    [SerializeField]
    private Text resultTextUI;

    [Space]
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
    Location currentLocation; // this gets set every day

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
        statsUI.SetStats(playerStats);
        statsUI.HideStats();
        locationSelectUI.SetActive(false);
        dayEventParent.SetActive(false);
        finalDayUIParent.SetActive(false);
        resultUIParent.SetActive(false);
        startGameUIParent.SetActive(true);
        foreach (GameObject go in askButtons)
        {
            Destroy(go);
        }
        askButtons = new List<GameObject>();
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

    public void SetUpStartGameGUI()
    {
        // this hides all the GUI except for the name and start button, which it shows :P
        ResetGame(); // start a new game

        // HERE
    }

    public void StartGame()
    {
        // this hides the start game GUI

        // HERE
        statsUI.ShowStats();

        // then goes to the select location stuff
        StartDay();
    }

    public void StartDay()
    {
        // this loads up the select a location GUI, which is just a bunch of buttons with location names, when the cursor hovers over them you should call
        // ClickOnLocation so that the camera moves.

        locationSelectUI.SetActive(true);

    }

public void ClickOnLocation(Location loc)
    {
        // when you click on a location (or perhaps just hover your mouse over the button thing?) the camera moves to face the location. Because why not.
        // this function is finished, it's just the monobehavior that calls this function that isn't
        LookAtLocation(loc.worldLocationEnumValue);

        // this is where we should add the world UI above the buildings! Yeah! It's not actually here in the code, it's in the scene, but the idea holds true.
        // HERE
    }

    public void SelectLocation(Location loc)
    {
        // when you select a location to go to, this function gets called.
        // When this function is called we hide the UI for selecting locations

        // HERE
        locationSelectUI.SetActive(false);

        // we then go to the UI for the location, intializing it for that location.
        currentLocation = loc;
        // we also initialize the UI for that location.
        // Here we'll be creating the UI from scratch to show how you can set the text and the images and whatever.
        // We'll probably pass the loc to the monobehavior responsible then create it in code over there.
        Character randCharacter = GetRandomCharacter(loc.worldLocationEnumValue);
        bool seenBefore = seenCharacters.Contains(randCharacter);
        if (!seenBefore)
            seenCharacters.Add(randCharacter);
        // Create the character text
        string locationText = loc.locationName;
        string eventText = randCharacter.RandomEventText(loc, seenBefore, playerName);
        // create a window with the location name, the event, and then a "Next Day" button. Given time I'd love to add a choice here, but who has time?

        // HERE
        dayEventParent.SetActive(true);
        dayEventText.text = eventText;
        dayLocationText.text = locationText;

    }

    public void EndOfDay()
    {
        // this is called when we leave the Location. This is when we update our stats (and consequently the UI).
        currentLocation.UpdateStatList(playerStats);
        UpdateStatsUI();
        // then we hide the UI for the location

        // HERE
        dayEventParent.SetActive(false);

        // then we update the day count
        daysLeft--;
        if (daysLeft == 0)
        {
            // then it's time to ask someone to hang out!
            SetUpAsking();
        } else
        {
            // otherwise go back to the location select screen
            StartDay();
        }
    }

    public void UpdateStatsUI()
    {
        // here we should update the stats for the player in the top right corner.
        // We'll actually sorta convolutedly do this in a IMGUI way

        // HERE
        statsUI.SetStats(playerStats);
    }
    
    public void SetUpAsking()
    {
        // this sets up the ask someone UI with all the characters that we've met (stored in seenCharacters).
        // this is where we show off lists and lists made programatically.

        finalDayUIParent.SetActive(true);

        for (int i = 0; i < seenCharacters.Count; i++)
        {
            Character curr = seenCharacters[i];
            // create a display object that allows you to select the characters.
            // perhaps add the listener to the click programatically?
            // make sure to add them to a list of UI items so you can delete them.

            // HERE
            GameObject go = Instantiate(askCharacterButtonPrefab, askCharacterButtonParent);
            go.GetComponent<DateChoiceButtonManager>().SetCharacter(curr, this);
            askButtons.Add(go);
        }
    }

    public void AskCharacter(Character character)
    {
        // this is when we ask someone to hang out!
        // if the character likes your stats, then you get a happy ending! If not, you get a sad ending :(
        // this is basically just a text screen plus a button to start a new game. If you click that then you get the start game function, which sets up the player name
        // entry!
        string resultText = "";
        if (character.EvaluateStats(playerStats))
        {
            // then you get the win text!
            resultText = character.yesText;
        } else
        {
            // then you get the :( text
            resultText = character.noText;
        }
        resultText = resultText.Replace("[pname]", PlayerName);
        // set the result in a text box and have a button that lets you start again
        // HERE
        finalDayUIParent.SetActive(false); // hide the previous day's UI

        resultUIParent.SetActive(true);
        resultTextUI.text = resultText;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    Character GetRandomCharacter(worldLocations loc)
    {
        // get a random character that spawns at that location
        // if no character spawns then make the game better, you managed to break it
        List<Character> possible = new List<Character>();
        for (int i = 0; i < characters.Count; i++)
        {
            worldLocations[] locs = characters[i].spawnLocations;
            for (int j = 0; j < locs.Length; j++)
            {
                if (locs[j] == loc || locs[j] == worldLocations.ALL)
                {
                    // then they're a possible character
                    possible.Add(characters[i]);
                    break; // stop checking this character we know they're possible.
                }
            }

        }
        return possible[Random.Range(0, possible.Count)]; // return a random character
    }

    public enum worldLocations
    {
        CAR, HOSPITAL, HOUSE, PARK, STORE, OFFICE, SEWER, ALL // the all is for the event text stuff
    }
}

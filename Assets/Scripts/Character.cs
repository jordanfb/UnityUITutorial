using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character", menuName ="Character", order = 0)]
public class Character : ScriptableObject {

    public string characterName;
    [TextArea]
    public string introductionText;
    [TextArea]
    public string description;
    public StoryManager.worldLocations[] spawnLocations; // the list of places where they spawn

    [Space]
    [Header("Events")]
    public string[] events;
    public StoryManager.worldLocations[] eventLocations; // where those events can happen

    // these things here describe what they like and dislike. Duh. It's used for scoring what happens
    // these are actually integer values that are max and min values required.
    [Space]
    [Tooltip("Money Sloth Strength Fun Fruit Disease Sleep")]
    public float[] likes; // stat has to be higher or equal to this value. Set it to 0 if you want to ignore it
    [Tooltip("Money Sloth Strength Fun Fruit Disease Sleep")]
    public float[] dislikes; // stat has to be less than or equal to this value. Just set it to 100000 if you want to ignore it.

    [Space]
    [Header("Results")]
    [TextArea]
    public string yesText;
    [TextArea]
    public string noText;


    public bool EvaluateStats(int[] playerStats)
    {
        // this returns true if the character is happy with the player and false otherwise
        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i] < likes[i])
                return false; // this failed because it didn't get a high enough like score
            if (playerStats[i] > dislikes[i])
                return false; // this failed because it got too high of a disliked trait.
        }
        return true; // if it made it through all of the tests it's satisfied
    }

    private string GetValidTextForLoc(Location loc)
    {
        List<string> possible = new List<string>();
        for (int i = 0; i < events.Length; i++)
        {
            if (eventLocations[i] == StoryManager.worldLocations.ALL || eventLocations[i] == loc.worldLocationEnumValue)
            {
                possible.Add(events[i]);
            }

        }
        return possible[Random.Range(0, possible.Count)]; // return a random character
    }

    public string RandomEventText(Location loc, bool seenBefore, string playerName)
    {
        string output = "";
        if (!seenBefore)
        {
            output = introductionText.Replace("[pname]", playerName); // "You catch sight of someone you've never seen before: " + characterName + ". " + description;
            // move the description into the intro text for now and just don't use it. This is pivoting folks!
            // Given time I'd love to make it so you also respond to the event by choosing between two options, but I don't have time to write that dialog :P
            // If I were doing that I'd make a class that stores the event text, the option A text, the option B text, and the results for those two choices
            // along with the stat changes for those choices. That would actually be reasonably simple, it's just the additional writing :P. Maybe if we have extra
            // time at the end of the lesson.
        } else
        {
            // I'm using this replacement method for the character here as well because IDK. We could probably just write in the character name...
            // I'll think about this...
            output = events[Random.Range(0, events.Length)].Replace("[pname]", playerName).Replace("[cname]", characterName);
        }
        return output;
    }
}

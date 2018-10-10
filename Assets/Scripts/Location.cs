using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Location", order = 0)]
public class Location : ScriptableObject
{
    public string locationName;
    [TextArea]
    public string locationDescription;
    [Tooltip("Hearts, Smarts, Charm, Money, Fun, Boldness, Creativity, min to max inclusive on both ends (only integers)")]
    public Vector2[] skillChances;
    // these are the random ranges of skills you get. When you visit you increase each skill by a random value between the min and max inclusive.
    public Vector3 cameraTarget;
    // this is a bad way of storing the camera target and UI hover text location. It's bad because we have to manually enter it in instead of setting it in the editor or whatever.
    // in fact I may just set loop in the beginning and set it from the story manager which is terrible but sorry guys, this isn't a real game :P
    public StoryManager.worldLocations worldLocationEnumValue; // the enum value that is linked with this.

    public int[] UpdateStatList(int[] stats)
    {
        // loop through the list of stats and add the random values
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] += Random.Range((int)skillChances[i].x, (int)skillChances[i].y+1);
        }
        return stats;
    }
}

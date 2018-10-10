using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character", menuName ="Character", order = 0)]
public class Character : ScriptableObject {

    public string characterName;
    [TextArea]
    public string description;
    public string[] events;
    
    // these things here describe what they like and dislike. Duh. It's used for scoring what happens
    [Space]
    public float[] likes;
    public float[] dislikes;

    [Space]
    [Header("Results")]
    [TextArea]
    public string yesText;
    [TextArea]
    public string noText;
}

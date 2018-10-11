using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateChoiceButtonManager : MonoBehaviour {

    [SerializeField]
    private Text characterName;

    private StoryManager storyManager;
    private Character character;


    /// <summary>
    /// Set the information so that the UI element can choose a character
    /// </summary>
    /// <param name="c">The character the button should select</param>
    /// <param name="manager">The story manager managing the story</param>
    public void SetCharacter(Character c, StoryManager manager)
    {
        character = c;
        characterName.text = c.characterName;
        storyManager = manager;
    }

    public void SelectCharacter()
    {
        storyManager.AskCharacter(character);
    }
}

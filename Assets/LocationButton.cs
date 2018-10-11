using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButton : MonoBehaviour {

    [SerializeField]
    private Location loc;

    [SerializeField]
    Text buttonText;

    [SerializeField]
    private StoryManager manager;

	// Use this for initialization
	void Start () {
        buttonText.text = loc.locationName;
	}
	
	public void LocationSelected()
    {
        manager.SelectLocation(loc);
        manager.ClickOnLocation(loc);
    }

    public void LocationHovered()
    {
        manager.ClickOnLocation(loc);
    }
}

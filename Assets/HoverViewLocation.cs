using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverViewLocation : MonoBehaviour, IPointerEnterHandler {

    private LocationButton button;

    private void Start()
    {
        button = GetComponent<LocationButton>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.LocationHovered();
    }
}

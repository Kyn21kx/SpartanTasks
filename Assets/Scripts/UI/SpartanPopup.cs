using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public enum PopupTypes {
    Info,
    Debug,
    Error,
    Input
}

public class SpartanPopup {
    
    private const int MAX_ADD_COMPONENTS = 5;

    public string Title { get; set; }
    public string Description { get; set; }

    public PopupTypes PopupType { get; set;}

    public List<TextMeshProUGUI> additionalTextComponents { get; private set; }
    public List<Selectable> additionalInputComponents { get; private set; }

    public SpartanPopup(string title, string description, PopupTypes popupType)
    {
        this.Title = title;
        this.Description = description;
        this.PopupType = popupType;
        this.additionalTextComponents = new List<TextMeshProUGUI>(MAX_ADD_COMPONENTS);
        //If the pop up is an input type, initialize it as such
        if (popupType == PopupTypes.Input) { 
            this.additionalTextComponents = new List<TextMeshProUGUI>(MAX_ADD_COMPONENTS);
        }
    }

    public void AddTextComponent(TextMeshProUGUI textComponent)
    {
        this.additionalTextComponents.Add(textComponent);
        textComponent.enabled = false;
    }

    public void AddInputComponent<T>(T inputComponent) where T : Selectable
    {
        this.additionalInputComponents.Add(inputComponent);
        inputComponent.enabled = false;
    }

}
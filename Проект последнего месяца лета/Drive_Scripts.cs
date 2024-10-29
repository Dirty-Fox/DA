using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive_Scripts : MonoBehaviour, I_Interactable
{
    [SerializeField] private string _pprompt;
    [SerializeField] private GameObject Map;

    public string InteractionPrompt => _pprompt;

    public bool Interact(Interactor interactor)
    {

        Map.SetActive(true);
        return true;
    }
}

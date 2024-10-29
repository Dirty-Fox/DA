using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants_inventory : MonoBehaviour, I_Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] GameObject plantInventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {

        plantInventory.SetActive(true);
        return true;
    }
}

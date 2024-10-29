using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_S_Chmom : MonoBehaviour, I_Interactable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
            
    public bool Interact(Interactor interactor)
    {

        Debug.Log("Ti pnul chmo");
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactibleMask;
    [SerializeField] private Interaction_Prompt _interactionPromptUi;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private I_Interactable _interactable;
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactibleMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<I_Interactable>();

            if (_interactable != null) 
            {
                if (!_interactionPromptUi._isDisplayed) 
                { 
                    _interactionPromptUi.SetUpPanel(_interactable.InteractionPrompt); 
                }

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    _interactable.Interact(this);
                }
            } 
        }
        else
        {
            if (_interactable != null)
            {
                _interactable = null;
            }
            if (_interactionPromptUi._isDisplayed)
            {
                _interactionPromptUi.ClosePanel();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}

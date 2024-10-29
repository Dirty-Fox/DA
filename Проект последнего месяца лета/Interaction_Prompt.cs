using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction_Prompt : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField]private GameObject _uiPanel;
    [SerializeField]private TextMeshProUGUI _promptText;

    private void Start()
    {
        _mainCamera = Camera.main;
        _uiPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool _isDisplayed = false;
    public void SetUpPanel(string promptText )
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        _isDisplayed = true;
    }

    public void ClosePanel() 
    {
        _isDisplayed = false;
        _uiPanel.SetActive(false);
    }
}

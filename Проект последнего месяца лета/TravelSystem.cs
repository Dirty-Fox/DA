using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelSystem : MonoBehaviour
{
    public void SelectDestenation(string sceneName)
    {
        Debug.Log("Button clicked, loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}

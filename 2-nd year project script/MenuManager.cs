using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainInventoryGroup;
    public GameObject pauseMenuUI;

    public static bool menuActive = false;

    void Update()
    {

        //Inventory Menu

        if (Input.GetKeyUp(KeyCode.I) && menuActive == false)
        {
            mainInventoryGroup.gameObject.SetActive(!mainInventoryGroup.gameObject.activeSelf);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            Debug.Log("inventory active");
            menuActive = true;
        }

        else {
        
        if (Input.GetKeyUp(KeyCode.I) && menuActive == true)
            {
                mainInventoryGroup.gameObject.SetActive(!mainInventoryGroup.gameObject.activeSelf);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                Debug.Log("Inventory not active");
                menuActive = false;
            }

        }

        //Pause Menu

        if (Input.GetKeyUp(KeyCode.Q) && !menuActive)
            {
                pauseMenuUI.gameObject.SetActive(!pauseMenuUI.gameObject.activeSelf);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                Debug.Log("menu active");
                menuActive = true;
        }
        else 
        {

            if (Input.GetKeyUp(KeyCode.Q))
            {
                pauseMenuUI.gameObject.SetActive(!pauseMenuUI.gameObject.activeSelf);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                Debug.Log("menu not active (By 'Q')");
                menuActive = false;
            }

        }
    }

    public void MenuActive() { 
        pauseMenuUI.gameObject.SetActive(!pauseMenuUI.gameObject.activeSelf);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        Debug.Log("menu not active (By button)");
        menuActive = false;
    }
}

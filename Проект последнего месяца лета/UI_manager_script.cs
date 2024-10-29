using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager_script : MonoBehaviour
{
    [SerializeField] private GameObject Map;
    [SerializeField] private GameObject _seeds;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Map.gameObject.SetActive(false);
            _seeds.gameObject.SetActive(false);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Platform_Manager : MonoBehaviour
{
    [SerializeField]
    public float spawnRate = 10f;
    [SerializeField]
    //private GameObject[] _roadPrefab; //array of prefabs
    public GameObject roadPrefabOne;
    //-----------------------------------------------------------------------------------------------------------------
    //-------------------------------------------Spawn road------------------------------------------------------------
    private void OnEnable()             // рабоатет когда объект с кодом спавна включен
    {
        InvokeRepeating(nameof(Spawn), 0, spawnRate);
    }
    private void OnDisable()            // Вырубать код спавна если объект, на который код прикрепили, выключен
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        Instantiate(roadPrefabOne, transform.position, Quaternion.Euler(0, 0, 0));
    }
    //-----------------------------------------------------------------------------------------------------------------
}

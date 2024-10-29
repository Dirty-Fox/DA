using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants_grow_script : MonoBehaviour
{
    public GameObject seedPrefab;
    public void Plant()
    {
        Instantiate(seedPrefab, transform.position, Quaternion.identity);
    }

}
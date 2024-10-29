using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/item")]
public class Item : ScriptableObject
{
    [Header("Stats")]
    public int HungerRegen;
    public int ThirstRegen;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scripteable object/Item")]
public class Item : ScriptableObject
{
    [Header("Item attributes")]
    public Sprite image;
    public ItemType type;
    public int id;
    
}

public enum ItemType
{
    Flask,Robot,Note
}

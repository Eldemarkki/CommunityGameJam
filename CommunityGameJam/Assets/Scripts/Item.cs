﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite icon;

    public Item recipe1, recipe2;
}

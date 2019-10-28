using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Category", menuName = "AtomStudios/CategoryAR")]
public class Category : ScriptableObject
{
    public string nameCategory;
    public Sprite logoCategory;
    public bool showJustContents = true;
    public List<ContentAR> contents;
}
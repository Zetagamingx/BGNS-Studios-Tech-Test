using UnityEngine;

public enum ItemCategory
{
    key
}

[CreateAssetMenu(menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    public Sprite icon;
    public string pickupMessage;
    public bool isStackable = true;
    public ItemCategory category;
    [TextArea] public string description;

}
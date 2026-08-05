using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int maxSlots = 30;

    [SerializeField] private List<InventorySlot> inventory = new();

    public List<InventorySlot> Inventory => inventory;

    

    private void Awake()
    {
        inventory.Clear();

        for (int i = 0; i < maxSlots; i++)
        {
            inventory.Add(new InventorySlot(null, 0));
        }
    }

    public bool AddItem(ItemData item, int amount)
    {
        //Debug.Log("Tried to add Item");
        foreach (InventorySlot slot in inventory)
        {
            if (!slot.IsEmpty &&
                slot.item == item &&
                item.IsStackable)
            {
                slot.quantity += amount;
                //PrintInventory();
                return true;
            }
        }

        
        foreach (InventorySlot slot in inventory)
        {
            if (slot.IsEmpty)
            {
                slot.item = item;
                slot.quantity = amount;
                //PrintInventory();
                return true;
            }
        }

        Debug.Log("Inventory Full");
        return false;
    }

    public void RemoveItem(ItemData item, int amount)
    {
        foreach (InventorySlot slot in inventory)
        {
            if (slot.item == item)
            {
                slot.quantity -= amount;

                if (slot.quantity <= 0)
                    slot.Clear();

                return;
            }
        }
    }

    public bool HasItem(ItemData item)
    {
        foreach (InventorySlot slot in inventory)
        {
            if (!slot.IsEmpty && slot.item == item)
                return true;
        }

        return false;
    }

    public void PrintInventory()
    {
        Debug.Log("===== INVENTORY =====");

        for (int i = 0; i < inventory.Count; i++)
        {
            InventorySlot slot = inventory[i];

            if (slot.IsEmpty)
                Debug.Log($"Slot {i}: Empty");
            else
                Debug.Log($"Slot {i}: {slot.item.ItemName} x{slot.quantity}");
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private RecipeDatabase recipeDatabase;

    [SerializeField] private int maxSlots = 30;

    [SerializeField] private List<InventorySlot> inventory = new();

    public InputActionReference combineAction;

    private int firstSelectedSlot = -1;
    private int secondSelectedSlot = -1;
    public List<InventorySlot> Inventory => inventory;

    

    private void Awake()
    {
        inventory.Clear();

        for (int i = 0; i < maxSlots; i++)
        {
            inventory.Add(new InventorySlot(null, 0));
        }
    }

    public void OnEnable()
    {
        combineAction.action.Enable();
        combineAction.action.performed += OnCombine;
    }

    public void OnDisable()
    {
        combineAction.action.performed -= OnCombine;
        combineAction.action.Disable();
    }

    public void SwapSlots(int fromIndex, int toIndex)
    {
        InventorySlot temp = Inventory[fromIndex];

        Inventory[fromIndex] = Inventory[toIndex];

        Inventory[toIndex] = temp;
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

    private void OnCombine(InputAction.CallbackContext context)
    {
        TryCombineItems(0, 1);
    }

    public bool TryCombineItems(int firstSlot, int secondSlot)
    {
        ItemData itemA = Inventory[firstSlot].item;
        ItemData itemB = Inventory[secondSlot].item;

        foreach (ItemCombineRecipe recipe in recipeDatabase.allRecipes)
        {
            if ((recipe.inputA == itemA && recipe.inputB == itemB) 
                
                ||    
                
                (recipe.inputA == itemB && recipe.inputB == itemA))

            {
                Inventory[firstSlot] = new InventorySlot(recipe.result, 1);

                Inventory[secondSlot].Clear();

                PrintInventory();

                FindFirstObjectByType<InventoryUIController>().RefreshInventory();

                return true;
            }
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
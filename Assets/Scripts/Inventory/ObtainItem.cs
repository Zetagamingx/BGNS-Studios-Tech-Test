using UnityEngine;

public class ObtainItem : MonoBehaviour, IInteract,IPickUp
{

    [SerializeField] private ItemData itemData;
    [SerializeField] private int quantity = 1;

    private Collider objectCollider;
    public string InteractionPrompt => "Pick up";

    public string ItemObtainedPrompt => $"Obtained {itemData.ItemName}";

    public ItemData Data => itemData;

    public int Quantity => quantity;

    private void Awake()
    {
        objectCollider = GetComponent<Collider>();
    }

    public void Interact()
    {
        PickUpItem();
    }

    private void PickUpItem()
    {
        objectCollider.enabled = false;
        gameObject.SetActive(false);
    }
}

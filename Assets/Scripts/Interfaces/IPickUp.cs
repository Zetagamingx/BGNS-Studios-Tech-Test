using UnityEngine.UIElements;

public interface IPickUp
{
    void PickUpItem();
    string ItemObtainedPrompt { get; }

    ItemData Data { get; }
    int Quantity { get; }
}

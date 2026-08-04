using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        UIDragItem draggedItem = eventData.pointerDrag.GetComponent<UIDragItem>();

        if (draggedItem == null)
            return;

        UIDragItem targetItem = GetComponentInChildren<UIDragItem>();

        //checks if slot already has another item for the swap.

        if (targetItem != null && targetItem != draggedItem)
        {
            targetItem.transform.SetParent(draggedItem.OriginalParent, false);
            targetItem.RectTransform.anchoredPosition = Vector2.zero;
        }

        draggedItem.transform.SetParent(draggedItem.transform, false);
        draggedItem.RectTransform.anchoredPosition = Vector2.zero;

        Debug.Log("Item Drop on" + gameObject.name);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UIDragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int SlotIndex { get; set; }

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Image image;
    private Transform originalParent;

    public RectTransform RectTransform => rectTransform;

    



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"Dragging slot {SlotIndex}");
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;

        UIDragVisual.Instance.BeginDrag(image.sprite);
        image.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UIDragVisual.Instance.Drag(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        UIDragVisual.Instance.EndDrag();

        image.enabled = true;

        //transform.SetParent(originalParent, false);
        rectTransform.anchoredPosition = Vector2.zero;
    }
}
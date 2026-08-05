using UnityEngine;
using UnityEngine.UI;

public class UIDragVisual : MonoBehaviour
{
    [SerializeField] private Image dragImage;

    private RectTransform rectTransform;

    public static UIDragVisual Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        rectTransform = dragImage.rectTransform;

        dragImage.gameObject.SetActive(false);
    }

    public void BeginDrag(Sprite sprite)
    {
        dragImage.sprite = sprite;
        dragImage.gameObject.SetActive(true);
    }

    public void Drag(Vector2 screenPosition)
    {
        rectTransform.position = screenPosition;
    }

    public void EndDrag()
    {
        dragImage.gameObject.SetActive(false);
    }
}
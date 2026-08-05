using UnityEngine;

public class TitleSelectionController : BasicClickController, IUISelectable
{
    [SerializeField] private string SectionToActivate;
    [SerializeField] private UIButtonVisual visual;

    private ConversationSelectionModel titleSelectionModel;
    private ConversationSelectionViewModel titleSelectionViewModel;
    
    protected override void Awake()
    {
        base.Awake();

        if (visual == null)
            visual = GetComponent<UIButtonVisual>();

        titleSelectionModel = GetComponentInParent<ConversationSelectionModel>(true);
        titleSelectionViewModel = GetComponentInParent<ConversationSelectionViewModel>(true);
    }
    protected override void OnClick()
    {
        titleSelectionModel.ShowSection(SectionToActivate);
        AudioManager.Instance.PlaySfx("emptybottlebump");
    }

    public void OnDeselected()
    {
        visual.SetHighlighted(false);
    }

    public void OnSelected()
    {
        Debug.Log($"TitleSelectionButton is selected");
        visual.SetHighlighted(true);
    }

    public void OnSubmit()
    {
        visual.PlayPressed();
        titleSelectionModel.ShowSection(SectionToActivate);
        AudioManager.Instance.PlaySfx("emptybottlebump");
        
        // Call ViewModel / Model logic here
        Debug.Log("Load Game button pressed.");
    }
}

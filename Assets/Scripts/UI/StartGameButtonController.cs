using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameButtonController : BasicClickController, IUISelectable
{

    [SerializeField] private UIButtonVisual visual;

    protected override void Awake()
    {
        base.Awake();

        if (visual == null)
            visual = GetComponent<UIButtonVisual>();
    }

    public void OnDeselected()
    {
        visual.SetHighlighted(false);
    }

    public void OnSelected()
    {
        visual.SetHighlighted(true);
        AudioManager.Instance.PlaySfx("Selected");
    }

    public void OnSubmit()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnClick()
    {
        Debug.Log("Start button clicked.");
        AudioManager.Instance.PlaySfx("Confirm");
        SceneManager.LoadScene(1);
    }
}


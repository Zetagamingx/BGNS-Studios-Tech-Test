using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGameButtonController : BasicClickController, IUISelectable
{

    [SerializeField] private UIButtonVisual visual;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private PauseMenuController pauseMenuController;

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
        AudioManager.Instance.PlaySfx("Confirm");
        pauseMenuController.ClosePause();
        saveManager.LoadGame();
        //SceneManager.LoadScene(1);
    }
}



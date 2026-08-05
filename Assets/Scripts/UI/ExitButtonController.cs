using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitButtonController : BasicClickController, IUISelectable
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
    }

    public void OnSubmit()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnClick()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


}

using UnityEngine;

public class TitleStarter : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Title");
    }
}

using UnityEngine;

public class ScreenViewAboutModel : MonoBehaviour
{
    public string urlContent;

    public void OnButtonSiteContentClicked()
    {
        Application.OpenURL(urlContent);
    }
}
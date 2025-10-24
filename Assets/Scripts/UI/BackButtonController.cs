using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    private GameObject activePanel;


    public void OnBackButtonClicked()
    {
        activePanel = UIManager.Instance.GetCurrentPanel();
        if (activePanel != null)
        {
            PanelController panelControllerScript = activePanel.GetComponent<PanelController>();
            if ( panelControllerScript != null)
            {
                GameObject previousPanel = panelControllerScript.GetPreviousPanel();
                if (previousPanel != null)
                {
                    UIManager.Instance.ShowPanel(previousPanel);
                }
                else
                {
                    Debug.Log(" no previous panel.");
                }
            }
            else
            {
                Debug.Log(" no panel controller.");
            }
        }
        else
        {
            Debug.Log(" no active panel.");
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SpookigramPanelController : PanelController
{

    [SerializeField] private Button myProfileButton;
    [SerializeField] private GameObject profilePanel;
    [SerializeField] private ProfileManager profileManager;
    private void OnEnable()
    {
        myProfileButton.onClick.AddListener(OnMyProfileButtonClicked);
    }
    private void OnDisable()
    {
        myProfileButton.onClick.RemoveListener(OnMyProfileButtonClicked);
    }
    private void OnMyProfileButtonClicked()
    {
        UIManager.Instance.ShowPanel(profilePanel);
        profilePanel.GetComponent<ProfileFeedPanelController>()
            .AssignProfileObject(profileManager.PlayerProfile, "");

    }
}

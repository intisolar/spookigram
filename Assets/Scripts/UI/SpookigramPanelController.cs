using UnityEngine;
using UnityEngine.UI;

public class SpookigramPanelController : PanelController
{
    [Header("Profile")]
    [SerializeField] private Button myProfileButton;
    [SerializeField] private GameObject profilePanel;
    [SerializeField] private ProfileManager profileManager;
    [Header("Friends")]
    [SerializeField] private Button myFriendsButton;
    [SerializeField] private GameObject friendsPanel;
    [Header("Messages")]
    [SerializeField] private Button messagesButton;
    [SerializeField] private GameObject messagesPanel;
    private void OnEnable()
    {
        myProfileButton.onClick.AddListener(OnMyProfileButtonClicked);
        myFriendsButton.onClick.AddListener(OnFriendsButtonClicked);
        messagesButton.onClick.AddListener(OnMessagesButtonClicked);
    }
    private void OnDisable()
    {
        myProfileButton.onClick.RemoveListener(OnMyProfileButtonClicked);
        myFriendsButton.onClick.RemoveListener(OnFriendsButtonClicked);
        messagesButton.onClick.RemoveListener(OnMessagesButtonClicked);
    }
    private void OnMyProfileButtonClicked()
    {
        UIManager.Instance.ShowPanel(profilePanel);
        profilePanel.GetComponent<ProfileFeedPanelController>()
            .AssignProfileObject(profileManager.PlayerProfile, "");

    }

    private void OnFriendsButtonClicked()
    {
        UIManager.Instance.ShowPanel(friendsPanel);
        FriendsPanelController controller =
        friendsPanel.GetComponent<FriendsPanelController>();
        controller.SetFriendsList(profileManager.PlayerProfile.GetFriends());
        controller.BuildFriendList();
    }

    private void OnMessagesButtonClicked()
    {
        UIManager.Instance.ShowPanel(messagesPanel);
        MessagesPanelController controller =
        messagesPanel.GetComponent<MessagesPanelController>();
        controller.SetFriendsList(profileManager.PlayerProfile.GetFriends());
        controller.BuildFriendList();
    }
}

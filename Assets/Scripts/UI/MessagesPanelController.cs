using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesPanelController : PanelController
{
    private List<ProfileObject> friendsMessagesList = null;
    [Header("Prefab & Parent")]
    [SerializeField] private FriendElementUtil friendItemPrefab;
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject chatPanel;

    private void OnEnable()
    {
        ClearPreFabFriendsFromParent();
    }

    public void BuildFriendList()
    {


        if (friendsMessagesList == null || friendsMessagesList.Count == 0)
        {
            Debug.LogWarning("friendsMessagesList is null");
            return;
        }
        foreach (var friend in friendsMessagesList)
        {
            Debug.Log(friend.GetUserName());
            var item = Instantiate(friendItemPrefab, contentParent);
            item.BindMessage(friend.GetUserName(), "Ver mensaje..." , friend.GetProfilePicture(), friend.DialogueScriptPath);
            // Si tu item tiene botón, acá podés suscribir:
             item.GetComponentInChildren<Button>()?.onClick.AddListener(() => OpenFriendProfile(friend));
        }
    }

    private void OpenFriendProfile(ProfileObject friend)
    {
        UIManager.Instance.ShowPanel(chatPanel);
        ChatPanelController controller =
        chatPanel.GetComponent<ChatPanelController>();
        //chatPanel.ResourcesPath = "";
    }
    private void ClearPreFabFriendsFromParent()
    {
        for (int i = contentParent.childCount - 1; i >= 0; i--)
            Destroy(contentParent.GetChild(i).gameObject);
    }
    private void OnDisable()
    {
        ResetPanelInfo();
    }
    public override void ResetPanelInfo()
    {
        friendsMessagesList = null;
        ClearPreFabFriendsFromParent();
    }

    public void SetFriendsList(List<ProfileObject> friendsList)
    {
        this.friendsMessagesList = friendsList;

    }
}

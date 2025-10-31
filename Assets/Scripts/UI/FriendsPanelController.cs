using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class FriendsPanelController : PanelController
{
    private List<ProfileObject> friendsList = null;
    [Header("Prefab & Parent")]
    [SerializeField] private FriendElementUtil friendItemPrefab;
    [SerializeField] private Transform contentParent;

    private void OnEnable()
    {
        ClearPreFabFriendsFromParent();
    }

    public void BuildFriendList()
    {
        

        if (friendsList == null || friendsList.Count == 0)
        {
            Debug.LogWarning("FriendList is null");
            return;
        }
        foreach (var friend in friendsList)
        {
            Debug.Log(friend.GetUserName());
            var item = Instantiate(friendItemPrefab, contentParent);
            item.BindFriend(friend.GetUserName(), friend.GetProfilePicture());
            // Si tu item tiene botón, acá podés suscribir:
            item.GetComponentInChildren<Button>()?.onClick.AddListener(() => OpenFriendProfile(friend));
        }
    }
    private void OpenFriendProfile(ProfileObject friend)
    {
        FriendProfilePanelManager.Instance.OpenFriendProfile(friend.Id);
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
        friendsList = null;
        ClearPreFabFriendsFromParent();
    }

    public void SetFriendsList(List<ProfileObject> friendsList)
    {
        this.friendsList = friendsList;
    }
}

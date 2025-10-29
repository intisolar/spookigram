using System.Collections.Generic;
using UnityEngine;

public class MessagesPanelController : PanelController
{
    private List<ProfileObject> friendsMessagesList = null;
    [Header("Prefab & Parent")]
    [SerializeField] private FriendElementUtil friendItemPrefab;
    [SerializeField] private Transform contentParent;

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
            item.BindMessage(friend.GetUserName(), null , friend.GetProfilePicture());
            // Si tu item tiene botón, acá podés suscribir:
            // item.GetComponent<Button>()?.onClick.AddListener(() => OpenFriendProfile(friend));
        }
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

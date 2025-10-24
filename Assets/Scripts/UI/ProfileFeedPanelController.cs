using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileFeedPanelController : PanelController
{

    [SerializeField] private TMP_Text userNameTMP;
    [SerializeField] private Image profilePicture;
    private ProfileObject profileObject;


    private void OnEnable()
    {
        //if ( userName == null )
        //{
        //    string playerName = GameManager.Instance.GetPlayerName();
        //    userName = string.IsNullOrEmpty(playerName) ? "mapache_anonimo" : playerName;
        //}
        //Debug.Log($"[ProfileFeedPanel] userName: {userName}");
        //if (string.IsNullOrEmpty(userNameTMP.text))
        //{
        //    userNameTMP.text = userName;
        //}
    }

    private void OnDisable()
    {
        ResetPanelInfo();
    }

    public void AssignProfileObject(ProfileRole userType, int userId)
    {
        //look for id of profile object and assign it to the panel to then display username image, etc.
    }

    public void AssignProfileObject(ProfileObject profile, string v)
    {
        profileObject = profile;
        if (profile == null )
        {
            Debug.LogWarning("profile is null");
            return;
        }
        if (profile.GetProfilePicture() == null)
        {
            Debug.LogWarning("profile picture is null");
            return;
        }
        if (profile.GetUserName() == null || profile.GetUserName().Trim().Length < 0)
        {
            Debug.LogWarning("profile user name is null");
            return;
        }
        RefreshUserInfo();
    }
    public void RefreshUserInfo()
    {
        userNameTMP.text = profileObject.GetUserName();
        Debug.Log($"[ProfileFeedPanel] Refrescado con: {profileObject.GetUserName()}");
        profilePicture.sprite = profileObject.GetProfilePicture();
    }

    public override void ResetPanelInfo()
    {
        ResetUserInfo();
    }

    private void ResetUserInfo()
    {
        userNameTMP.text = null;
        profilePicture.sprite = null;
    }


}

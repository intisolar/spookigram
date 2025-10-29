using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfileObject : MonoBehaviour
{
    [SerializeField] private int id;

    [Header("Config")]
    [SerializeField] private ProfileRole role = ProfileRole.Suspect;

    [Header("Profile_info")]
    [SerializeField] private Image profileImage;
    [SerializeField] private string userName;
    [SerializeField] private string description;
    [SerializeField] private int friendNumber;
    [Header("Profile_content")]
    [SerializeField] private List<ProfileObject> friendList;
    private ImageController imageController;
    private List<Image> images;
    

    public int Id { get => id; set => id = value; }

    private void Awake()
    {
        if (role == ProfileRole.Player)
        {
            imageController = gameObject.GetComponentInChildren<ImageController>();
            images = imageController.GetAllChildrenImages();
        }
    }

    public void SetProfilePicture(Image picture)
    {
        profileImage = picture;
    }



    public string GetUserName()
    {
        return userName;
    }

    public void SetUserName(string user)
    {
        userName = user;
    }

    public Sprite GetProfilePicture()
    {
        return profileImage.sprite;
    }

    public void ResetPlayerInfo()
    {
        SetUserName(null);
        SetProfilePicture(null);
    }

    public void AssignProfilePictureById(int picId)
    {

        Image pickedImage = GetProfilePictureById(picId);

        if(pickedImage == null)
        {
            Debug.LogError("Image ID wasn't found, profile picture unassigned");
        }
        else
        {
            profileImage = pickedImage;
        }
    }

    public Image GetProfilePictureById(int picId)
    {
        Image foundImage = null;
        if (images != null)
        {
            foreach (var image in images)
            {
                if (image.GetComponent<ImageInfo>().Id == picId)
                {
                    foundImage = image;
                }
            }
        }
        return foundImage;
    }

    public void AddFriend(ProfileObject profile)
    {
        if (DoesFriendExistAlredy(profile))
        {
            return;
        } 

        friendList.Add(profile);
    }
    
    public bool DoesFriendExistAlredy(ProfileObject profile)
    {
        foreach (var friend in friendList)
        {
            if (friend.Equals(profile))
            {
                Debug.LogWarning("Friend Already exists. this.Id=" + this.id + " username=" + this.GetUserName() +
                    " vs. " + profile.Id + " " + profile.GetUserName());
                return true;
            }
        }

        return false;

    }

    public List<ProfileObject> GetFriends()
    {
        if(friendList != null && friendList.Count > 0)
        {
            Debug.Log("There are friends in ProfileObject:" + friendList.Count);
        }
        else
        {
            Debug.Log("No friends in ProfileObject.");
        }
            return friendList;
    }

    private bool Equals(ProfileObject profile)
    {
        return this.id == profile.id;
    }
}

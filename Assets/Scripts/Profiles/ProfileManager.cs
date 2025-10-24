using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    [SerializeField] private ProfileObject playerProfile;
    [SerializeField] private ProfileObject victimProfile;
    [SerializeField] private ProfileObject criminalProfile;
    [SerializeField] private SuspectProfile[] suspectProfiles;

    public ProfileObject PlayerProfile { get => playerProfile; private set => playerProfile = value; }
    public ProfileObject VictimProfile { get => victimProfile; private set => victimProfile = value; }
    public ProfileObject CriminalProfile { get => criminalProfile; private set => criminalProfile = value; }

    private void Awake()
    {
        SetSuspects();
    }

    public ProfileObject GetProfileByTypeAndId(ProfileRole profileRole, int userId)
    {
        if (profileRole.Equals(ProfileRole.Player))
        {
            return PlayerProfile;
        }
        else if (profileRole.Equals(ProfileRole.Victim))
        {
            return VictimProfile;
        }
        else if (profileRole.Equals(ProfileRole.Suspect))
        {
            return GetSuspectById(userId);
        }
        else {
            throw new System.Exception("Profile role " + profileRole + " does not exist.");
        }
    }

    private void SetSuspects()
    {
         suspectProfiles = gameObject.GetComponentsInChildren<SuspectProfile>();
    }

    public ProfileObject[] GetSuspects()
    {
        return suspectProfiles;
    }

    public SuspectProfile GetSuspectById(int id)
    {
        for (int i = 0; i < suspectProfiles.Length; i++)
        {
            if(id == suspectProfiles[i].Id)
            {
                return (suspectProfiles[i]);
            }
            else
            {
                throw new System.Exception(" SuspectProfile of id " + id + " does not exist.");
            }
        }
        return null;
    }

    public List<ProfileObject> GetAllNonPlayableProfiles()
    {
        List<ProfileObject> NonPlayableProfiles = new();
        NonPlayableProfiles.Add(VictimProfile);
        foreach (var item in suspectProfiles)
        {
            NonPlayableProfiles.Add(item);
        }
        return NonPlayableProfiles;
    }

    public bool IsCriminal(ProfileObject userProfile)
    {
        return criminalProfile.Equals(userProfile);
    }

    public bool IsCriminal(SuspectProfile userProfile)
    {
        return userProfile.IsCriminal;
    }

}

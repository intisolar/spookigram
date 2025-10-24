using UnityEngine;

public class SuspectProfile : ProfileObject
{
    [SerializeField] private bool isCriminal;

    public bool IsCriminal { get => isCriminal; set => isCriminal = value; }
}

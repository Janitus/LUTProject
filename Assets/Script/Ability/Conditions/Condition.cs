using UnityEngine;

public abstract class Condition : ScriptableObject
{
    public abstract bool IsMet ( Character character );
}

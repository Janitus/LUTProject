using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public int maximumLevel;
    [HideInInspector] public int currentLevel = 0; 

    public virtual void Apply(Player player) {}
}

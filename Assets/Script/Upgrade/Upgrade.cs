using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public Sprite icon;
    public int maximumLevel;
    [HideInInspector] public int currentLevel = 0;
    protected Player player;

    public void Initialize() {
        this.player = Player.instance;
    }

    public void Apply() {
        currentLevel++;
        HandleApply ();
    }

    protected virtual void HandleApply() {}

    public virtual string GetDescription () => "";
}

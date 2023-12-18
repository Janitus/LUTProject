using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDebugger : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = Player.instance;
        Debug.Log ("REMOVE ME IF NOT USED!");
        Debug.Log (player.transform.GetChild (0).name);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Vector2 playerInput;
    public static Player instance;

    protected override void Awake () {
        base.Awake ();
        instance = this;
    }

    private void Update () {
        playerInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
        Move (playerInput);
    }
}

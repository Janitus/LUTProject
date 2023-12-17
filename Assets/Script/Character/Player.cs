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

    protected override void Update () {
        base.Update ();
        ReadKeyboard ();
        ReadMouse ();
        SetSpriteDirection ();
        ConstraintPlayerToPlayArea ();
    }
    private void ReadKeyboard () {
        playerInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
        Move (playerInput);
    }

    private void ReadMouse () {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        aim = worldPosition - (Vector2)transform.position;

        if (Input.GetMouseButton (0)) abilities[0].Activate ();
        if (Input.GetMouseButton (1)) abilities[1].Activate ();
    }

    private void ConstraintPlayerToPlayArea() {
        float minX = -20;
        float maxX = 20;
        float minY = -12.5f;
        float maxY = 12.5f;

        float clampedX = Mathf.Clamp (transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp (transform.position.y, minY, maxY);
        transform.position = new Vector3 (clampedX, clampedY, transform.position.z);
    }
}

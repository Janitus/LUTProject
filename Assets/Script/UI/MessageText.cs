using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageText : MonoBehaviour
{
    public static MessageText instance;
    private FadeInTransition fade;
    private TextMeshProUGUI tmp;
    void Start()
    {
        fade = GetComponent<FadeInTransition>();
        tmp = GetComponent<TextMeshProUGUI> ();
        instance = this;
    }

    public void DisplayMessage ( string message, float fadeTimer = 2f ) {
        tmp.text = message;
        fade.StartFadeIn (fadeTimer);
    }
}

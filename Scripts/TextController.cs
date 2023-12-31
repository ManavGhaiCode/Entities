using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {
    public TMP_Text txt;

    public void SetText(string str) {
        txt.text = str;
    }
}
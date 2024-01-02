using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image image;
    public Sprite[] Sprites;

    private int CurrentSprite = 0;

    public void AddHealth(int Amount) {
        CurrentSprite -= Amount;

        if (CurrentSprite < 0) {
            CurrentSprite = 0;
        }

        image.sprite = Sprites[CurrentSprite];
    }

    public void RemoveHealth(int Amount) {
        CurrentSprite += Amount;

        if (CurrentSprite == Sprites.Length) {
            CurrentSprite = 0;
        }

        image.sprite = Sprites[CurrentSprite];
    }
}
/*
 * Gerard Lamoureux
 * PenguinSlidingUI
 * Team Project 1
 * Handles UI for Penguin Sprite
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PenguinSlidingUI : MonoBehaviour, IPlayerObserver
{
    Image image;
    public Sprite walkingSprite;
    public Sprite slidingSprite;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        PlayerController.ThisPlayerController.RegisterPlayerObserver(this);
    }

    public void UpdateData(PlayerData pd)
    {
        if (pd.IsPlayerSliding)
            image.sprite = slidingSprite;
        else
            image.sprite = walkingSprite;
    }
}

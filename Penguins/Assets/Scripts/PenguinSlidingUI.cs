using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PenguinSlidingUI : MonoBehaviour, IPlayerObserver
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        PlayerController.ThisPlayerController.RegisterPlayerObserver(this);
    }

    public void UpdateData(PlayerData pd)
    {
        if (pd.IsPlayerSliding)
            text.text = "Sliding (Placeholder)";
        else
            text.text = "Walking (Placeholder)";
    }
}

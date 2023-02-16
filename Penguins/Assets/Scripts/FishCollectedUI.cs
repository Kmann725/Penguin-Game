using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishCollectedUI : MonoBehaviour, IPlayerObserver
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        PlayerController.ThisPlayerController.RegisterPlayerObserver(this);
    }

    public void UpdateData(PlayerData pd)
    {
        text.text = "Fish Collected: " + pd.FishCollected;
    }
}

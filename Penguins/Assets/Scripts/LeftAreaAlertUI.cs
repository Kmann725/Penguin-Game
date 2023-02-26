/*
 * Gerard Lamoureux
 * LeftAreaAlertUI
 * Team Project 1
 * Handles UI when player leaves playable area
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftAreaAlertUI : MonoBehaviour, IPlayerObserver
{
    TextMeshProUGUI text;

    Coroutine showAlertCoroutine;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.ThisPlayerController.RegisterPlayerObserver(this);

    }

    public void UpdateData(PlayerData pd)
    {
        if (!pd.IsPlayerTeleporting)
            return;
        if (showAlertCoroutine != null)
            StopCoroutine(showAlertCoroutine);
        showAlertCoroutine = StartCoroutine(ShowAlertCoroutine());
    }

    IEnumerator ShowAlertCoroutine()
    {
        text.text = "You have left the map and have been teleported to Spawn!";
        yield return new WaitForSeconds(3);
        text.text = "";
        showAlertCoroutine = null;
    }
}

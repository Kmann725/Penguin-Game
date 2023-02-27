using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinBuffUI : MonoBehaviour, IPlayerObserver
{
    Image image;
    RectTransform rectTransform;
    Vector2 ogPosition;
    Coroutine showBuffRoutine;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ogPosition = rectTransform.anchoredPosition;
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    private void Start()
    {
        PlayerController.ThisPlayerController.RegisterPlayerObserver(this);
    }

    public void UpdateData(PlayerData data)
    {
        if(data.PlayerSpeedBuffed)
        {
            if (showBuffRoutine != null)
                StopCoroutine(showBuffRoutine);
            showBuffRoutine = StartCoroutine(ShowBuffRoutine());
        }
    }

    private IEnumerator ShowBuffRoutine()
    {
        rectTransform.anchoredPosition = ogPosition;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        float time = 1;
        while (time > 0)
        {
            yield return new WaitForFixedUpdate();
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + Time.deltaTime * 60);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime);
            time -= Time.deltaTime;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}

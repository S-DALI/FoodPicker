using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimate : MonoBehaviour
{
    [SerializeField] private float floatDuration = 1f;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float floatingHeight = 1f;

    private TMP_Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        Vector3 startPos = transform.position;

        float elapsedTime = 0f;
        while (elapsedTime < floatDuration)
        {
            float newYPos = Mathf.Lerp(startPos.y, startPos.y + floatingHeight, elapsedTime / floatDuration);
            transform.position = new Vector3(startPos.x, newYPos, startPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        float fadeElapsedTime = 0f;
        while (fadeElapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, fadeElapsedTime / fadeDuration);
            Color newColor = textComponent.color;
            newColor.a = alpha;
            textComponent.color = newColor;
            fadeElapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}

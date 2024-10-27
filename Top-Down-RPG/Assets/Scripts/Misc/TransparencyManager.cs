using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparencyManager : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparency = 0.8f;
    [SerializeField] private float fadeDuration = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (spriteRenderer) StartCoroutine(FadeTo(spriteRenderer, fadeDuration, spriteRenderer.color.a, transparency));
            if (tilemap) StartCoroutine(FadeTo(tilemap, fadeDuration, tilemap.color.a, transparency));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (spriteRenderer) StartCoroutine(FadeTo(spriteRenderer, fadeDuration, spriteRenderer.color.a, 1));
            if (tilemap) StartCoroutine(FadeTo(tilemap, fadeDuration, tilemap.color.a, 1));
        }
    }

    private IEnumerator FadeTo(SpriteRenderer spriteRenderer, float duration, float start, float end)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, time / duration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeTo(Tilemap tilemap, float duration, float start, float end)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, time / duration);
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, alpha);
            yield return null;
        }
    }
}

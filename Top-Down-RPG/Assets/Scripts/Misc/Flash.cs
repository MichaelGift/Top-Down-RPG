using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float flashDuration = 0.1f;

    private Material defaultMat;
    private SpriteRenderer spriteRenderer;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
    }

    public IEnumerator FlashWhite(){
        spriteRenderer.material = whiteFlashMat;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = defaultMat;
    }
}

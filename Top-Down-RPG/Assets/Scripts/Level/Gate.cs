using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    [SerializeField]private float waitTime = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            UiFader.Instance.FadeToBlack();
            StartCoroutine(LoadLevel());
        }
    }

    private IEnumerator LoadLevel()
    {   
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(levelToLoad);
    }

}

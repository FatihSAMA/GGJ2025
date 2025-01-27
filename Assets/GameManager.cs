using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 

    public bool isGameOver = false;

    // public GameObject winUI;
    // public GameObject looseUI;

    public AudioSource source;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            //DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

       // winUI.SetActive(true);
    }

    public void FailGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        source.Play(); // �nce sesi �al
        StartCoroutine(LoadGameOverSceneAfterDelay(source.clip.length)); // Sesin s�resi kadar bekle
    }

    private IEnumerator LoadGameOverSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Belirtilen s�re kadar bekle
        SceneManager.LoadScene("Main"); // Sonra sahneyi y�kle
    }
}

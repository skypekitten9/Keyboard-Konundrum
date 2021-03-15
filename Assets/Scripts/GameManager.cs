using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public bool GameOver { get; private set; }
    public Color keyboardColor, playerColor;
    public float timeOut;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void Win(WinType winType)
    {
        if (GameOver == true)
        {
            Debug.Log("Game is already over!");
            return;
        }

        GameOver = true;
        switch (winType)
        {
            case WinType.Player:
                StartCoroutine(FinializeGame(playerColor));
                break;
            case WinType.Keyboard:
                StartCoroutine(FinializeGame(keyboardColor));
                break;
            default:
                break;
        }
    }

    IEnumerator FinializeGame(Color backgroundColor)
    {
        Camera.main.backgroundColor = backgroundColor;
        yield return new WaitForSeconds(timeOut);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

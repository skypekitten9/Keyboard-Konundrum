using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool GameOver { get; private set; }
    public Color keyboardColor, playerColor;
    public float timeOut;



    protected GameManager() { }


    private void Awake()
    {
    }

    private void Start()
    {
    }

    private void Update()
    {
    }


    private void OnDrawGizmos()
    {
        try
        {

        }
        catch (System.Exception) { }
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
                transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                StartCoroutine(FinializeGame(playerColor));
                break;
            case WinType.Keyboard:
                transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
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

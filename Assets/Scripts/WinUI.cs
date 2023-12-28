using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinUI : MonoBehaviour
{
    [Header("UI References :")]
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private TextMeshProUGUI uiWinnerText;

    [Header("Board Reference :")]
    [SerializeField] private Board board;

    private void Start()
    {
        board.OnWinAction += OnWinEvent;
        uiCanvas.SetActive(false);
    }

    private void OnWinEvent(Mark mark, Color color)
    {
        uiWinnerText.text = (mark == Mark.None) ? "Nobody Wins" : mark.ToString() + " Wins.";
        uiWinnerText.color = color;

        uiCanvas.SetActive(true);
        StartCoroutine(LoadSceneAfterDelay(3f));
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        board.OnWinAction -= OnWinEvent;
    }
}

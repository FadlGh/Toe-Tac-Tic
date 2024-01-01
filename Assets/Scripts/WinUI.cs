using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinUI : MonoBehaviour
{
    [Header("UI References :")]
    [SerializeField] private TextMeshProUGUI uiWinnerText;
    [SerializeField] private TextMeshProUGUI uiModeText;

    [Header("Board Reference :")]
    [SerializeField] private Board board;

    private void Start()
    {
        board.OnWinAction += OnWinEvent;
        uiWinnerText.gameObject.SetActive(false);
        uiModeText.text = ModePicker.instance.currentMode.ToString() + " Mode";
    }

    private void OnWinEvent(Mark mark, Color color)
    {
        uiWinnerText.text = (mark == Mark.None) ? "Nobody Wins" : mark.ToString() + " Wins.";
        uiWinnerText.color = color;

        uiWinnerText.gameObject.SetActive(true);
        uiModeText.gameObject.SetActive(false);
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

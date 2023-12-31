using UnityEngine;
using UnityEngine.SceneManagement;

public class ModePicker : MonoBehaviour
{
    [SerializeField] private Mode[] modes;
    public Mode currentMode;

    public static ModePicker instance;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentMode = modes[Random.Range(0, modes.Length)];

        SceneManager.sceneLoaded -= OnSceneLoaded;
        print(currentMode.ToString());
    }
}

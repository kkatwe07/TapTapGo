using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioClipManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;

    void Awake()
    {
        DontDestroyOnLoad(bgMusic.gameObject);
        bgMusic.Play();
        SceneManager.LoadScene("Game");
    }
}

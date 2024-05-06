using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => ReturnMenu());
        AudioManagerController.Instance.MusicAudioSource.Stop();
        AudioManagerController.Instance.PlaySfx(5);
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

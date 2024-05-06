using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnOptions;
    [SerializeField] private GameObject menu;
    private void Start()
    {
        AudioManagerController.Instance.PlayMusic(0);
    }
    public void Play()
    {
        AudioManagerController.Instance.SaveAudioSettings();
        SceneManager.LoadScene("Game");
    }
    public void ActiveOptions()
    {
        menu.SetActive(true);
        menu.GetComponent<Image>().raycastTarget = true;
    }
    public void DisableMenu()
    {
        menu.SetActive(false);
        menu.GetComponent<Image>().raycastTarget = false;
    }
}

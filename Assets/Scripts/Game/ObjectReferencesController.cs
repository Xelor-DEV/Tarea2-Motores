using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ObjectReferencesController : MonoBehaviour
{
    public UnityEvent OnChangeScene;
    private void Start()
    {
        OnChangeScene.Invoke();
        AudioManagerController.Instance.LoadAudioSettings();
        AudioManagerController.Instance.PlayMusic(1);
    }
    public void AssignMasterToggle(Toggle masterToggle)
    {
        AudioManagerController.Instance.MasterToggle = masterToggle;
        masterToggle.isOn = AudioManagerController.Instance.MasterToggle.isOn;
    }
    public void MuteMaster()
    {
        AudioManagerController.Instance.MuteMasterNoSlider();
    }

}

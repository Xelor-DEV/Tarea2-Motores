using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManagerController : MonoBehaviour
{
    public static AudioManagerController Instance { get; private set; }
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicConfiguration;
    [SerializeField] private Slider sfxConfiguration;
    [SerializeField] private Slider masterConfiguration;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip[] musicClipsLoop;
    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private AudioSettings audioSettings;
    [SerializeField] private Toggle masterToggle;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    public Toggle MasterToggle
    {
        get
        {
            return masterToggle;
        }
        set
        {
            masterToggle = value;
        }
    }
    public Slider MusicConfiguration
    {
        get
        {
            return musicConfiguration;
        }
        set
        {
            musicConfiguration = value;
        }
    }
    public Slider SFXConfiguration
    {
        get
        {
            return sfxConfiguration;
        }
        set
        {
            sfxConfiguration = value;
        }
    }
    public Slider MasterConfiguration
    {
        get
        {
            return masterConfiguration;
        }
        set
        {
            masterConfiguration = value;
        }
    }
    public AudioSource MusicAudioSource
    {
        get
        {
            return musicAudioSource;
        }
    }
    public AudioSource SfxAudioSource
    {
        get
        {
            return sfxAudioSource;
        }
    }
    public AudioClip[] SfxClips
    {
        get
        {
            return sfxClips;
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SaveAudioSettings()
    {
        audioSettings.musicVolume = musicConfiguration.value;
        audioSettings.sfxVolume = sfxConfiguration.value;
        audioSettings.masterVolume = masterConfiguration.value;
        audioSettings.masterMute = masterToggle.isOn;
        audioSettings.musicMute = musicToggle.isOn;
        audioSettings.sfxMute = sfxToggle.isOn;
    }
    public void LoadAudioSettings()
    {
        musicConfiguration.value = audioSettings.musicVolume;
        sfxConfiguration.value = audioSettings.sfxVolume;
        masterConfiguration.value = audioSettings.masterVolume;
        masterToggle.isOn = audioSettings.masterMute;
        musicToggle.isOn = audioSettings.musicMute;
        sfxToggle.isOn = audioSettings.sfxMute;
        SetVolumeOfMusic();
        SetVolumeOfSfx();
        SetVolumeOfMaster();
        MuteMaster();
        MuteMusic();
        MuteSfx();
    }
    public void SetVolumeOfMusic()
    {
        audioMixer.SetFloat("music", Mathf.Log10(musicConfiguration.value) * 20f);
    }
    public void SetVolumeOfSfx()
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxConfiguration.value) * 20f);
    }
    public void SetVolumeOfMaster()
    {
        audioMixer.SetFloat("master", Mathf.Log10(masterConfiguration.value) * 20f);
    }
    public void PlayMusic(int index)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = musicClipsLoop[index];
        musicAudioSource.Play();
    }
    public void PlaySfx(int index)
    {
        sfxAudioSource.PlayOneShot(sfxClips[index]);
    }
    public float GetSfxLength(int index)
    {
        return sfxClips[index].length;
    }
    public void MuteMaster()
    {
        if (masterToggle.isOn == true)
        {
            audioMixer.SetFloat("master", -80f);
        }
        else
        {
            audioMixer.SetFloat("master", Mathf.Log10(masterConfiguration.value) * 20f);
        }
    }
    public void MuteMasterNoSlider()
    {
        if (masterToggle.isOn == true)
        {
            audioMixer.SetFloat("master", -80f);
        }
        else
        {
            audioMixer.SetFloat("master", Mathf.Log10(audioSettings.masterVolume) * 20f);
        }
    }

    public void MuteMusic()
    {
        if (musicToggle.isOn == true)
        {
            audioMixer.SetFloat("music", -80f);
        }
        else
        {
            audioMixer.SetFloat("music", Mathf.Log10(musicConfiguration.value) * 20f);
        }
    }

    public void MuteSfx()
    {
        if (sfxToggle.isOn == true)
        {
            audioMixer.SetFloat("sfx", -80f);
        }
        else
        {
            audioMixer.SetFloat("sfx", Mathf.Log10(sfxConfiguration.value) * 20f);
        }
    }
}
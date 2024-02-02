using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;

    [Header("UIObjects")]
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Dropdown _qualityDropwon;

    [SerializeField] private Toggle _vsyncToggle;
    [SerializeField] private Toggle _fullscreenToggle;

    [SerializeField] private Slider _generalAudioSlider;
    [SerializeField] private Slider _generalMusicSlider;
    [SerializeField] private Slider _generalEffectSlider;

    private void OnEnable()
    {
        StartWindowSizeValue();
        LoadValues();
    }

    private void StartWindowSizeValue()
    {
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();

        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0 ; i< resolutions.Length ; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        currentResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", currentResolutionIndex);

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void LoadValues()
    {
        _qualityDropwon.value = PlayerPrefs.GetInt("qualityIndex", 3);

        _vsyncToggle.isOn = (PlayerPrefs.GetInt("isVsync", 1) == 1 ? true : false);
        _fullscreenToggle.isOn = (PlayerPrefs.GetInt("isFullscreen", 1) == 1 ? true : false);

        _generalAudioSlider.value = PlayerPrefs.GetFloat("VolumeMaster", 0);
        _generalMusicSlider.value = PlayerPrefs.GetFloat("VolumeMusic", 0);
        _generalEffectSlider.value = PlayerPrefs.GetFloat("VolumeEffect", 0);

    }

    #region ImageSettings

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
    }

    public void SetQualitty(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("isFullscreen", (isFullscreen ? 1 : 0));
    }

    public void SetVsync(bool isVsync)
    {
        QualitySettings.vSyncCount = (isVsync ? 1 : 0);
        PlayerPrefs.SetInt("isVsync", (isVsync ? 1 : 0));
    }

    #endregion

    #region AudioSettings
    [Header("AudiomMixers")]
    [SerializeField] private AudioMixer _generalMixer;
    public void SetVolumeMaster (float volume)
    {
        _generalMixer.SetFloat("VolumeMaster", volume);
        PlayerPrefs.SetFloat("VolumeMaster", volume);
    }

    public void SetVolumeEffect(float volume)
    {
        _generalMixer.SetFloat("VolumeEffect", volume);
        PlayerPrefs.SetFloat("VolumeEffect", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        _generalMixer.SetFloat("VolumeMusic", volume);
        PlayerPrefs.SetFloat("VolumeMusic", volume);
    }
    #endregion
}

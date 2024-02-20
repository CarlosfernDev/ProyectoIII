using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    [Header("UIObjects")]
    [SerializeField] private LateralSlider _resolutionSlider;

    private void OnEnable()
    {
        StartWindowSizeValue();
    }

    private void StartWindowSizeValue()
    {
        //resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();

        _resolutionSlider.TextSettings.Clear();

        _resolutionSlider.TextSettings = new List<SettingData>();

        int currentResolutionIndex = 0;
        for (int i = 0 ; i< Screen.resolutions.Length ; i++)
        {
            SettingData temporalData = new SettingData();

            string option = Screen.resolutions[i].width + " x " + Screen.resolutions[i].height + " (" + Mathf.Floor((float)Screen.resolutions[i].refreshRateRatio.value) + ") Hz";

            temporalData.Name = option;
            temporalData.ValueAction.AddListener(SetResolution);

            _resolutionSlider.TextSettings.Add(temporalData);

            if (Screen.resolutions[i].width == Screen.currentResolution.width &&
                Screen.resolutions[i].height == Screen.currentResolution.height && Screen.resolutions[i].refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                currentResolutionIndex = i;
            }
        }

        currentResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", currentResolutionIndex);
        _resolutionSlider.IndexState = currentResolutionIndex;

    }

    #region ImageSettings

    public void SetResolution()
    {
        Resolution resolution = Screen.resolutions[_resolutionSlider.IndexState];
        Screen.SetResolution(resolution.width, resolution.height, (Screen.fullScreen) ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, resolution.refreshRateRatio);
        PlayerPrefs.SetInt("resolutionIndex", _resolutionSlider.IndexState);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, (Screen.fullScreen) ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed , resolution.refreshRateRatio);
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

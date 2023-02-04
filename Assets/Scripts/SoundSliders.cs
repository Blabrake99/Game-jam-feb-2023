using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliders : MonoBehaviour
{
    public enum TargetMixer
    {
        SFX = 1,
        MUSIC,
        MASTER
    }

    public bool loadingSettingsValue;
    AudioManager manager;
    [SerializeField]
    TargetMixer mixer;
    [SerializeField]
    Slider slider;

    private void Start()
    {
        if (manager == null)
        {
            manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    private void Update()
    {
        if (manager == null)
        {
            manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    public void SetLevel(float level)
    {
        if (manager == null)
        {
            manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
        //ignore this function call if loading programmatically
        if (loadingSettingsValue)
        {
            return;
        }
        switch (mixer)
        {
            case TargetMixer.MUSIC:
                manager.setMusicVol(level);
                break;
            case TargetMixer.SFX:
                manager.setSFXVol(level);
                break;
            case TargetMixer.MASTER:
                manager.setMasterVol(level);
                break;
            default:
                Debug.LogWarning("No mixer selected for volume control");
                break;
        }
    }
    private void OnEnable()
    {
        setVolumeLevel();
    }
    public void setVolumeLevel()
    {
        if (manager == null)
        {
            manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
        loadingSettingsValue = true;
        switch (mixer)
        {
            case TargetMixer.MUSIC:
                slider.value = manager.getMusicVol();
                break;
            case TargetMixer.SFX:
                float value = manager.getSFXVol();
                slider.value = value;
                break;
            case TargetMixer.MASTER:
                slider.value = manager.getMasterVol();
                break;
            default:
                Debug.LogWarning("No mixer selected for volume control");
                break;
        }

        loadingSettingsValue = false;
    }
}

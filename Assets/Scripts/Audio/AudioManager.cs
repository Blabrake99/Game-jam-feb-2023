using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{



    AudioMixerGroup sfx;
    AudioMixerGroup music;
    AudioMixerGroup master;

    private const string musicVol = "MusicVol";
    private const string sfxVol = "SFXVol";
    private const string masterVol = "MasterVol";

    #region SFX
    [Header("-----------------------------------------------------------------------------------------------------")]
    [Header("OneShots")]
    [Header("-----------------------------------------------------------------------------------------------------")]
    [SerializeField] GameObject jump;
    [SerializeField] GameObject flamerthrower;


    #endregion

    [Header("-----------------------------------------------------------------------------------------------------")]
    [Header("Ambience")]
    [Header("-----------------------------------------------------------------------------------------------------")]

    #region Ambience
    [SerializeField] GameObject RustlingLeaves;

    [Header("-----------------------------------------------------------------------------------------------------")]
    [Header("Music")]
    [Header("-----------------------------------------------------------------------------------------------------")]
    [SerializeField] GameObject CoolCPU;
    [SerializeField] GameObject GoingSomewhere;
    [SerializeField] GameObject BossCPU;

    private AudioSource currentBGM;


    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(this);


        AudioMixer mixer = Resources.Load("Mixer") as AudioMixer;


        if (mixer != null)
        {
            //only one of each group will be found, it just likes to return an array
            sfx = mixer.FindMatchingGroups("SFX")[0];
            music = mixer.FindMatchingGroups("BGM")[0];
            master = mixer.FindMatchingGroups("Master")[0];



        }
        else
        {
            Debug.LogError("Error Sound Mixer was not loaded properly");
        }

    }


    #region UI_INTERACTION
    public void setSFXVol(float value)
    {

        sfx.audioMixer.SetFloat(sfxVol, Mathf.Log10(value) * 20);
    }

    public void setMusicVol(float value)
    {
        music.audioMixer.SetFloat(musicVol, Mathf.Log10(value) * 20);
    }

    public void setMasterVol(float value)
    {
        master.audioMixer.SetFloat(masterVol, Mathf.Log10(value) * 20);
    }

    public float getSFXVol()
    {

        sfx.audioMixer.GetFloat(sfxVol, out float val);
        val = Mathf.Pow(10, val / 20);
        if (val <= 0 || val > 1)
        {
            return 0.5f;
        }
        return val;
    }

    public float getMusicVol()
    {
        music.audioMixer.GetFloat(musicVol, out float val);
        val = Mathf.Pow(10, val / 20);
        if (val <= 0 || val > 1)
        {
            return 0.5f;
        }
        return val;
    }

    public float getMasterVol()
    {
        master.audioMixer.GetFloat(masterVol, out float val);
        val = Mathf.Pow(10, val / 20);
        if (val <= 0 || val > 1)
        {
            return 0.5f;
        }
        return val;
    }

    #endregion

    #region play_functions
    public void playJump()
    {
        jump.GetComponent<AudioSource>().Play();
    }

    public void playGoingSomewhere()
    {
        AudioSource song = GoingSomewhere.GetComponent<AudioSource>();

        if (currentBGM != null && currentBGM != song)
        {
            currentBGM.Stop();
        }
        if (song.isPlaying)
            return;
        song.loop = true;
        song.Play();
        currentBGM = song;
    }


    public void playWindLeaves()
    {
        AudioSource song = RustlingLeaves.GetComponent<AudioSource>();
        song.loop = true;
        song.Play();
    }

    public void playFlamethrower()
    { 
        AudioSource flame = this.flamerthrower.GetComponent<AudioSource>();
        if (flame.isPlaying)
            return;
        flame.loop = true;
        flame.Play();
    }

    public void stopFlamethrower()
    {
        AudioSource flame = this.flamerthrower.GetComponent<AudioSource>();
        flame.loop = true;
        flame.Stop();
    }

    public void playBossTheme()
    {
        AudioSource boss = BossCPU.GetComponent<AudioSource>();
        if (currentBGM != null && currentBGM != boss)
        {
            currentBGM.Stop();
        }
      

        if (boss.isPlaying)
            return;
        boss.loop = true;
        boss.Play();
        currentBGM = boss;
    }
    #endregion

}






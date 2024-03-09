using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            //Instance = this;
            //DontDestroyOnLoad(gameObject);
            SetupAudioManager();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetupAudioManager()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public AudioSource menuMusic, bossMusic, levelCompleteMusic;
    public AudioSource[] levelTracks;

    public AudioSource[] allSFX;

    void StopMusic()
    {
        menuMusic.Stop();
        bossMusic.Stop();
        levelCompleteMusic.Stop();

        foreach (AudioSource track in levelTracks)
        {
            track.Stop();
        }
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }
    public void PlayBossMusic()
    {
        StopMusic();
        bossMusic.Play();
    }
    public void PlayLevelCompeleteMusic()
    {
        StopMusic();
        levelCompleteMusic.Play();
    }

    public void PlayLevelMusic(int TrackToPlay)
    {
        StopMusic();
        levelTracks[TrackToPlay].Play();
    }

    public void PLaySFX(int SFXToPlay)
    {
        allSFX[SFXToPlay].Stop();
        allSFX[SFXToPlay].Play();
    }

    public void PlaySFXpitched(int sfxToPlay)
    {
        allSFX[sfxToPlay].Stop();

        allSFX[sfxToPlay].pitch = Random.Range(.75f, 1.25f);

        allSFX[sfxToPlay].Play();
    }
}

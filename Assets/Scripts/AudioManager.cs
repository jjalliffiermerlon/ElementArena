using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //------------------------------------------------Singleton------------------------------------------------------
    public static AudioManager AudioManagerInstance{ get; private set; }

    //---------------------------------------------------Fields--------------------------------------------------------
    //------Musics------
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] playModeMusicsClips;
    [SerializeField] private AudioClip menuMusicClip;
    [SerializeField] private AudioClip pauseMusicClip;
    [SerializeField] private AudioClip endGameMusicClip;

    //------UI Sound------
    [SerializeField] private AudioSource menuSource;
    [SerializeField] private AudioClip menuMoveClip;
    [SerializeField] private AudioClip menuChoiceClip;
    [SerializeField] private AudioClip menuCancelClip;
    [SerializeField] private AudioClip[] playerJoinClips;
    [SerializeField] private AudioClip startGameClip;

    //------Round Manager Sound------
    [SerializeField] private AudioClip CounterClip;
    [SerializeField] private AudioClip goClip;
    [SerializeField] private AudioClip playAreaReduceAlertClip;

    //------Player------
    [SerializeField] private AudioSource deathSource;
    [SerializeField] private AudioSource punchHitSource;
    [SerializeField] private AudioSource punchMissSource;
    [SerializeField] private AudioSource walkSoundSource;

    //------Elements------
    //Fireball
    [SerializeField] private AudioSource fireBallLaunchSource;
    [SerializeField] private AudioSource fireballHitSource;
    //WindDash
    [SerializeField] private AudioSource windDashSource;
    //Combo wind and fire
    [SerializeField] private AudioSource fireDashSource;
    [SerializeField] private AudioSource flameFireDashSource;

    //------Crate------
    [SerializeField] private AudioSource crateDestroySource;

    //------Element Spawner------
    [SerializeField] private AudioSource elementPickedUpSource;
    [SerializeField] private AudioSource elementSpawnedSource;

    //------------------------------------------------------Methods------------------------------------------------------
    //------Musics------
    public void playMusic(string kind)//Play -> Play Music, Menu-> Main menu Music, Pause -> Pause Music, End-> End of the game
    {
        if(kind == "Play")
        {
            musicSource.Stop();
            int random = Random.Range(0,playModeMusicsClips.Length-1);
            musicSource.clip = playModeMusicsClips[random];
            musicSource.Play();

        }else if (kind == "Menu")
        {
            musicSource.Stop();
            musicSource.clip = menuMusicClip;
            musicSource.Play();

        }else if (kind == "Pause")
        {
            musicSource.Stop();
            musicSource.clip = pauseMusicClip;
            musicSource.Play();
        }else if(kind == "End")
        {
            musicSource.Stop();
            musicSource.clip = endGameMusicClip;
            musicSource.Play();
        }
    }

    //------UISounds------
    public void playMenuSound(string kind)//Move,Choice,Cancel,Join, Start
    {
        if(kind == "Move")
        {
            menuSource.Stop();
            menuSource.clip = menuMoveClip;
            menuSource.Play();
        }else if (kind == "Choice"){
            menuSource.Stop();
            menuSource.clip = menuChoiceClip;
            menuSource.Play();
        }else if(kind == "Cancel")
        {
            menuSource.Stop();
            menuSource.clip = menuCancelClip;
            menuSource.Play();
        }else if(kind == "Join")
        {
            menuSource.Stop();
            int random = Random.Range(0, playerJoinClips.Length - 1);
            menuSource.clip = playerJoinClips[random];
            musicSource.Play();
        }else if(kind == "Start")
        {
            menuSource.Stop();
            menuSource.clip = startGameClip;
            musicSource.Play();
        }
    }

    //------RoundManager------
    public void playRoundManagerSound (string kind)//Count, Go, Area
    {
        if(kind == "Count")
        {
            menuSource.Stop();
            menuSource.clip = CounterClip;
            musicSource.Play();
        }else if (kind == "Go")
        {
            menuSource.Stop();
            menuSource.clip = goClip;
            menuSource.Play();
        }else if (kind == "Area")
        {
            menuSource.Stop();
            menuSource.clip = playAreaReduceAlertClip;
            menuSource.Play();
        }
    }

    //------Player------
    public void playDeathSound()
    {
        deathSource.Play();
    }

    public void playPuchHitSound()
    {
        punchHitSource.Play();
    }

    public void playPuchMissSound()
    {
        punchMissSource.Play();
    }

    public void playWalkSound()
    {
        walkSoundSource.Play();
    }

    public void stopWalkSound()
    {
        walkSoundSource.Stop();
    }

    //-----Elements------
    //Fireball
    public void playFireballLaunch()
    {
        fireBallLaunchSource.Play();
    }
    
    public void playFireballHit()
    {
        fireballHitSource.Play();
    }

    //Wind Dash
    public void playWindDash()
    {
        windDashSource.Play();
    }

    //FireDash
    public void playFireDash()
    {
        windDashSource.Play();
    }
    public void playFireDashFlame()
    {
        flameFireDashSource.Play();
    }
    public void stopFireDashFlame()
    {
        flameFireDashSource.Stop();
    }

    //------Crate------
    public void crateDestructionSource()
    {
        crateDestroySource.Play();
    }

    //------Element spawner-----
    public void playElementPickedUp()
    {
        elementPickedUpSource.Play();
    }
    public void playElementSpawned()
    {
        elementSpawnedSource.Play();
    }

    //-------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        if (AudioManagerInstance != null && AudioManagerInstance != this)
        {
            Destroy(this);
            return;
        }
        AudioManagerInstance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip background, enemydeath, enemyhit, hitplayer, Obsdestroyed, pickup, playershoot, enemyshoot; //audio flies
    static AudioSource audiosrc; // gets audio source
   
    // Start is called before the first frame update
    void Start()
    {
        background = Resources.Load<AudioClip>("background"); //sets background to background audio file
        enemydeath = Resources.Load<AudioClip>("enemydeath"); // sets enemydeath to enemydeath audio file
        enemyhit = Resources.Load<AudioClip>("enemyhit"); // sets enemyhit to enemyhit audio file
        hitplayer = Resources.Load<AudioClip>("hitplayer"); // sets hitplayer to hitplayer audio file
        Obsdestroyed = Resources.Load<AudioClip>("Obsdestroyed"); // sets Obsdestroyed to Obsdestroyed audio file
        pickup = Resources.Load<AudioClip>("pickup"); // sets pickup to pickup audio file
        playershoot = Resources.Load<AudioClip>("playershoot"); // sets Playershoot to playershoot audio file
        enemyshoot = Resources.Load<AudioClip>("enemyshoot"); // sets enemyshoot to enemyshoot audio file

        audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case"background": audiosrc.PlayOneShot(background);
                break;
            case "enemydeath":
                audiosrc.PlayOneShot(enemydeath);
                break;
            case "enemyhit":
                audiosrc.PlayOneShot(enemyhit);
                break;
            case "hitplayer":
                audiosrc.PlayOneShot(hitplayer);
                break;
            case "Obsdestroyed":
                audiosrc.PlayOneShot(Obsdestroyed);
                break;
            case "pickup":
                audiosrc.PlayOneShot(pickup);
                break;
            case "playershoot":
                audiosrc.PlayOneShot(playershoot);
                break;
            case "enemyshoot":
                audiosrc.PlayOneShot(enemyshoot);
                break;
        }

    }
}

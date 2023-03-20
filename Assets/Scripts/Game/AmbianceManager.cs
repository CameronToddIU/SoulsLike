using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32;
using UnityEngine;

public class AmbianceManager : MonoBehaviour
{
    public static AmbianceManager instance;

    public static AudioSource defaultAmbiance;
    public AudioSource aSource;

    private static bool fadeInstanceActive;

    private static bool isDefaultMusic;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        defaultAmbiance = aSource;
        defaultAmbiance.volume = 0.03f;
        defaultAmbiance.Play();
        isDefaultMusic = true;
        fadeInstanceActive = false;
    }

    public static void SwapTrack(AudioSource newClip, bool withinRange)
    {
        if(!fadeInstanceActive && withinRange)
        {
            instance.StartCoroutine(FadeTrack(newClip, withinRange));
        } else if (!withinRange)
        {
            instance.StartCoroutine(FadeTrack(newClip, false));
        }
    }

        public static IEnumerator FadeTrack(AudioSource newClip, bool withinRange)
        {
            fadeInstanceActive = true;
            float timeToFade = 1.25f;
            float timeElapsed = 0;

            if (withinRange)
            {
                if (isDefaultMusic)
                {
                    newClip.Play();

                    while (timeElapsed < timeToFade)
                    {
                        newClip.volume = Mathf.Lerp(0f, 0.03f, timeElapsed / timeToFade);
                        defaultAmbiance.volume = Mathf.Lerp(0.03f, 0f, timeElapsed / timeToFade);
                        timeElapsed += Time.deltaTime;
                        yield return null;
                    }

                    defaultAmbiance.Stop();
                    isDefaultMusic = false;
                }

            }
            else
            {
                if (!isDefaultMusic)
                {
                    defaultAmbiance.Play();

                    while (timeElapsed < timeToFade)
                    {
                        defaultAmbiance.volume = Mathf.Lerp(0f, 0.03f, timeElapsed / timeToFade);
                        newClip.volume = Mathf.Lerp(0.03f, 0f, timeElapsed / timeToFade);
                        timeElapsed += Time.deltaTime;
                        yield return null;
                    }

                    newClip.Stop();
                    isDefaultMusic = true;
                }
            }
        }
    
}

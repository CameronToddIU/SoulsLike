using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup diedBackgroundImageCanvasGroup;
    public AudioSource diedAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerDead;
    float m_Timer;
    bool m_HasAudioPlayed;
    bool m_IsBossDead;

    public void PlayerEnteredEnd()
    {      
        m_IsPlayerAtExit = true;
    }
    public void BossDied()
    {
        m_IsBossDead = true;
    }

    public void PlayerDied()
    {
        m_IsPlayerDead = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit || m_IsBossDead)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerDead)
        {
            EndLevel(diedBackgroundImageCanvasGroup, true, diedAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (m_IsPlayerDead)
            {
                SceneManager.LoadScene(2);
            }
            else if (m_IsPlayerAtExit)
            {
                SceneManager.LoadScene(3);
            }
            else if (m_IsBossDead)
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
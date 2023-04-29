using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    public AudioSource BMusic;
    public GameObject camCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        AmbianceManager.SwapTrack(BMusic, true);
        camCollider.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        public GameObject closedDoor;
        public GameObject openDoor;

        public AudioSource doorOpen;
        public AudioSource doorClose;

        private Color curColor;
        private Color targetColor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            openDoor.SetActive(true);
            closedDoor.SetActive(false);
            doorOpen.Play();
        }

        //private void OnTriggerExit2D(Collider2D other)
        /*{
            targetColor = new Color(1, 1, 1, 0);
            openDoor.SetActive(false);
            closedDoor.SetActive(true);
            doorClose.Play();
        }*/

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}

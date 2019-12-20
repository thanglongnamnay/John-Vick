using System.Collections;
using UnityEngine;

namespace Controller {
    public class AudioController : MonoBehaviour {
        public static AudioController instance;
        public AudioClip reload;

        private AudioSource _source;

        public AudioController() {
            instance = this;
        }

        private void OnEnable() {
            _source = GetComponent<AudioSource>();
        }

        public void play(AudioClip clip, float duration, float after = 0) {
            StartCoroutine(startPlay(clip, after));
            StartCoroutine(stopPlay(after + duration));
        }

        private IEnumerator startPlay(AudioClip clip, float after) {
            yield return new WaitForSeconds(after);
            _source.pitch = Time.timeScale;
            _source.PlayOneShot(clip);
        }
        private IEnumerator stopPlay(float after) {
            yield return new WaitForSeconds(after);
            _source.Stop();
        }
    }
}
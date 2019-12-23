using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller {
    public class ToggleLight : MonoBehaviour {
        public float interval = 1;

        private float _lastTime = 0;
        private Light[] _lights;
        private float[] _lightIntensities;

        private void Start() {
            _lights = GetComponentsInChildren<Light>();
            _lightIntensities = _lights.Select(l => l.intensity).ToArray();
        }

        private void Update() {
            if (Time.time - _lastTime < interval) return;
            _lastTime = Time.time;
            Debug.Log("start toggle: " + Time.time);
            StartCoroutine(toggle(Random.value));
        }

        private IEnumerator toggle(float value) {
            if (value > .3f) {
                StartCoroutine(toggle(Random.value));
            }

            var index0 = Random.Range(0, _lights.Length);
            var light1 = _lights[index0];
            light1.intensity = .1f;
            Debug.Log("turn off 1 light");
            yield return restoreLight(light1, index0);

            if (value > .5f) {
                yield return new WaitForSeconds(.1f);
                light1.intensity = .1f;
                yield return restoreLight(light1, index0);
            }
        }

        private IEnumerator restoreLight(Light light1, int lastIntensity) {
            yield return new WaitForSeconds(.1f);
            light1.intensity = _lightIntensities[lastIntensity];
        }
    }
}
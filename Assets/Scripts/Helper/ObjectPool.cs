using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Helper {
    [Serializable]
    public class ObjectPoolItem {
        private GameObject[] _pool;

        private int _currentGameObjectIndex;
	
        public int initialPoolSize = 1;
        public GameObject poolObject;
        public ObjectPool objectPool { get; set; }

        private const float ExtendFactor = 2;
        public void setPoolObject(GameObject value) {
            poolObject = value;
            _pool = new GameObject[initialPoolSize];
            for (int i = 0; i < initialPoolSize; ++i) {
                _pool[i] = Object.Instantiate(poolObject);
            }
            _currentGameObjectIndex = 0;
        }
        public GameObject getGameObject(Vector3 position, Quaternion rotation) {
            GameObject r = _pool[_currentGameObjectIndex];
            if (r.activeSelf) {
                for (int i = 0; i < _pool.Length; ++i) {
                    if (!_pool[i].activeSelf) {
                        _currentGameObjectIndex = i;
                    }
                }
                extendPool();
            }
            r = _pool[_currentGameObjectIndex];
            r.transform.position = position;
            r.transform.rotation = rotation;
            r.SetActive(true);
            _currentGameObjectIndex = (_currentGameObjectIndex + 1) % _pool.Length;
            return r;
        }
        private void extendPool() {
            int newSize = (int) (_pool.Length * ExtendFactor);
            _currentGameObjectIndex = _pool.Length;
            Array.Resize(ref _pool, newSize);
            for (int i = _currentGameObjectIndex; i < newSize; ++i) {
                _pool[i] = Object.Instantiate(poolObject);
            }
            Debug.Log(poolObject.name + " extended to: " + _pool.Length);
        }


    }
    public class ObjectPool : MonoBehaviour {
        public static ObjectPool sharedInstant;
        public List<ObjectPoolItem> poolObjects;

        private void Awake() {
            sharedInstant = this;
            foreach (ObjectPoolItem item in poolObjects) {
                item.objectPool = this;
                item.setPoolObject(item.poolObject);
            }
        }

        public GameObject getGameObject(string objectName, Vector3 position, Quaternion rotation) {
            return poolObjects.First(p => p.poolObject.name == objectName).getGameObject(position, rotation);
        }
    }
}
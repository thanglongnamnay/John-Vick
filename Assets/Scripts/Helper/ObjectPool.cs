using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Helper {
    [Serializable]
    public class ObjectPoolItem {
        private List<GameObject> _pool;

        private int _currentGameObjectIndex;
	
        public int initialPoolSize;
        public GameObject poolObject;
        public ObjectPool objectPool { get; set; }

        public void setPoolObject(GameObject value) {
            poolObject = value;
            _pool = new List<GameObject>();
            for (var i = 0; i < initialPoolSize; ++i) {
                var gameObject = Object.Instantiate(poolObject);
                gameObject.SetActive(false);
                _pool.Add(gameObject);
            }
            _currentGameObjectIndex = 0;
        }
        public GameObject getGameObject(Vector3 position, Quaternion rotation) {
            GameObject r = _pool[_currentGameObjectIndex];
            if (r.activeSelf) {
                for (var i = 0; i < _pool.Count; ++i) {
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
            _currentGameObjectIndex = (_currentGameObjectIndex + 1) % _pool.Count;
            return r;
        }
        private void extendPool() {
            _currentGameObjectIndex = _pool.Count;
            _pool.Add(Object.Instantiate(poolObject));
        }


    }
    public class ObjectPool : MonoBehaviour {
        public static ObjectPool instance;
        private static int _code;
        
        public List<ObjectPoolItem> poolObjects;
        private Dictionary<int, Func<ObjectPoolItem, bool>> hashFuncs = new Dictionary<int, Func<ObjectPoolItem, bool>>();
        private Dictionary<string, int> hashNames = new Dictionary<string, int>();

        public ObjectPool() {
            instance = this;
        }

        private void Awake() {
            foreach (ObjectPoolItem item in poolObjects) {
                item.objectPool = this;
                item.setPoolObject(item.poolObject);
            }
        }

        public GameObject getGameObject(string objectName, Vector3 position, Quaternion rotation) {
            if (!hashNames.ContainsKey(objectName)) {
                hash(objectName);
            }
            return getGameObject(hashNames[objectName], position, rotation);
        }

        private void hash(string objectName) {
            hashNames[objectName] = ++_code;
            hashFuncs[_code] = p => p.poolObject.name == objectName;
        }

        private GameObject getGameObject(int objectHash, Vector3 position, Quaternion rotation) {
            return poolObjects.First(hashFuncs[objectHash]).getGameObject(position, rotation);
        }
    }
}
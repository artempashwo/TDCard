using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TD.Enemies {
    public class ObjectPooling : MonoBehaviour {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int poolSize = 10;
        [SerializeField]private Vector3 startPooling;
        private List<GameObject> poolList;
        private GameObject poolContainer;

        private void Awake() {
            poolList = new List<GameObject>(poolSize);
            poolContainer = new GameObject($"Pool - {prefab.name}");
            CreatePoller();
        }

        private void Start() {
            poolContainer.transform.position = startPooling;
        }

        private void CreatePoller() {
            for (var i = 0; i < poolSize; i++) {
                poolList.Add(CreateInstance());
            }
        }

        private GameObject CreateInstance() {
            var newInstance = Instantiate(prefab, poolContainer.transform, true);
            newInstance.SetActive(false);
            return newInstance;
        }

        public GameObject GetInstanceFromPool() {
            foreach (var t in poolList.Where(t => !t.activeInHierarchy)) {
                return t;
            }

            return CreateInstance();
        }
        
        public static IEnumerator ReturnToPoolWithDelay(GameObject instance, float delay) {
            yield return new WaitForSeconds(delay);
            instance.SetActive(false);
        }
        
        public static void ReturnToPool(GameObject instance) => instance.SetActive(false);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Baits {
	public class Spawner : MonoBehaviour {
		[SerializeField] private GameObject baitPrefab;
		[SerializeField] private Vector2Int terrainSize;
		[SerializeField] private List<EatenEvent> baitList;
		[SerializeField] private int mapBaitsLimit = 100;
		[SerializeField] private float baitRegenSeconds = 1f;
		[SerializeField] private Coroutine _regenCoroutine;

		private void Awake() {
			SpawnAllBaits();
		}

		private void Start() {
			_regenCoroutine = StartCoroutine(BaitsRegen());
		}

		private void SpawnAllBaits() {
			for (int i = 0; i < mapBaitsLimit; i++) {
				BaitsSpawner();
			}
		}

		private void BaitsSpawner() {
			float randX = UnityEngine.Random.Range(0f, terrainSize.x);
			float randZ = UnityEngine.Random.Range(0f, terrainSize.y);

			Vector3 newBaitPos = new Vector3(randX, 0.2f, randZ);

			GameObject baitObject = Instantiate(baitPrefab, newBaitPos, Quaternion.identity, transform);
			Baits.EatenEvent bait = baitObject.GetComponent<EatenEvent>();
			baitList.Add(bait);
			bait.baitListReference = baitList;
			bait.eventHandler += bait.OnEatenAction;
		}

		private IEnumerator BaitsRegen() {
			while (true) {
				if (baitList.Count < mapBaitsLimit) {
					BaitsSpawner();
				}
				yield return new WaitForSeconds(baitRegenSeconds);
			}
		}
	}
}

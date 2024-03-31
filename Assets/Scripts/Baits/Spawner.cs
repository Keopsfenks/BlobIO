using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Baits {
	public class Spawner : MonoBehaviour {
		[SerializeField] private GameObject baitPrefab;
		[SerializeField] private Vector2Int terrainSize;
		[SerializeField] private List<Event> baitList;
		[SerializeField] private int mapBaitsLimit = 100;

		private void Awake() {
			SpawnAllBaits();
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

			GameObject bait = Instantiate(baitPrefab, newBaitPos, Quaternion.identity, transform);
			Baits.Event tmpEvent = bait.GetComponent<Event>();

			baitList.Add(tmpEvent);
		}
	}
}

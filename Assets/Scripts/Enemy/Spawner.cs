using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
	public class Spawner : MonoBehaviour {
		[SerializeField] private int mapEnemyLimit = 1;
		[SerializeField] private List<GameObject> enemyPrefabs;
		[SerializeField] private List<GameObject> enemyList;
		[SerializeField] private Vector2Int terrainSize;

		private void Awake() {
			SpawnEnemy();
		}

		private GameObject CreateEnemyAttr(Vector3 enemyPos) {
			GameObject enemy = Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)],
				enemyPos, Quaternion.identity, transform);
			GameObject colliderObject = new GameObject("CollisionDetector");
			GameObject stats = new GameObject("Stats");
			/*GameObject beheviorArea = new GameObject("BeheviorArea");*/

			enemy.AddComponent<Enemy.BeheviorAI>();
			enemy.AddComponent<NavMeshAgent>();
			enemy.AddComponent<Rigidbody>();
			enemy.GetComponent<Rigidbody>().isKinematic = true;

			colliderObject.AddComponent<CapsuleCollider>();
			colliderObject.transform.position = enemy.transform.position;
			colliderObject.transform.SetParent(enemy.transform);
			colliderObject.AddComponent<Enemy.Collider>();
			colliderObject.GetComponent<CapsuleCollider>().isTrigger = true;

			stats.AddComponent<Enemy.Stats>();
			stats.transform.position = enemy.transform.position;
			stats.transform.SetParent(enemy.transform);

			/*beheviorArea.AddComponent<SphereCollider>();
			SphereCollider area = beheviorArea.GetComponent<SphereCollider>();
			area.radius = 5f;
			beheviorArea.transform.SetParent(enemy.transform);
			beheviorArea.transform.position = enemy.transform.position;*/

			return enemy;
		}

		private void SpawnEnemy() {
			for (int i = 0; i < mapEnemyLimit; i++) {
				float randX = UnityEngine.Random.Range(0f, terrainSize.x);
				float randZ = UnityEngine.Random.Range(0f, terrainSize.y);

				Vector3 newEnemyPos = new Vector3(randX, 0f, randZ);
				enemyList.Add(CreateEnemyAttr(newEnemyPos));

			}
		}
	}
}
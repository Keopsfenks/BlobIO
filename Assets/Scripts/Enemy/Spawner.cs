using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
	public class Spawner : MonoBehaviour {
		[SerializeField] private int mapEnemyLimit = 1;
		[SerializeField] private List<GameObject> enemyPrefabs;

	}
}
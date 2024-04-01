using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
	public class BeheviorAI : MonoBehaviour {
		private NavMeshAgent agent;

		private void Awake() {
			agent = GetComponent<NavMeshAgent>();
		}

		private IEnumerator enemyMovement() {
			while (true) {
				yield return null;
			}
		}
	}
}
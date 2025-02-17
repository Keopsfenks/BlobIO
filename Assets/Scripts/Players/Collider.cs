﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Players {
	public class Collider : MonoBehaviour {
		public event UnityAction<Baits.EatenEvent> eventHandler;
		private Players.Stats pStats;

		private void Awake() {
			pStats = FindObjectOfType<Players.Stats>();
		}

		private void OnTriggerEnter(UnityEngine.Collider other) {
			if (other.TryGetComponent(out Baits.EatenEvent bait)) {
				eventHandler?.Invoke(bait);
				bait.OnEatenEvent();
				pStats.SetBlobCount(1);
			}
		}
	}
}
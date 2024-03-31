using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Baits {
	public class EatenEvent : MonoBehaviour {
		public event UnityAction<EatenEvent> eventHandler;
		public List<EatenEvent> baitListReference;
		private Players.Stats _pStats;

		private void Awake() {
			_pStats = FindObjectOfType<Players.Stats>();
		}

		public void OnEatenEvent() {
			eventHandler?.Invoke(this);
		}

		public void OnEatenAction(EatenEvent bait) {
			eventHandler -= OnEatenAction;
			baitListReference.Remove(bait);
			Destroy(this.gameObject);
			_pStats.SetBlobCount(1);
		}
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy {
	public class Collider : MonoBehaviour {
		public event UnityAction<Baits.EatenEvent> eventHandler;

		private void OnTriggerEnter(UnityEngine.Collider other) {
			if (other.TryGetComponent(out Baits.EatenEvent bait)) {
				Debug.Log("Enems İs Enterred");
				eventHandler?.Invoke(bait);
				bait.OnEatenEvent();

				Enemy.Stats eStats = FindObjectOfType<Enemy.Stats>();
				eStats.SetBlobCount(1);
			}
		}
	}
}
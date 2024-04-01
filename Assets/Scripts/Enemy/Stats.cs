using UnityEngine;

namespace Enemy {
	public class Stats : MonoBehaviour {
		[SerializeField] private int blobCount;

		public int GetBlobCount() {
			return blobCount;
		}

		public void SetBlobCount(int count) {
			this.blobCount += count;
		}
	}
}
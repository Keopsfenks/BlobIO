using System;
using UnityEngine;

namespace Players {
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
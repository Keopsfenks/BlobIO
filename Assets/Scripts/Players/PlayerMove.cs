using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {
	[SerializeField] private NavMeshAgent agent;

	private void Start() {
		StartCoroutine(InputListener());
	}

	private IEnumerator InputListener() {
		while (true) {
			if (Input.GetMouseButton(0)) {
				Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(clickRay, out RaycastHit clickHit)) {
					if (clickHit.transform.CompareTag("Ground")) {
						agent.destination = clickHit.point;
					}
				}
			}

			yield return null;
		}
	}
}

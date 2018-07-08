using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3[] movementVectors = new Vector3[4] { new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0), new Vector3 (0, 1, 0), new Vector3 (0, -1, 0) };
	private KeyCode[] movementKeys = new KeyCode[4] { KeyCode.D, KeyCode.A, KeyCode.W, KeyCode.S };

	[SerializeField] private float speed;

	[SerializeField] private LineRenderer lineRenderer;

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private SpriteRenderer[] enemies;

	void Start () {

	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			lineRenderer.SetPosition (0, Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10)));
		}

		if (Input.GetMouseButton (0)) {
			lineRenderer.SetPosition (1, Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10)));
		}

		if (Input.GetMouseButtonUp (0)) {
			lineRenderer.SetPositions (new Vector3[] { Vector3.zero, Vector3.zero });
		}

		for (int i = 0; i < movementKeys.Length; i++) {
			if (Input.GetKey (movementKeys[i])) {
				Vector3 temp = transform.position;

				transform.position += movementVectors[i] * speed;

				if (IsColliding ()) {
					transform.position = temp;
				}
			}
		}

		transform.position = MathUtils.RoundPlayerPositionToPixelPerfect (transform.position);
	}

	private bool IsColliding () {
		for (int i = 0; i < enemies.Length; i++) {
			if (spriteRenderer.bounds.Intersects (enemies[i].bounds)) {
				return true;
			}
		}
		return false;
	}
}
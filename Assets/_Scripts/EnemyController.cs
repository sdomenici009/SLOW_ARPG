using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private PlayerController player;

	[SerializeField] private float speed;
	[SerializeField] private float range;
	[SerializeField] private float aggroRange;

	private bool _isIdle = true;
	private bool isAttacking = false;

	[SerializeField] private AnimationCurve curve;

	[SerializeField] private SpriteRenderer[] enemies;

	[SerializeField] private SpriteRenderer spriteRenderer;

	private bool IsIdle {
		get { return !isAttacking; }
	}

	private void Update () {
		if (IsIdle) {
			if (Vector3.Distance (transform.position, player.transform.position) < aggroRange && Vector3.Distance (transform.position, player.transform.position) > range) {
				Vector3 temp = transform.position;
				transform.position += (player.transform.position - transform.position).normalized * speed * curve.Evaluate (Time.timeSinceLevelLoad % 1);
				transform.position = MathUtils.RoundPlayerPositionToPixelPerfect (transform.position);
				if (IsColliding ()) {
					transform.position = temp;
				}
			}
		} else {
			//	Attack ();
		}
	}

	private bool IsColliding () {
		for (int i = 0; i < enemies.Length; i++) {
			if (spriteRenderer.bounds.Intersects (enemies[i].bounds)) {
				return true;
			}
		}

		return false;
	}

	private void Attack () {
		StartCoroutine (AttackCoroutine ());
	}

	private IEnumerator AttackCoroutine () {
		isAttacking = true;
		yield return new WaitForSeconds (.75f);
		isAttacking = false;
	}
}
using System.Collections;
using UnityEngine;

public static class MathUtils {

	private const int PIXELS_PER_UNIT = 64;

	public static Vector3 RoundPlayerPositionToPixelPerfect (Vector3 position) {
		float x = Mathf.Round (position.x * PIXELS_PER_UNIT) / PIXELS_PER_UNIT;
		float y = Mathf.Round (position.y * PIXELS_PER_UNIT) / PIXELS_PER_UNIT;
		return new Vector3 (x, y, 0);
	}
}
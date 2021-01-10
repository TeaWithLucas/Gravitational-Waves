using System.Collections.Generic;
using UnityEngine;

namespace Game.Extensions {
	/// <summary>
	/// Extension methods for UnityEngine.Vector2.
	/// Sources: https://gist.github.com/omgwtfgames/f917ca28581761b8100f, https://github.com/mminer/unity-extensions
	/// </summary>

	public static class Vector2Extensions {
		public static Vector2 xy(this Vector3 v) {
			return new Vector2(v.x, v.y);
		}

		public static Vector2 WithX(this Vector2 v, float x) {
			return new Vector2(x, v.y);
		}

		public static Vector2 WithY(this Vector2 v, float y) {
			return new Vector2(v.x, y);
		}
	}
}

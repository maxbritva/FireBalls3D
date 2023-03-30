﻿using UnityEngine;

namespace Paths
{
	[CreateAssetMenu(fileName = "MovePreferences", menuName = "ScriptableObjects/MovePreferences/MovePreferences")]
	public class MovePreferencesSo : ScriptableObject
	{
		[SerializeField][Min(0.0f)] private float _durationPerWaypoint;
		[SerializeField][Min(0.0f)] private float _rotateDuration;

		public float DurationPerWaypoint => _durationPerWaypoint;

		public float RotateDuration => _rotateDuration;

		public float TotalDuration => _rotateDuration + _durationPerWaypoint;
	}
}
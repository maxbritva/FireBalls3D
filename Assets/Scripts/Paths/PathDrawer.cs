using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Paths
{
	public class PathDrawer : MonoBehaviour
	{
		[SerializeField] private Path _path;

		[Header("Settings")] 
		[SerializeField] private float _waypointsRadius = 0.25f;
		[SerializeField] private Color _waypointColor = Color.red;
		[SerializeField] private Color _lineColor = Color.red;

		private void OnDrawGizmos()
		{
			if (_path is null)
				return;
			
			IReadOnlyList<Transform> waypoints = GetAllWayPoints(_path.Segments);
			DrawWayPoints(waypoints);
			DrawSegmentLines(waypoints);
		}

		private void DrawWayPoints(IEnumerable<Transform> waypoints)
		{
			Gizmos.color = _waypointColor;
			foreach (Transform waypoint in waypoints)
			Gizmos.DrawSphere(waypoint.position,_waypointsRadius );
		}

		private void DrawSegmentLines(IReadOnlyList<Transform> waypoints)
		{
			if (waypoints.Count <2)
				return;
			Gizmos.color = _lineColor;
			
			for (int i = 1; i < waypoints.Count; i++) 
				Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
		}
		private IReadOnlyList<Transform> GetAllWayPoints(IEnumerable<PathSegment> segments)
		{
			Transform[] waypoints = Array.Empty<Transform>();

			foreach (PathSegment segment in segments)
			{
				waypoints = waypoints
					.Union(segment.WayPoints)
					.ToArray();
			}
			return waypoints;
		}
	}
}
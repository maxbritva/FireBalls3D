using Paths.Builders;
using UnityEngine;

namespace Paths
{
	[System.Serializable]
	public struct PathSegment
	{
		public Transform[] WayPoints;
		public PathPlatformBuilder PlatformBuilder;
	}
}
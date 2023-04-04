using System.Collections.Generic;
using Obstacles;
using Obstacles.Generation;
using UnityEngine;

namespace Paths.Builders
{
	public class PathObstaclesBuilder : MonoBehaviour
	{
		[SerializeField] private Transform _root;

		private IReadOnlyList<Obstacle> _obstaclesPrefab;

		private void Initialize(IReadOnlyList<Obstacle> obstaclesPrefab) => 
			_obstaclesPrefab = obstaclesPrefab;

		public void Build(ObstacleCollisionFeedback feedback)
		{
			ObstaclesGeneration generation = new ObstaclesGeneration(_obstaclesPrefab);
			IEnumerable<Obstacle> obstacles = generation.Create(_root, feedback);
		}
	}
}
using System.Collections.Generic;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Obstacles.Generation
{
	public class ObstaclesGeneration
	{
		private readonly IReadOnlyList<Obstacle> _obstaclesPrefab;

		public ObstaclesGeneration(IReadOnlyList<Obstacle> obstaclePrefabs)
		{
			_obstaclesPrefab = obstaclePrefabs;
		}

		public IEnumerable<Obstacle> Create(Transform root, ObstacleCollisionFeedback feedback)
		{
			var createdObstacles = new Obstacle[_obstaclesPrefab.Count];
			for (var i = 0; i < _obstaclesPrefab.Count; i++)
			{
				Obstacle createdObstacle = UnityObject.Instantiate(_obstaclesPrefab[i], root);
				createdObstacle.Initialize(feedback);
				createdObstacle.transform.eulerAngles = GetRandomYRotation();
				createdObstacles[i] = createdObstacle;
			}
			return createdObstacles;
		}

		private Vector3 GetRandomYRotation() => 
			Vector3.up * Random.Range(0.0f, 360.0f);
	}
}
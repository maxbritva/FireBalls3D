using System.Collections.Generic;
using Obstacles;
using Obstacles.Disappearing;
using Obstacles.Generation;
using Tweening;
using UnityEngine;

namespace Paths.Builders
{
	public class PathObstaclesBuilder : MonoBehaviour
	{
		[SerializeField] private Transform _root;
		[SerializeField] private LocalMoveTweenSo _disappearAnimation;
		
		private IReadOnlyList<Obstacle> _obstaclesPrefab;
		private void Initialize(IReadOnlyList<Obstacle> obstaclesPrefab) => 
			_obstaclesPrefab = obstaclesPrefab;
		public ObstacleDisappearing  Build(ObstacleCollisionFeedback feedback)
		{
			ObstaclesGeneration generation = new ObstaclesGeneration(_obstaclesPrefab);
			IEnumerable<Obstacle> obstacles = generation.Create(_root, feedback);
			return new ObstacleDisappearing(_root, obstacles, _disappearAnimation);
		}
		
		
	}
}
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tweening;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Obstacles.Disappearing
{
	public class ObstacleDisappearing
	{
		private readonly Transform _obstaclesRoot;
		private readonly IEnumerable<Obstacle> _obstacles;
		private readonly IAwaitableTweenAnimation _animation;
		public ObstacleDisappearing(Transform obstaclesRoot, IEnumerable<Obstacle> obstacles, IAwaitableTweenAnimation animation)
		{
			_obstaclesRoot = obstaclesRoot;
			_obstacles = obstacles;
			_animation = animation;
		}

		public async Task ApplyAsync()
		{
			await _animation.ApplyTo(_obstaclesRoot);
			foreach (Obstacle obstacle in _obstacles)
				UnityObject.Destroy(obstacle.gameObject);
			await Task.CompletedTask;
		}
	}
}
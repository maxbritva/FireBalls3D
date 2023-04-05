﻿using System;
using Obstacles;
using Paths;
using Players;
using UnityEngine;

namespace Levels.Generation
{
	public class LevelBuilder : MonoBehaviour
	{
		[Header("Path")]
		[SerializeField] private Transform _pathRoot;

		[SerializeField] private LevelStructureSo _structure;

		[Header("Player")] 
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

		private void Start() => 
			Build();

		private void Build()
		{
			Path path = _structure.CreatePath(_pathRoot, _obstacleCollisionFeedback);
			Vector3 initialPosition = path.Segments[0].WayPoints[0].position;
			_playerMovement.StartMovingOn(path, initialPosition);
		}
	}
}
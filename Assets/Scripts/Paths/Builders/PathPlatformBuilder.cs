using System.Threading;
using System.Threading.Tasks;
using Obstacles;
using Obstacles.Disappearing;
using Towers.Disassembling;
using UnityEngine;

namespace Paths.Builders
{
	public class PathPlatformBuilder : MonoBehaviour
	{
		[SerializeField] private PathTowerBuilder _towerBuilder;
		[SerializeField] private PathObstaclesBuilder _obstacleBuilder;

		private ObstacleCollisionFeedback _feedback;
		private CancellationTokenSource _cancellationTokenSource;
		public void Initialize(PathPlatformStructure pathPlatformStructure ,ObstacleCollisionFeedback collisionFeedback, CancellationTokenSource cancellationTokenSource)
		{
			_towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
			_obstacleBuilder.Initialize(pathPlatformStructure.Obstacles);
			_feedback = collisionFeedback;
			_cancellationTokenSource = cancellationTokenSource;
		}

		public async Task<(TowerDisassembling, ObstacleDisappearing)> BuildAsync()
		{
			TowerDisassembling disassembling = await _towerBuilder.BuildAsync(_feedback.PlayerProjectilePool, _cancellationTokenSource.Token);
			if (_cancellationTokenSource.IsCancellationRequested)
				return (disassembling, null);
			ObstacleDisappearing disappearing = _obstacleBuilder.Build(_feedback);
			return (disassembling, disappearing);
		}
	}
}
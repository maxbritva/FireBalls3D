using System.Threading.Tasks;
using Obstacles;
using Obstacles.Disappearing;
using Paths.Builders.Disassembling;
using UnityEngine;

namespace Paths.Builders
{
	public class PathPlatformBuilder : MonoBehaviour
	{
		[SerializeField] private PathTowerBuilder _towerBuilder;
		[SerializeField] private PathObstaclesBuilder _obstacleBuilder;

		private ObstacleCollisionFeedback _feedback;
		public void Initialize(PathPlatformStructure pathPlatformStructure ,ObstacleCollisionFeedback collisionFeedback)
		{
			_towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
			_obstacleBuilder.Initialize(pathPlatformStructure.Obstacles);
			_feedback = collisionFeedback;
		}

		public async Task<(TowerDisassembling, ObstacleDisappearing)> BuildAsync()
		{
			TowerDisassembling disassembling = await _towerBuilder.BuildAsync(_feedback.PlayerProjectilePool);
			ObstacleDisappearing disappearing = _obstacleBuilder.Build(_feedback);
			return (disassembling, disappearing);
		}
	}
}
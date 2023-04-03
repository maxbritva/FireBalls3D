using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;
using Towers;

namespace Towers.Generation
{
	[CreateAssetMenu(fileName = "TowerFactory", menuName = "ScriptableObjects/Tower/TowerFactory")]
	public class TowerFactorySo : ScriptableObject, IAsyncTowerFactory, ITowerSegmentCreationCallback
	{
		[SerializeField] private TowerSegment _segmentPrefab;
		[Space]
		[SerializeField][Min(0)] private int _segmentCount;

		[SerializeField] [Min(0.0f)] private float _spawnTimePerSegment;

		[Space] [SerializeField] private Material[] _materials = Array.Empty<Material>();
		
		public event Action SegmentCreated;

		private int SpawnTimePerSegmentMilliseconds => (int)(_spawnTimePerSegment * 1000);
		
		public async Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken)
		{
			Vector3 position = tower.position;
			var segments = new Queue<TowerSegment>(_segmentCount);
			for (int i = 0; i < _segmentCount; i++)
			{
				if (cancellationToken.IsCancellationRequested)
					break;
				TowerSegment segment = CreateSegment(tower, position, i);
				segments.Enqueue(segment);
				position = GetNextPositionAfter(segment.transform, position);
				SegmentCreated?.Invoke();
				await Task.Delay(SpawnTimePerSegmentMilliseconds, cancellationToken);
			}

			return new Tower(segments);
		}

		private TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOfInstance)
		{
			TowerSegment segment = Instantiate(_segmentPrefab, position, tower.rotation, tower);
			Material material = GetSegmentMaterialBy(numberOfInstance);
			segment.SetMaterial(material);
			return segment;
		}

		private Vector3 GetNextPositionAfter(Transform segment, Vector3 currentPosition)
		{
			float segmentHeight = segment.localScale.y;
			return currentPosition + Vector3.up * segmentHeight;
		}
		private Material GetSegmentMaterialBy(int numberOfInstance)
		{
			int index = numberOfInstance % _materials.Length;
			return _materials[index];
		}

		
	}
}
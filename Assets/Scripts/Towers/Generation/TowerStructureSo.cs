using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;
using Paths.Builders;

namespace Paths.Builders.Generation
{
	[CreateAssetMenu(fileName = "TowerStructure", menuName = "ScriptableObjects/Tower/TowerStructure")]
	public class TowerStructureSo : ScriptableObject
	{
		[SerializeField] private TowerSegment _segmentPrefab;
		[Space]
		[SerializeField][Min(0)] private int _segmentCount;

		[SerializeField] [Min(0.0f)] private float _spawnTimePerSegment;

		[Space] [SerializeField] private Material[] _materials = Array.Empty<Material>();

		public TowerSegment SegmentPrefab => _segmentPrefab;
		public int SegmentCount => _segmentCount;

		public int SpawnTimePerSegmentMilliseconds => (int)(_spawnTimePerSegment * 1000);
		
		public Material GetSegmentMaterialBy(int numberOfInstance)
		{
			int index = numberOfInstance % _materials.Length;
			return _materials[index];
		}
		public TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOfInstance)
		{
			TowerSegment segment = Instantiate(_segmentPrefab, position, tower.rotation, tower);
			Material material = GetSegmentMaterialBy(numberOfInstance);
			segment.SetMaterial(material);
			return segment;
		}
		
	}
}
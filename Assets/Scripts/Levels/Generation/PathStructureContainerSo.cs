using UnityEngine;

namespace Levels.Generation
{
	[CreateAssetMenu(fileName = "PathStructureContainer", menuName = "ScriptableObjects/Levels/Generation/PathStructureContainer")]
	public class PathStructureContainerSo : ScriptableObject
	{
		public PathStructureSo PathStructure;
	}
}
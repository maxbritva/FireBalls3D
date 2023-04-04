
using UnityEngine;

namespace Paths.Builders
{
	public class TowerSegment : MonoBehaviour
	{

		public void SetMaterial(Material material) => 
			GetComponent<MeshRenderer>().sharedMaterial = material;
	}
}

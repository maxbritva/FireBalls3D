using Fabric;
using UnityEngine;

namespace Shooting.Pool
{
	[CreateAssetMenu(fileName = "ProjectileFactory", menuName = "ScriptableObjects/ProjectileFactory")]
	public class ProjectileFactory : ScriptableObject, IFactory<Projectile>
	{

		[SerializeField] private Projectile _projectilePrefab;
		public Projectile Create() => Instantiate(_projectilePrefab);
	}
}
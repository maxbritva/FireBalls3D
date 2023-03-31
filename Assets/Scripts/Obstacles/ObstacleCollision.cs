using PlayerComponents;
using Shooting;
using Shooting.Pool;
using Unity.VisualScripting;
using UnityEngine;

namespace Obstacles
{
	public class ObstacleCollision : MonoBehaviour
	{
		[SerializeField] private ProjectilePool _pool;

		[SerializeField] private PlayerInputHandler _playerInputHandler;
		[SerializeField] private Transform _player;

		[SerializeField] private ProjectileFactory _projectileFactory;
		
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out Projectile projectile) == false)
				return;

			Vector3 hitPoint = other.contacts[0].point;
		}
	}
}
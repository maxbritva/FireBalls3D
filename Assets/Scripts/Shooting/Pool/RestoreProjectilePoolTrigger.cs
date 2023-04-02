using System;
using Pool;
using UnityEngine;

namespace Shooting.Pool
{
	public class RestoreProjectilePoolTrigger : MonoBehaviour
	{
		[SerializeField] private ProjectilePool _projectilePool;

		public event Action ProjectileReturned;
		private void OnTriggerEnter(Collider other)
		{
			if(other.TryGetComponent(out Projectile projectile) == false)
				return;
			_projectilePool.Return(projectile);
			ProjectileReturned?.Invoke();
		}
	}
}
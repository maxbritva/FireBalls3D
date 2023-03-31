﻿using Coroutines;
using Physics;
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
		[SerializeField] private DirectionalBouncePreferencesSo _directionalBouncePreferencesSo;

		private bool _hasAlreadyCollided;
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out Projectile projectile) == false)
				return;

			if(_hasAlreadyCollided)
				return;
			_hasAlreadyCollided = true;
			
			_pool.Return(projectile);
			_playerInputHandler.Disable();
			_pool.Disable();
			Vector3 hitPoint = other.contacts[0].point;
			Projectile playerHitProjectile = _projectileFactory.Create();

			new DirectionalBounce(playerHitProjectile.transform, new CoroutineExecutor(playerHitProjectile),
				_directionalBouncePreferencesSo.Value).BounceTo(_player.position, hitPoint);
		}
	}
}
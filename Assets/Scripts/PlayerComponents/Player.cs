using System;
using Characters;
using Paths;
using Pool;
using Shooting;
using Shooting.Pool;
using UnityEngine;

namespace PlayerComponents
{
	public class Player : MonoBehaviour
	{
		[Header("Character")]
		[SerializeField] private CharacterContainerSo _characterContainer;
		
		[Header("Path")]
		[SerializeField] private Path _path;
		[SerializeField] private MovePreferencesSo _movePreferences;
		
		[Header("Shooting")]
		[SerializeField] private ShootingPreferencesSo _shootingPreferences;
		[SerializeField] private ProjectilePool _projectilePool;

		private FireRate _fireRate;
		private Weapon _weapon;
		private PathFollowing _pathFollowing;

		private void Start()
		{
			Character character = _characterContainer.Create(transform);
			_projectilePool.Initialize(_shootingPreferences.ProjectileFactory);
			_projectilePool.Prewarm();
			_weapon = new Weapon(character.ShootPoint, _projectilePool, _shootingPreferences.ProjectileSpeed);
			_fireRate = new FireRate(_shootingPreferences.FireRate);
			_pathFollowing = new PathFollowing(this, _path, _movePreferences);
		}

		public void Shoot() => 
			_fireRate.Shoot(_weapon);

		[ContextMenu(nameof(Move))]
		public void Move() => 
			_pathFollowing.MoveToNext();
	}
}
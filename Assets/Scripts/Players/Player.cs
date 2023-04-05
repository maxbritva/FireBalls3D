﻿using Characters;
using Paths;
using Shooting;
using Shooting.Pool;
using UnityEngine;

namespace Players
{
	public class Player : MonoBehaviour
	{
		[Header("Character")]
		[SerializeField] private CharacterContainerSo _characterContainer;
		
	
		
		[Header("Shooting")]
		[SerializeField] private ShootingPreferencesSo _shootingPreferences;
		[SerializeField] private ProjectilePool _projectilePool;

		private FireRate _fireRate;
		private Weapon _weapon;

		private void Start()
		{
			Character character = _characterContainer.Create(transform);
			_projectilePool.Initialize(_shootingPreferences.ProjectileFactory);
			_projectilePool.Prewarm();
			_weapon = new Weapon(character.ShootPoint, _projectilePool, _shootingPreferences.ProjectileSpeed);
			_fireRate = new FireRate(_shootingPreferences.FireRate);
		}

		public void Shoot() => 
			_fireRate.Shoot(_weapon);
	}
}
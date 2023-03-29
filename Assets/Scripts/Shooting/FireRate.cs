using UnityEngine;

namespace Shooting
{
	public class FireRate
	{
		private readonly float _value;
		private readonly Weapon _weapon;
		private float _lastShootTime;

		public FireRate(Weapon weapon, float value)
		{
			_weapon = weapon;
			_value = value;

		}

		private bool CanShoot => Time.time >= _lastShootTime + 1.0/_value;
		public void Shoot()
		{
			if(CanShoot == false)
				return;
			_weapon.Shoot();
			_lastShootTime = Time.time;
		}
	}
}
using UnityEngine;
using System;

namespace PlayerComponents
{
	public class PlayerInputHandler : MonoBehaviour
	{
		[Header("Input")]
		[SerializeField] private InputTouchPanel _touchPanel;
		[Header("Player")]
		[SerializeField] private Player _player;

		private void OnEnable()
		{
			_touchPanel.Holding += Shoot;
		}

		private void OnDisable()
		{
			_touchPanel.Holding -= Shoot;
		}

		private void Shoot(Touch touch) => _player.Shoot();
	}
}
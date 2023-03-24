using System;
using UnityEngine;

namespace Animations
{
	public class UIRotationAnimation : MonoBehaviour
	{
		[SerializeField] [Min(0.0f)] private float _speedRotation; 
		private void Update() => 
			Rotate(_speedRotation);

		private void Rotate(float speed)
		{
			transform.Rotate(Vector3.forward *-1, speed * Time.deltaTime);
		}
	}
}
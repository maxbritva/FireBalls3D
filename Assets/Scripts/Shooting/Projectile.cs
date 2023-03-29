using System.Collections;
using UnityEngine;

namespace Shooting
{
	[RequireComponent(typeof(Rigidbody))]
	public class Projectile : MonoBehaviour
	{
		private Rigidbody _rigidBody;

		private void Awake() => 
			_rigidBody = GetComponent<Rigidbody>();

		public void Shoot(Vector3 position, Vector3 direction, float speed)
		{
			transform.position = position;
			StartCoroutine(MoveAlong(direction, speed));
		}

		private IEnumerator MoveAlong(Vector3 direction, float speed)
		{
			while (true)
			{
				Vector3 newPosition = _rigidBody.position + direction * speed * Time.deltaTime;
				_rigidBody.MovePosition(newPosition);
				yield return null;
			}
		}
	}
}
using Paths;
using UnityEngine;

namespace Players
{
	public class PlayerMovement : MonoBehaviour
	{
		[Header("Path")]
		[SerializeField] private MovePreferencesSo _movePreferences;

		[Header("Player")]
		[SerializeField] private PlayerInputHandler _inputHandler;
		[SerializeField] private Transform _player;
		

		public void StartMovingOn(Path path)
		{
			new PlayerPathFollowing( new  PathFollowing(_player, path, _movePreferences), path, _inputHandler)
				.StartMovingAsync();
		}
	}
}
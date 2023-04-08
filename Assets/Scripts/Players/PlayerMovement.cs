using System.Threading;
using GameStates.Base;
using Paths;
using Paths.Completion;
using UnityEngine;

namespace Players
{
	public class PlayerMovement : MonoBehaviour
	{
		[Header("Path")]
		[SerializeField] private MovePreferencesSo _movePreferences;

		[SerializeField] private GameStatesMachineSo _statesMachine;

		[Header("Player")]
		[SerializeField] private PlayerInputHandler _inputHandler;
		[SerializeField] private Transform _player;
		

		public void StartMovingOn(Path path, Vector3 initialPosition, CancellationTokenSource cancellationTokenSource)
		{
			_player.position = initialPosition;
			new PlayerPathFollowing( new  PathFollowing(_player, path, _movePreferences), path, _inputHandler, new LevelPathCompletion(_statesMachine))
				.StartMovingAsync(cancellationTokenSource.Token);
		}
	}
}
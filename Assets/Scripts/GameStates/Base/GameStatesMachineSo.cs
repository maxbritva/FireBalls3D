using UnityEngine;

namespace GameStates.Base
{
	[CreateAssetMenu(fileName = "GameStatesMachine", menuName = "ScriptableObjects/GameStates/GameStatesMachine")]
	public class GameStatesMachineSo : ScriptableObject, IGameStateMachine
	{
		[SerializeField] private GameStateSo[] _states;
		private GameStateMachine _stateMachine;

		private void OnEnable()
		{
			_stateMachine = new GameStateMachine(_states);
		}

		public void Enter<TState>() where TState : IGameState => 
			_stateMachine.Enter<TState>();
	}
}
using System;
using System.Collections.Generic;

namespace GameStates.Base
{
	public class GameStateMachine : IGameStateMachine
	{
		private readonly Dictionary<Type, IGameState> _states;
		private IGameState _currentState = new Empty();

		public GameStateMachine(IEnumerable<IGameState> states) : this(CreateStatesFrom(states)) {}
		public GameStateMachine(Dictionary<Type, IGameState> states)
		{
			_states = states;
		}
		public void Enter<TState>() where TState : IGameState
		{
			// proverka sostoyanii
			if (_states.TryGetValue(typeof(TState), out IGameState newState) == false)
				throw new InvalidOperationException("Trying to entered unregistered game state");
			//exit state
			_currentState.Exit();
			//change state
			_currentState = newState;
			//enter new state
			_currentState.Enter();

		}

		private static Dictionary<Type, IGameState> CreateStatesFrom(IEnumerable<IGameState> states)
		{
			var createdStates = new Dictionary<Type, IGameState>();
			foreach (IGameState state in states)
			{
				Type stateKey = state.GetType();
				createdStates.Add(stateKey, state);
			}

			return createdStates;
		}
	}
}
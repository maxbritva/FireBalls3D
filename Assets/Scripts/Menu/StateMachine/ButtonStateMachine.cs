using System;
using StateMachine;
using UnityEngine;

namespace Menu.StateMachine
{
	public class ButtonStateMachine : MonoBehaviour
	{
		[SerializeField] private MonoState[] _states = Array.Empty<MonoState>();
		[SerializeField] private string _key;
		private int _currentStateIndex;

		private void Start()
		{
			Initialize();
		}

		public void ChangeToNextState()
		{
			_currentStateIndex = GetNextStateIndex(_currentStateIndex);
			_states[_currentStateIndex].Enter();
			PlayerPrefs.SetInt(_key, _currentStateIndex);
		}

		private void Initialize()
		{
			if (_states.Length == 0)
			{
				enabled = false;
				throw new Exception("States should have any states");
			}
			_currentStateIndex = PlayerPrefs.GetInt(_key,0);
			_states[_currentStateIndex].Enter();
		}

		private int GetNextStateIndex(int currentIndex)
		{
			return (currentIndex + 1) % _states.Length;
		}
	}
}
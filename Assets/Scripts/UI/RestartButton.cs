using GameStates.Base;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(Button))]
	public class RestartButton : MonoBehaviour
	{
		[SerializeField] private GameStatesMachineSo _statesMachine;
		private void Start()
		{
			Button button = GetComponent<Button>();
			button.onClick.AddListener(_statesMachine.Enter<LevelLostState>);
		}
	}
}
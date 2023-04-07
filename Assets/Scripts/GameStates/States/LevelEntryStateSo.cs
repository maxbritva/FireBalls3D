using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "LevelEntryState", menuName = "ScriptableObjects/GameStates/LevelEntryState")]
	public class LevelEntryStateSo : GameStateSo
	{
		[SerializeField] private Scene _locationScene;
		[SerializeField] private Scene _playerGeneratedPathScene;

		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
		public override  void Enter()
		{
			_sceneLoading.LoadAsync(_locationScene);
			_sceneLoading.LoadAsync(_playerGeneratedPathScene);
		}

		public override void Exit(){}
	}
}
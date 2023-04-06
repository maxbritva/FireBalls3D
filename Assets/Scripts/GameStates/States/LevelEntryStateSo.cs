﻿using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "LevelEntryState", menuName = "ScriptableObjects/GameStates/LevelEntryState")]
	public class LevelEntryStateSo : GameStateSo
	{
		[SerializeField] private Scene _scene;

		private readonly IAsyncSceneLoading _sceneLoading = new UnitySceneLoading();
		public override  void Enter() => 
			_sceneLoading.LoadAsync(_scene);

		public override void Exit(){}
	}
}
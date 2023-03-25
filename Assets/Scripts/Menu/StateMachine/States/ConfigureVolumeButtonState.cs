﻿using UnityEngine;
using UnityEngine.Audio;

namespace Menu.StateMachine.States
{
	public abstract class ConfigureVolumeButtonState :IconChangeButtonState
	{
		[Header("VolumeSettings")]
		[SerializeField] private string _volumeExposedParameter;
		[SerializeField] private AudioMixer _audioMixer;
		protected abstract float VolumeLevel { get; }

		protected override void OnStateEnter()
		{
			_audioMixer.SetFloat(_volumeExposedParameter, VolumeLevel);
		}
	}
}
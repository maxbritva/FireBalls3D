using StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.StateMachine.States
{
	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(AudioSource))]
	public class IconChangeButtonState : MonoState
	{
		[SerializeField] private AudioClip _clickSound;
		[SerializeField] private Sprite _icon;
		
		private Image _image;
		private AudioSource _audioSource;

		private void Start()
		{
			_image = GetComponent<Image>();
			_audioSource = GetComponent<AudioSource>();
			_audioSource.mute = true;
		}

		public override void Enter()
		{
			_image.sprite = _icon;
			_audioSource.PlayOneShot(_clickSound);
			_audioSource.mute = false;
			OnStateEnter();
		}

		protected virtual void OnStateEnter(){}
	}
}
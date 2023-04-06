using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
	[RequireComponent(typeof(Button))]
	public class PlayButton : MonoBehaviour
	{
		[SerializeField] private string _levelSceneName  = "Tropic1";

		private void Start()
		{
			Button button = GetComponent<Button>();
			button.onClick.AddListener(LoadLevel);
		}

		private async void LoadLevel()
		{
			SceneManager.LoadScene(_levelSceneName);
			await Task.Delay(3000);
		}
	}
}
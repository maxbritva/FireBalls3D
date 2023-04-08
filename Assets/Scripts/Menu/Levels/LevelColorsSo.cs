using UnityEngine;

namespace Menu.Levels
{
	[CreateAssetMenu(fileName = "LevelColors", menuName = "ScriptableObjects/Menu/Levels/Colors")]
	public class LevelColorsSo : ScriptableObject
	{
		[SerializeField] private Color _passedLevels = Color.white;
		[SerializeField] private Color _nextLevels = Color.green;

		public Color PassedLevels => _passedLevels;

		public Color NextLevels => _nextLevels;
	}
}
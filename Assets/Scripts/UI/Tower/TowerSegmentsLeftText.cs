using TMPro;
using UnityEngine;

namespace UI.Tower
{
	public class TowerSegmentsLeftText : MonoBehaviour
	{
		[SerializeField] private TextMeshPro _text;

		public void UpdateTextValue(int segments) => 
			_text.text = $"{segments}";
	}
}
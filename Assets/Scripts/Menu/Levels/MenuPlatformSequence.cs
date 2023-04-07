using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Menu.Levels
{
	public class MenuPlatformSequence : MonoBehaviour
	{
		[SerializeField] private MenuLevel[] _levels = Array.Empty<MenuLevel>();
		[SerializeField] private AssetReferenceGameObject _levelMarker;
	}
}
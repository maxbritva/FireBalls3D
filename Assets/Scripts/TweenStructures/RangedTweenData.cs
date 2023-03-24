using DG.Tweening;

namespace TweenStructures
{
	[System.Serializable]
	public class Vector3RangedTweenData: RangedTweenData<UnityEngine.Vector3> {}
	
	[System.Serializable]
	public class Vector2RangedTweenData: RangedTweenData<UnityEngine.Vector2> {}
	public class RangedTweenData<T> : TweenData<T>
	{
		public T From;
	}
}
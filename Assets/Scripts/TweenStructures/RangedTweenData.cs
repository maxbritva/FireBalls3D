using DG.Tweening;

namespace TweenStructures
{
	public class Vector3RangedTweenData: RangedTweenData<UnityEngine.Vector3> {}
	public class Vector2RangedTweenData: RangedTweenData<UnityEngine.Vector2> {}
	public class RangedTweenData<T> : TweenData<T>
	{
		public T From;
	}
}
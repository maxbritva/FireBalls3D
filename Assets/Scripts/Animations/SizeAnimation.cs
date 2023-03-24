using System.Collections;
using DG.Tweening;
using TweenStructures;
using UnityEngine;

public class SizeAnimation : MonoBehaviour
{
	[SerializeField] private Vector3TweenData _tweenData;

   private void Start() =>
	   ApplyAnimation();

  

   private void ApplyAnimation() =>
      transform.DOScale(_tweenData.EndValue, _tweenData.Duration)
         .SetEase(_tweenData.Ease)
         .SetLoops(-1, LoopType.Yoyo);
}

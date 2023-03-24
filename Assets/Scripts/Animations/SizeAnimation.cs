using System.Collections;
using UnityEngine;

public class SizeAnimation : MonoBehaviour
{
   [SerializeField] private Vector3 _scaleFrom;
   [SerializeField] private Vector3 _scaleTo;
   [SerializeField][Min(0.0f)] private float _duration;
   [SerializeField] private AnimationCurve _scaleCurve;
   private void Start() => 
      StartCoroutine(PlayLoopedScaledAnimation(transform,_scaleFrom,_scaleTo, _duration));

   private IEnumerator PlayLoopedScaledAnimation(Transform transformToAnimate, Vector3 from, Vector3 to, float duration)
   {
      while (true)
      {
         yield return StartCoroutine(PlayScaleAnimation(transformToAnimate, to, duration,_scaleCurve));
         yield return StartCoroutine(PlayScaleAnimation(transformToAnimate, from, duration,_scaleCurve));
      }
      
   }
   private IEnumerator PlayScaleAnimation(Transform transformToAnimate, Vector3 to, float duration, AnimationCurve scaleCurve)
   {
      float enteredTime = Time.time;
      Vector3 enteredScale = transformToAnimate.localScale;

      while (Time.time < enteredTime + duration)
      {
         float elapsedTimePercent = (Time.time - enteredTime) / duration;
         Vector3 difference = to - enteredScale;
         Vector3 scaledDifference = scaleCurve.Evaluate(elapsedTimePercent) * difference;
         transformToAnimate.localScale = enteredScale + scaledDifference;
         
         yield return null;
      }

      
   }
}

﻿using System;
using DG.Tweening;
using UnityEngine;

namespace TweenStructures
{
	[Serializable]
	public class Vector3TweenData: TweenData<Vector3> {}
	public class TweenData<T>
	{
		public T To;
		public float Duration;
		public Ease Ease;
	}
}
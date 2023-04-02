﻿using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using TweenStructures;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Towers.Generation
{
	public class TowerGenerator : MonoBehaviour
	{
		[SerializeField] private UnityObject _towerFactory;
		[SerializeField] private Transform _towerRoot;
		[SerializeField] private Vector3TweenData _rotationData;

		private IAsyncTowerFactory TowerFactory => (IAsyncTowerFactory)_towerFactory;

		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
		private void OnValidate()
		{
			if (_towerFactory != null && _towerFactory is IAsyncTowerFactory ==false)
			{
				_towerFactory = null;
				throw new InvalidExpressionException("Tower Factory should be derived from IAsyncTowerFactory");
			}
		}

		private void OnDisable() => 
			_cancellationTokenSource.Cancel();

		[ContextMenu(nameof(Generate))]
		public async Task<Tower> Generate()
		{
			ApplyRotation(_rotationData);
			return await TowerFactory.CreateAsync(_towerRoot, _cancellationTokenSource.Token);
		}

		private void ApplyRotation(Vector3TweenData rotationData) =>
			_towerRoot
				.DORotate(rotationData.To, rotationData.Duration, RotateMode.FastBeyond360)
				.SetEase(rotationData.Ease);
	}
}
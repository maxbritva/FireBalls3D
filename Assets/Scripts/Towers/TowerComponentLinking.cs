using System;
using System.Threading.Tasks;
using Shooting.Pool;
using Towers.Disassembling;
using Towers.Generation;
using UnityEngine;

namespace Towers
{
	public class TowerComponentLinking : MonoBehaviour
	{
		[SerializeField] private Transform _towerRoot;
		[SerializeField] private TowerGenerator _generator;
		[SerializeField] private RestoreProjectilePoolTrigger _projectileHitTrigger;

		private TowerDisassembling _disassembling;
		private Tower _tower;

		[ContextMenu(nameof(Prepare))]
		public async Task Prepare()
		{
			_tower = await _generator.Generate();
			_disassembling = new TowerDisassembling(_tower, _towerRoot);
			_projectileHitTrigger.ProjectileReturned += _disassembling.RemoveBottom;
		}

		private void OnDisable()
		{
			if(_disassembling != null)
				_projectileHitTrigger.ProjectileReturned -= _disassembling.RemoveBottom;
		}
	}
}
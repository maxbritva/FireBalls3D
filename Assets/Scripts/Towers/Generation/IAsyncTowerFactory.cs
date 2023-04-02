using System.Threading;
using System.Threading.Tasks;
using Towers;
using UnityEngine;

namespace Towers.Generation
{
	public interface IAsyncTowerFactory
	{
		Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken);
	}
}
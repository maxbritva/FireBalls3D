using System.Threading.Tasks;
using UnityEngine;

namespace Paths.Builders.Generation
{
	public interface IAsyncTowerGenerator
	{
		Task<Tower> CreateAsync(Transform tower);
	}
}
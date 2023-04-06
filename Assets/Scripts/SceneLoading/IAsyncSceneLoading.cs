using System.Threading.Tasks;
using UnityEngine;

namespace SceneLoading
{
	public interface IAsyncSceneLoading
	{
		//LoadAsync
		Task<AsyncOperation> LoadAsync(Scene scene);

		//UnloadAsync
		Task<AsyncOperation> UnloadAsync(Scene scene);
	}
}
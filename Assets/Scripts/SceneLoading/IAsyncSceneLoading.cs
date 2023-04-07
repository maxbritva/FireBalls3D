using System.Threading.Tasks;

namespace SceneLoading
{
	public interface IAsyncSceneLoading
	{
		//LoadAsync
		Task LoadAsync(Scene scene);

		//UnloadAsync
		Task UnloadAsync(Scene scene);
	}
}
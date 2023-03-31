using UnityEditor.PackageManager.Requests;

namespace Pool
{
	public interface IPool<T>
	{
		void Prewarm();

		T Request();

		void Return(T member);
	}
}
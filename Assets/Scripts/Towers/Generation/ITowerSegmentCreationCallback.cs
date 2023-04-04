using System;

namespace Paths.Builders.Generation
{
	public interface ITowerSegmentCreationCallback
	{
		event Action<int> SegmentCreated;
	}
}
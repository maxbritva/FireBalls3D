﻿using System;

namespace Towers.Generation
{
	public interface ITowerSegmentCreationCallback
	{
		event Action SegmentCreated;
	}
}
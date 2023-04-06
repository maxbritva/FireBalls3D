using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Extensions
{
	public static class AsyncOperationExtensions
	{
		public static AsyncOperationAwaiter GetAwaiter(this AsyncOperation operation) => 
			new AsyncOperationAwaiter(operation);
	}
	
	public struct AsyncOperationAwaiter : INotifyCompletion
	{
		private readonly AsyncOperation _asyncOperation;
		private Action _continuation;

		public AsyncOperationAwaiter(AsyncOperation asyncOperation)
		{
			_asyncOperation = asyncOperation;
			_continuation = null;
		}

		public bool IsCompleted => _asyncOperation.isDone;
		public AsyncOperation GetResult() => _asyncOperation;
		
		public void OnCompleted(Action continuation)
		{
			_continuation = continuation;
			_asyncOperation.completed += OnOperationCompleted;

		}

		private void OnOperationCompleted(AsyncOperation asyncOperation) => 
			_continuation.Invoke();
	}
}
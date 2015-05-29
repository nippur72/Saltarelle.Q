using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[Imported]
public class Future : FutureBase<object>, INotifyCompletion
{
}

[Imported]
public class Future<T> : FutureBase<T>, INotifyCompletion
{
}


[Imported]
public class FutureBase<T> : INotifyCompletion
{
	#region async/await compiler interface

	[InlineCode("{this}")] 
	public extern FutureBase<T> GetAwaiter();
	
	public extern bool IsCompleted 
	{ 
		[InlineCode("({this}.isFullfilled() || {this}.isRejected())")] 
		get; 
	}

	[InlineCode("{this}.inspect().value")]
	public extern T GetResult();

	[ScriptName("then")]
	public extern void OnCompleted(Action continuation);

	#endregion

	// 0-p
   [ScriptName("then")] public FutureBase<T> Then()                                                             { return null; }

   // 1-p
   [ScriptName("then")] public FutureBase<T> Then(Action successCallback)                                       { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback)                               { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Func<FutureBase<T>> successCallback)                                 { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Func<object,FutureBase<T>> successCallback)                          { return null; }

   // 2-p
   [ScriptName("then")] public FutureBase<T> Then(Action         successCallback, Action         errorCallback)  { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action         successCallback, Action<object> errorCallback)  { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback, Action         errorCallback)  { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback, Action<object> errorCallback)  { return null; }
      
   // 3-p
   [ScriptName("then")] public FutureBase<T> Then(Action         successCallback, Action         errorCallback, Action         notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action         successCallback, Action         errorCallback, Action<object> notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action         successCallback, Action<object> errorCallback, Action         notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action         successCallback, Action<object> errorCallback, Action<object> notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback, Action         errorCallback, Action         notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback, Action         errorCallback, Action<object> notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback, Action<object> errorCallback, Action         notifyCallback) { return null; }
   [ScriptName("then")] public FutureBase<T> Then(Action<object> successCallback, Action<object> errorCallback, Action<object> notifyCallback) { return null; }

   //[ScriptName("catch")] public Promise Catch<TResult>(Action<object> onRejected: (reason: any) => IHttpPromise<TResult>){ return null; }
   //[ScriptName("catch")] public Promise Catch<TResult>(onRejected: (reason: any) => IPromise<TResult>)    { return null; }
   //[ScriptName("catch")] public Promise Catch<TResult>(onRejected: (reason: any) => TResult)              { return null; }

   [ScriptName("finally")] public FutureBase<T> Finally(Action FinallyCallback) { return null; }
	
	/*
   [InlineCode(@"(function(fn){{{this}.then(     function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Success<T>(Action<T> func) { return null; }
   [InlineCode(@"(function(fn){{{this}.then(null,function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Error  <T>(Action<T> func) { return null; }

   [InlineCode(@"(function(fn){{{this}.then(     function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Success(Action<object> func) { return null; }
   [InlineCode(@"(function(fn){{{this}.then(null,function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Error  (Action<object> func) { return null; }
      
   [InlineCode(@"(function(fn){{{this}.then(     function(response){{fn();}});return {this};}})({func})")] public FutureBase Success(Action func) { return null; }
   [InlineCode(@"(function(fn){{{this}.then(null,function(response){{fn();}});return {this};}})({func})")] public FutureBase Error  (Action func) { return null; }      

   [InlineCode(@"(function(fn){{{this}.then(     function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Success<T>(Func<T,FutureBase> func) { return null; }
   [InlineCode(@"(function(fn){{{this}.then(null,function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Error  <T>(Func<T,FutureBase> func) { return null; }

   [InlineCode(@"(function(fn){{{this}.then(     function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Success(Func<object,FutureBase> func) { return null; }
   [InlineCode(@"(function(fn){{{this}.then(null,function(response){{fn(response);}});return {this};}})({func})")] public FutureBase Error  (Func<object,FutureBase> func) { return null; }
      
   [InlineCode(@"(function(fn){{{this}.then(     function(response){{fn();}});return {this};}})({func})")] public FutureBase Success(Func<FutureBase> func) { return null; }
   [InlineCode(@"(function(fn){{{this}.then(null,function(response){{fn();}});return {this};}})({func})")] public FutureBase Error  (Func<FutureBase> func) { return null; }      
	*/
}                         


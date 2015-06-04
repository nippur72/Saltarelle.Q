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

	//[InlineCode("{this}")] 
	//[InlineCode("({this}.done(function(){{}},function(err){{throw err;}},function(){{}}))")] 
	[InlineCode("{this}.catch(function(err){{$$ex=err; $sm();}})")] 
	public extern FutureBase<T> GetAwaiter();
	
	public extern bool IsCompleted 
	{ 
		[InlineCode("({this}.isFullfilled() || {this}.isRejected())")] 
		get; 
	}

	[InlineCode("{this}.inspect().value")]
	public extern T GetResult();

	[ScriptName("done")]	
	public extern void OnCompleted(Action continuation);

	#endregion

	#region Then
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback);                                                              										 
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback, Action         errorCallback);                                
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback, Action<object> errorCallback);                                         							 
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback, Action         errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback, Action         errorCallback, Action<object> notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback, Action<object> errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Action         successCallback, Action<object> errorCallback, Action<object> notifyCallback); 

   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback);                                                              
   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback, Action         errorCallback);                                
   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback, Action<object> errorCallback);                                
   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback, Action         errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback, Action         errorCallback, Action<object> notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback, Action<object> errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Action<object> successCallback, Action<object> errorCallback, Action<object> notifyCallback); 

   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback);                                                              										 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback, Action         errorCallback);                                
   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback, Action<object> errorCallback);                                         							 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback, Action         errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback, Action         errorCallback, Action<object> notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback, Action<object> errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<FutureBase<T>> successCallback, Action<object> errorCallback, Action<object> notifyCallback); 

   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback);                                                              
   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback, Action         errorCallback);                                
   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback, Action<object> errorCallback);                                
   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback, Action         errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback, Action         errorCallback, Action<object> notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback, Action<object> errorCallback, Action         notifyCallback); 
   [ScriptName("then")] public extern FutureBase<T> Then(Func<object,FutureBase<T>> successCallback, Action<object> errorCallback, Action<object> notifyCallback); 
	#endregion

	#region Done
   [ScriptName("done")] public extern void Done(Action         successCallback);                                                              
   [ScriptName("done")] public extern void Done(Action<object> successCallback);                                                              										 
   [ScriptName("done")] public extern void Done(Action         successCallback, Action         errorCallback);                                
   [ScriptName("done")] public extern void Done(Action         successCallback, Action<object> errorCallback);                                
   [ScriptName("done")] public extern void Done(Action<object> successCallback, Action         errorCallback);                                
   [ScriptName("done")] public extern void Done(Action<object> successCallback, Action<object> errorCallback);                                         							 
   [ScriptName("done")] public extern void Done(Action         successCallback, Action         errorCallback, Action         notifyCallback); 
   [ScriptName("done")] public extern void Done(Action         successCallback, Action         errorCallback, Action<object> notifyCallback); 
   [ScriptName("done")] public extern void Done(Action         successCallback, Action<object> errorCallback, Action         notifyCallback); 
   [ScriptName("done")] public extern void Done(Action         successCallback, Action<object> errorCallback, Action<object> notifyCallback); 
   [ScriptName("done")] public extern void Done(Action<object> successCallback, Action         errorCallback, Action         notifyCallback); 
   [ScriptName("done")] public extern void Done(Action<object> successCallback, Action         errorCallback, Action<object> notifyCallback); 
   [ScriptName("done")] public extern void Done(Action<object> successCallback, Action<object> errorCallback, Action         notifyCallback); 
   [ScriptName("done")] public extern void Done(Action<object> successCallback, Action<object> errorCallback, Action<object> notifyCallback); 
	#endregion

	#region Catch
   [ScriptName("catch")] public extern FutureBase<T> Catch(Action         errorCallback);
   [ScriptName("catch")] public extern FutureBase<T> Catch(Action<object> errorCallback);
	#endregion Catch

   [ScriptName("finally")] public extern FutureBase<T> Finally(Action FinallyCallback);	
}                         


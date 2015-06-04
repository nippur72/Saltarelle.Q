using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[Imported]
public class Promise	: INotifyCompletion
{
	public Promise(Action<Action<object>,Action<object>> fun) {}

	public extern Promise then(Action               onFulfilled);
	public extern Promise then(Action<object>       onFulfilled);
	public extern Promise then(Func<Promise>        onFulfilled);
	public extern Promise then(Func<object,Promise> onFulfilled);

	public extern Promise then(Action               onFulfilled, Action onRejected);
	public extern Promise then(Action<object>       onFulfilled, Action onRejected);
	public extern Promise then(Func<Promise>        onFulfilled, Action onRejected);
	public extern Promise then(Func<object,Promise> onFulfilled, Action onRejected);

	public extern Promise @catch(Action onRejected);


	#region async/await compiler interface

	//[InlineCode("{this}")] 
	//[InlineCode("({this}.done(function(){{}},function(err){{throw err;}},function(){{}}))")] 
	//[InlineCode("{this}.catch(function(err){{ throw err; }})")] 
	[InlineCode("{this}.catch(function(err){{$$ex=err; $sm();}})")] 	
	public extern Promise GetAwaiter();
	
	public extern bool IsCompleted 
	{ 
		[InlineCode("({this}.state_ == 'fulfilled' || {this}.state_ == 'rejected')")] 
		get; 
	}

	[InlineCode("{this}.data_")]
	public extern object GetResult();

	[ScriptName("then")]	
	public extern void OnCompleted(Action continuation);

	#endregion
}


public class ProgramEs6
{
	public static async void Main(string[] args)
	{			
		var p = ProgramEs6.mypromise();

		/*
		// traditional
		Console.WriteLine("es6 promise started");
		p.then(()=>
		{
			Console.WriteLine("es6 promise resolved");
		})
		.@catch(()=>
		{
			Console.WriteLine("es6 promise rejected");
		});							
		Console.WriteLine("es6 promise ended");
		*/

		// async/await approach
		Console.WriteLine("es6 promise started");

		try
		{
			var result = await ProgramEs6.mypromise();
			Console.WriteLine("es6 promise resolved, result="+result.ToString());
		}
		catch(Exception ex)
		{
			Console.WriteLine("es6 promise rejected: "+ex.Message);
		}
		finally
		{
			Console.WriteLine("es6 promise completed!");
		}

	}

	public static Promise mypromise()
	{
		return new Promise((resolve,reject)=>{
			Window.SetTimeout(()=>
			{
				resolve("ok");
				//reject("err!");
			},2000);
		});		
	}
}


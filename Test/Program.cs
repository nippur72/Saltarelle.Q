using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static async void Main(string[] args)
	{						
		/*
		// untyped
		Console.WriteLine("1 - future started");	
		string s = (string) await wait_a_little();
		Console.WriteLine("3 - future ended");		
		Console.WriteLine(s);		  
		
		// typed
		Console.WriteLine("1 - future started");	
		s = await wait_another_little();
		Console.WriteLine("3 - future ended");		
		Console.WriteLine(s);				

		// no await, old way
		wait_a_little_more().Then((result)=>
		{
			Console.WriteLine(string.Format("future resolved with no await! val={0}",result));	
		});		
		*/

		/*
		Tools.wait_a_little_more()
		.Then(()=>cause_error())
		.Catch((err)=>Console.WriteLine((string)err))
		.Finally(()=>Console.WriteLine("finally"));		
		*/

		
		try
		{
			await Tools.wait_a_little_more();
			await Tools.cause_error();
		}
		catch(Exception ex)
		{
			Console.WriteLine("inside catch msg="+ex.Message);
		}

		Console.WriteLine("finally");
		
		//TestDone.Test();
	}
}

public class Tools
{
	public static Future wait_a_little()
	{
		Completer compl = new Completer();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("'wait_a_little' resolved");	
			compl.Resolve("this is future result as untyped");
		},3000);

		return compl.Future;
	}
	
	public static Future<string> wait_another_little()
	{
		var compl = new Completer<string>();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("'wait_another_little' resolved");	
			compl.Resolve("this is future result as typed string");
		},1000);

		return compl.Future;
	}	

	public static Future wait_a_little_more()
	{
		Completer compl = new Completer();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("'wait_a_little_more' resolved");	
			compl.Resolve("risp");
		},1000);

		return compl.Future;
	}

	public static Future cause_error()
	{
		Completer compl = new Completer();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("'cause_error' rejected");	
			compl.Reject("there was an error");
		},1000);

		return compl.Future;
	}
}

public class TestDone
{
	public static void Test()
	{
		Tools.wait_a_little()
			.Then(()=>Tools.cause_error())
			.Done(
				()=>{Console.WriteLine("done");}/*,
				()=>{Console.WriteLine("error"); throw new Exception("jjj"); }*/
			);
	}
}

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
	}

	public static Future wait_a_little()
	{
		Completer compl = new Completer();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("2 - future resolved");	
			compl.Resolve("this is future result as untyped");
		},3000);

		return compl.Future;
	}
	
	public static Future<string> wait_another_little()
	{
		var compl = new Completer<string>();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("2 - future resolved");	
			compl.Resolve("this is future result as typed string");
		},3000);

		return compl.Future;
	}	

	public static Future wait_a_little_more()
	{
		Completer compl = new Completer();
		
		Window.SetTimeout(()=>{			
		   Console.WriteLine("future resolved");	
			compl.Resolve("risp");
		},3000);

		return compl.Future;
	}
}


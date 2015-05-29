using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[Imported]
public class Completer : CompleterBase<object>
{
   [InlineCode("Q.defer()")]
	public Completer(){}
	[ScriptName("promise")] public Future Future;
}

[Imported]
public class Completer<T> : CompleterBase<T>
{
   [InlineCode("Q.defer()")]
	public Completer(){}
	[ScriptName("promise")] public Future<T> Future;
}

[Imported]
public class CompleterBase<T>
{
   [InlineCode("Q.defer()")]
	public CompleterBase(){}

	[ScriptName("resolve")] public void Resolve() {}
   [ScriptName("resolve")] public void Resolve(T value) {}
   [ScriptName("reject")]  public void Reject() {}
   [ScriptName("reject")]  public void Reject(object reason) {}
   [ScriptName("notify")]  public void Notify() {}
   [ScriptName("notify")]  public void Notify(object state) {}   
}


(function() {
	'use strict';
	var $asm = {};
	ss.initAssembly($asm, 'test');
	////////////////////////////////////////////////////////////////////////////////
	// Program
	var $Program = function() {
	};
	$Program.__typeName = 'Program';
	$Program.Main = function(args) {
		var $state = 0, $$ex, $t1, $t2, ex;
		var $sm = function() {
			$sm1:
			for (;;) {
				switch ($state) {
					case 0: {
						$state = -1;
						//
						//		// untyped
						//
						//		Console.WriteLine("1 - future started");
						//
						//		string s = (string) await wait_a_little();
						//
						//		Console.WriteLine("3 - future ended");
						//
						//		Console.WriteLine(s);
						//
						//		
						//
						//		// typed
						//
						//		Console.WriteLine("1 - future started");
						//
						//		s = await wait_another_little();
						//
						//		Console.WriteLine("3 - future ended");
						//
						//		Console.WriteLine(s);
						//
						//		
						//
						//		// no await, old way
						//
						//		wait_a_little_more().Then((result)=>
						//
						//		{
						//
						//		Console.WriteLine(string.Format("future resolved with no await! val={0}",result));
						//
						//		});
						//
						//		Tools.wait_a_little_more()
						//
						//		.Then(()=>cause_error())
						//
						//		.Catch((err)=>Console.WriteLine((string)err))
						//
						//		.Finally(()=>Console.WriteLine("finally"));
						$state = 1;
						continue $sm1;
					}
					case 1:
					case 2:
					case 3:
					case 4: {
						if ($state === 1) {
							$state = 2;
						}
						try {
							if ($$ex !== undefined) {
								throw $$ex;
							}
							$sm2:
							for (;;) {
								switch ($state) {
									case 2: {
										$state = -1;
										$t1 = $Tools.wait_a_little_more().catch(function(err) {
											$$ex = err;
											$sm();
										});
										$state = 3;
										$t1.done($sm);
										return;
									}
									case 3: {
										$state = -1;
										$t1.inspect().value;
										$t2 = $Tools.cause_error().catch(function(err) {
											$$ex = err;
											$sm();
										});
										$state = 4;
										$t2.done($sm);
										return;
									}
									case 4: {
										$state = -1;
										$t2.inspect().value;
										$state = -1;
										break $sm2;
									}
									default: {
										break $sm2;
									}
								}
							}
						}
						catch ($t3) {
							ex = ss.Exception.wrap($t3);
							console.log('inside catch msg=' + ex.get_message());
						}
						console.log('finally');
						//TestDone.Test();
						$state = -1;
						break $sm1;
					}
					default: {
						break $sm1;
					}
				}
			}
		};
		$sm();
	};
	global.Program = $Program;
	////////////////////////////////////////////////////////////////////////////////
	// ProgramEs6
	var $ProgramEs6 = function() {
	};
	$ProgramEs6.__typeName = 'ProgramEs6';
	$ProgramEs6.Main = function(args) {
		var $state = 0, $$ex, p, $t1, result, ex;
		var $sm = function() {
			var $doFinally = true;
			$sm1:
			for (;;) {
				switch ($state) {
					case 0: {
						$state = -1;
						p = $ProgramEs6.mypromise();
						//
						//		// traditional
						//
						//		Console.WriteLine("es6 promise started");
						//
						//		p.then(()=>
						//
						//		{
						//
						//		Console.WriteLine("es6 promise resolved");
						//
						//		})
						//
						//		.@catch(()=>
						//
						//		{
						//
						//		Console.WriteLine("es6 promise rejected");
						//
						//		});
						//
						//		Console.WriteLine("es6 promise ended");
						// async/await approach
						console.log('es6 promise started');
						$state = 1;
						continue $sm1;
					}
					case 1:
					case 2:
					case 3: {
						if ($state === 1) {
							$state = 2;
						}
						try {
							if ($$ex !== undefined) {
								throw $$ex;
							}
							$sm2:
							for (;;) {
								switch ($state) {
									case 2: {
										$state = -1;
										$t1 = $ProgramEs6.mypromise().catch(function(err) {
											$$ex = err;
											$sm();
										});
										$state = 3;
										$t1.then($sm);
										$doFinally = false;
										return;
									}
									case 3: {
										$state = -1;
										result = $t1.data_;
										console.log('es6 promise resolved, result=' + result.toString());
										$state = -1;
										break $sm2;
									}
									default: {
										break $sm2;
									}
								}
							}
						}
						catch ($t2) {
							ex = ss.Exception.wrap($t2);
							console.log('es6 promise rejected: ' + ex.get_message());
						}
						finally {
							if ($doFinally) {
								console.log('es6 promise completed!');
							}
						}
						$state = -1;
						break $sm1;
					}
					default: {
						break $sm1;
					}
				}
			}
		};
		$sm();
	};
	$ProgramEs6.mypromise = function() {
		return new Promise(function(resolve, reject) {
			window.setTimeout(function() {
				resolve('ok');
				//reject("err!");
			}, 2000);
		});
	};
	global.ProgramEs6 = $ProgramEs6;
	////////////////////////////////////////////////////////////////////////////////
	// TestDone
	var $TestDone = function() {
	};
	$TestDone.__typeName = 'TestDone';
	$TestDone.Test = function() {
		$Tools.wait_a_little().then(function() {
			return $Tools.cause_error();
		}).done(function() {
			console.log('done');
		});
	};
	global.TestDone = $TestDone;
	////////////////////////////////////////////////////////////////////////////////
	// Tools
	var $Tools = function() {
	};
	$Tools.__typeName = 'Tools';
	$Tools.wait_a_little = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log("'wait_a_little' resolved");
			compl.resolve('this is future result as untyped');
		}, 3000);
		return compl.promise;
	};
	$Tools.wait_another_little = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log("'wait_another_little' resolved");
			compl.resolve('this is future result as typed string');
		}, 1000);
		return compl.promise;
	};
	$Tools.wait_a_little_more = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log("'wait_a_little_more' resolved");
			compl.resolve('risp');
		}, 1000);
		return compl.promise;
	};
	$Tools.cause_error = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log("'cause_error' rejected");
			compl.reject('there was an error');
		}, 1000);
		return compl.promise;
	};
	global.Tools = $Tools;
	ss.initClass($Program, $asm, {});
	ss.initClass($ProgramEs6, $asm, {});
	ss.initClass($TestDone, $asm, {});
	ss.initClass($Tools, $asm, {});
})();

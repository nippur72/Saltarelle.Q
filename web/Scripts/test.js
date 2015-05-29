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
		var $state = 0, $t1, s, $t2;
		var $sm = function() {
			$sm1:
			for (;;) {
				switch ($state) {
					case 0: {
						$state = -1;
						// untyped
						console.log('1 - future started');
						$t1 = $Program.wait_a_little();
						$state = 1;
						$t1.then($sm);
						return;
					}
					case 1: {
						$state = -1;
						s = ss.cast($t1.inspect().value, String);
						console.log('3 - future ended');
						console.log(s);
						// typed
						console.log('1 - future started');
						$t2 = $Program.wait_another_little();
						$state = 2;
						$t2.then($sm);
						return;
					}
					case 2: {
						$state = -1;
						s = $t2.inspect().value;
						console.log('3 - future ended');
						console.log(s);
						// no await, old way
						$Program.wait_a_little_more().then(function(result) {
							console.log(ss.formatString('future resolved with no await! val={0}', result));
						});
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
	$Program.wait_a_little = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log('2 - future resolved');
			compl.resolve('this is future result as untyped');
		}, 3000);
		return compl.promise;
	};
	$Program.wait_another_little = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log('2 - future resolved');
			compl.resolve('this is future result as typed string');
		}, 3000);
		return compl.promise;
	};
	$Program.wait_a_little_more = function() {
		var compl = Q.defer();
		window.setTimeout(function() {
			console.log('future resolved');
			compl.resolve('risp');
		}, 3000);
		return compl.promise;
	};
	global.Program = $Program;
	ss.initClass($Program, $asm, {});
})();

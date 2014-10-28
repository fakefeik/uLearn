﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uLearn.Courses.BasicProgramming.Slides.U07_Complexity
{
	[Slide("Базовые понятия", "{06DFE5F4-512B-4972-BAF5-60B45392D27F}")]
	class S020_BasicTerms
	{
		//#video TmU1e5OuRr4
		/*
		##Задача

		__Задача__ — это соответствие, определяющее зависимость выхода (слова) от входа (слова).

		$\Sigma$ — алфавит (произвольное конечное множество, элементы которого интерпретируются как символы)

		$\Sigma^*$ -- множество всех слов из букв алфавита $\Sigma$.

		$\rho\subset\Sigma^*\times\Sigma^*$ -- бинарное отношение, определяющее задачу. 
		Пара $(x,y)\in\rho$ показывает, что $y$ является допустимым выходом для входа $x$.

		##Алгоритм

		__Алгоритм__ — это последовательность элементарных операций, обрабатывающая входную строку $x$ для получения выходной строки $y$ такой, что $(x,y)\in\rho$

		Под элементарной операцией в этом курсе мы будем понимать операции, исполняющиеся непосредственно на процессоре: сложение чисел, умножение и т.д.

		__Программа__ — это алгоритм, выраженный на некотором языке, который может быть транслирован в элементарные операции

		##Сложность алгоритма

		__Временная сложность алгоритма__ — это функция $f(n)$, $f:N\rightarrow	N$, показывающая точную верхнюю границу количества элементарных операций, необходимых для завершения работы алгоритма, в зависимости от количества символов во входе

		__Емкостная сложность алгоритма__ — аналогичная оценка для __дополнительной__ памяти, необходимой для анализа входа. Память, использующаяся для хранения входа, не учитывается.
		*/
	}
}
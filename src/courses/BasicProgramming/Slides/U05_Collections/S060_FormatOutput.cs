﻿using System;
using uLearn;

namespace Slide08
{
	//#video EXenLjobvwc
	/*
	## Заметки по лекции
	*/
	[Slide("Форматированный вывод", "{458FFA94-D602-4E54-857D-FCEAF5E505FA}")]
	public class S060_FormatOutput
    {
        public static void MainX()
        {

            var a = 13;
            var b = 14.3456789;

            //Всегда можно писать так:
            Console.WriteLine(a + " " + b);

            //Но для больших документов это не удобно. Кроме того, не получится настроить, 
            //например, количество цифр после запятой
            //Используйте форматированный вывод
            Console.WriteLine("{0} {1}", a, b);

            //Для того, чтобы отформатировать строку без вывода, используйте string.Format
            //На самом деле, Console.WriteLine просто вызывает string.Format.
            var formattedString = string.Format("{0} {1}", a, b);

            //Фигурные скобки НЕ ЯВЛЯЮТСЯ спецсимволами шарпа:
            Console.WriteLine("{}"); //Это будет работать!

            //Но они являются спецсимволами метода string.Format, и их нельзя использовать просто так,
            //если вызывается этот метод
            //Console.WriteLine("{0}{}", a); //Это скомпилируется, но выбросит исключение

            //Надо их экранировать удвоением
            Console.WriteLine("{0}{{}}", a);

            //Форматированный вывод позволяет настроить точность округления
            Console.WriteLine("{0:0.000} {1:0.0000}", 1.23456, 1.23456);

            //Вывод завершающих нулей
            Console.WriteLine("{0:0.000} {1:0.###}", 1.2, 1.2);

            //Разбиение на колонки и выравнивание по левому
            Console.WriteLine("{0,10}|\n{1,10}|", 12345, 123);

            //или правому краю
            Console.WriteLine("{0,-10}|\n{1,-10}|", 12345, 123);

            //А также комбинации выравнивания и округления
            Console.WriteLine("{0,10:0.00}|\n{1,10:0.000}|", 1.45, 21.345);

            //И много чего еще. См. документацию к методу string.Format
        }
    }
}
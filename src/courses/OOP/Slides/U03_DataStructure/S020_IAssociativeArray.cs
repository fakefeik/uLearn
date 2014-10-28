﻿using uLearn;

namespace OOP.Slides.U03_DataStructure
{
	[Slide("Задача. Ассоциативный массив", "{6F904BCF-1B0A-46C8-9384-3C0BD28A50C6}")]
	public class S020_IAssociativeArray
	{
        /*
        Данная задача является обязательной.
        Необходимо реализовать ассоциативный массив, где ключом является строка, а значением целое число, с помощью хэш-таблицы, самобалансирующегося дерева поиска (выбрать из предложенных) или списка с пропусками:
        */

        public interface SimpleMap
        {
            int get(string key);
            int put(string key, int value);
            int remove(string key);
        }

        /*
        Операция put возвращает предыдущее значение, которое было ассоциировано с ключом key. Операция remove возвращает значение, которое было ассоциировано с ключом key.
        Не забудьте протестировать вашу реализацию.
        
        Использовать встроенные в Java коллекции (Map, Set, List и производные) нельзя, массивы — можно.
        */
    }
}
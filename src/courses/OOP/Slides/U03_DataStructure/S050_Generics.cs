﻿using System;
using uLearn;

namespace OOP.Slides.U03_DataStructure
{
    [Slide("Задача. Обобщенное программирование", "{BB5A40EC-B9FE-48E8-A441-3F368C65DF12}")]
    public class S050_Generics
    {
        /*
        Решая две предыдущие задачи можно было заметить, что для данных структур данных не важно, 
        над какими типами они работают. Ассоциативный массив, в котором ключами и значениями являются строки, ничем не отличается от ассоциативного массива,
        в котором ключами и значениями являются целые числа. Вместо отдельной реализации под каждую пару типов ключ-значение, 
        желательно иметь одну общую реализацию ассоциативного массива, для которого можно задавать необходимые типы для ключа и значения.
        
        Для решения этой проблемы в языках программирования есть так называемые обобщённые типы (Generic types).
        Они позволяют описать ассоциативный массив следующим образом (здесь TKey — тип ключа, а TValue — тип значения):
        */

        public interface SimpleMap<TKey, TValue>
        {
            TValue get(TKey key);
            TValue put(TKey key, TValue value);
            TValue remove(TKey key);
        }

		/*
        В данном примере TKey и TValue называются типами-параметрами, а SimpleMap<TKey, TValue> — обобщенным типом.
        
        При реализации обобщенных типов часто возникает необходимость наложения ограничений на типы-параметры.
        Например, при реализации ассоциативного массива с помощью самобалансирующегося дерева поиска, необходимо 
        чтобы экземпляры TKey был упорядочиваемыми. 
		
		Одна из возможностей сделать в С# тип упорядочиваемым — реализовать в типе интерфейс
        IComparable(http://msdn.microsoft.com/ru-ru/library/system.icomparable.aspx). 
        Значит, необходимо наложить на TKey следующее ограничение: он должен реализовывать интерфейс IComparable<TKey>:
        */

        public interface IOrderedAssociativeArray<TKey, TValue> where TKey : IComparable<TKey>
        {
            TValue Find(TKey key);
            TValue Insert(TKey key, TValue value);
            TValue Remove(TKey key);
        }

        /*
        
        ## Задача
        Данная задача является обязательной.
        Необходимо реализовать обобщенные варианты IAssosiativeArray и IHeap. 
        Не забудьте протестировать ваши реализации.
        */
    }
}
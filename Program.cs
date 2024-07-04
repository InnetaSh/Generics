//Создайте универсальный класс CustomList<T>, который будет представлять собой список элементов с дополнительными возможностями. Реализуйте следующие функции:

//Добавление элемента: Метод Add(T item) для добавления элемента в список.
//Удаление элемента: Метод Remove(T item) для удаления первого вхождения элемента из списка.
//Получение элемента по индексу: Метод Get(int index) для получения элемента по индексу.
//Поиск элемента: Метод Find(Predicate<T> match) для поиска элемента, соответствующего условию, заданному делегатом Predicate<T>.
//Получение всех элементов: Метод GetAll() для получения всех элементов в виде массива.
//Сортировка элементов: Метод Sort(IComparer<T> comparer) для сортировки элементов списка с использованием переданного компаратора.

using System.Collections.Generic;
using System.Drawing;

var l = new CustomList<int>();
l.Add(1);
l.Add(67);
l.Add(5);
l.Add(-90);
l.Add(5);
l.Print();
Console.WriteLine();

l.Remove(5);
l.Print();
Console.WriteLine();

try { 
var elem = l.Get(4);
Console.WriteLine(elem);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine();


IntTest test = new IntTest();
var x =  l.Find(test.Test);
Console.WriteLine(x);

Comp comparer = new Comp();
var listNew = l.Sort(comparer);
foreach (var item in listNew)
{
    Console.Write($"{item} \t");
}





class CustomList<T>
{
    List<T> list;

    public CustomList()
    {
        list = new List<T>();
    }


    public void Add(T item) //для добавления элемента в список.
    {
        list.Add(item);
    }

    public void Remove(T item) //для удаления первого вхождения элемента из списка.
    {
        list.Remove(item);
    }

    public T Get(int index) //для получения элемента по индексу.
    {
        if (index < 0 || index >= list.Count)
            throw new IndexOutOfRangeException("index is out of range");
        return list[index];
    }

    public T Find(Predicate<T> match) // для поиска элемента, соответствующего условию, заданному делегатом Predicate<T>.
    {
        foreach (var item in list)
            if (match.Invoke(item))
                return item;
        return list[0];
    }

    public T[] GetAll()
    {
        //int count = list.Count;
        //T[] mas = new T[count];
        //for (var i = 0; i < count; i++)
        //{
        //    mas[i] = list[i];
        //}
        //return mas;

        return list.ToArray();
    }
    public List<T> Sort(IComparer<T>comparer)
    {
        List<T> listNew = new List<T>();
        listNew.AddRange(list);

        for (int i = 0; i < listNew.Count; i++)
        {
            for (int j = listNew.Count - 1; j > i; j--)
            {
                if (comparer.Compare(listNew[j], listNew[j - 1]) < 0)
                {
                    T temp = listNew[j];
                    listNew[j] = listNew[j - 1];
                    listNew[j - 1] = temp;
                }
            }
        }

        //listNew.Sort(comparer);
        return listNew;
    }
    public void Print()
    {
        foreach (var item in list)
        {
            Console.Write($"{item} \t");
        }
    }
}

public class IntTest
{
    public bool Test(int x)
    {
        return x < 0;
    }
}

public class Comp : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x > y) return 1;
        if (x < y) return -1;
        return 0;
    }

    
}

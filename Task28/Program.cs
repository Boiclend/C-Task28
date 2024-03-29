﻿using System.Linq.Expressions;
using System.Runtime.InteropServices;

// Составить программу, содержащую стандартный набор функций обработки строк (аналоги си-функций).
//  Программу необходимо реализовать без использования си-функций.

// Интерфейс  создаваемых функций:
// Определение длинны строки, функция должна возвращать количество символов входной строки.
// int lengthString(char *); // прототип функции определения длинны строки
// Функция переворачивает строку и возвращает указатель на перевёрнутую строку, пример:
// входная строка: С++ 
// выходная строка: ++С
// char *reverseString(char *); // прототип функции для переворота (инверсии) строки
// Функция для проверки баланса скобок, то есть количество открытых скобок должно совпадать с количеством закрытых, 
// причём необходимо отличать тип скобочек — круглые, квадратные, фигурные. Функция возвращает значение типа int,
//  если 0 — баланс скобок нарушен, если 1 — баланс скобок выдержан, если -1 скобок во входной строке нет.
// int balanceBrackets(char *); // прототип функции проверки баланса парных скобок
// Функция должна возвращать номер позиции. начиная с которой подстрока входит в строку.
// int occurenceSubstring(char *, char *); // прототип функции поиска первого вхождения подстроки в строку,
//  функция должна возвращать позицию первого вхождения подстроки
// Функция конкатенации строк, но конкатенация выполняется начиная с n-й позиции так,
//  что вторая строка вставляется в первую строку не удалив ни одного из символов первой строки.
//  Возвращаемое значение — строка, полученная после вставки второй в первую строки. Пример:
// входные данные: строка 1 — cpp.com, строка 2 — studio, номер позиции = 4
// результат = cppstudio.com
// char *insertnString (char *, char *, int); // прототип функции вставки строки во вторую строку с указанной позиции
// Функция должна скопировать часть входной строки (k символов), начиная с позиции с номером N.
// char *сutString(char *, int, int); // прототип функции извлечения k символов входной строки, начиная с позиции N


string Message(string text) {
    Console.WriteLine(text);
    string t = Console.ReadLine();
    return t;
}

void stringLenght(string text) 
{
    int count = 0;
    for (int i = 0; i < text.Length; i++)
    {
        count++;
    }
    Console.WriteLine($"Длинна строки = {count}");
}

void reverseString(string text) 
{
    for (int i = text.Length - 1; i >= 0; i--)
    {
        Console.Write(text[i]);
    }
}

void balanceBrackets(string text, int Choice) 
{
Stack<char> braces = new Stack<char>();
bool ok = true;
int index = 0;
char temp = ' ';
string path = @"C:\Users\РомаиЛиля\Desktop\C#Task28\Task28\t.txt";
string xml = " ";
xml = File.ReadAllText(path);
if (Choice == 1)
{
    Console.WriteLine(xml);
    for (int i = 0; i < xml.Length; ++i)
{
    foreach (var c in xml)
    {
        index++;
        switch (c)
        {
            case '<':
                braces.Push(c);
                break;

            case '>':
                if (braces.Count == 0)
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается скобка >, а открытых нет");
                    return;
                }
                temp = braces.Peek();
                if (braces.Pop() != '<') 
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается скобка >, а открыта {temp}");
                    return;
                }
                break;
           
        }
    }   
    if (braces.Count == 0) 
    {
        Console.WriteLine("Последовательность не нарушена");
        return;
    }
    else
    {
        Console.WriteLine($"Проверка не пройдена, имеется лишняя открывающая скобка - {braces.Peek()}, по индексу - {xml.IndexOf(braces.Peek())}");
        return;
    }
}
}
else
{
for (int i = 0; i < text.Length; ++i)
{
    foreach (var c in text)
    {
        index++;
        switch (c)
        {
            case '{':
            case '(':
            case '[':
                braces.Push(c);
                break;

            case '}':
                if (braces.Count == 0)
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается {'}'} скобка, а открытых нет");
                    return;
                }
                temp = braces.Peek();
                if (braces.Pop() != '{') 
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается {'}'} скобка, а открыта {temp}");
                    return;
                }
                break;
            case ']':
                if (braces.Count == 0)
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается ] скобка, а открытых нет");;
                    return;
                }
                temp = braces.Peek();
                if (braces.Pop() != '[')
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается ] скобка, а открыта {temp}");;
                    return;
                } 
                break;
            case ')':
                if (braces.Count == 0)
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается ) скобка, а открытых нет");
                    return;
                }
                temp = braces.Peek();
                if (braces.Pop() != '(') 
                {
                    Console.WriteLine($"ошибка в символе - {index - 1}, закрывается ) скобка, а открыта {temp}");;
                    return;
                } 
                break;
        }
    }   
    if (braces.Count == 0) 
    {
        Console.WriteLine("Полседовательность не нарушена");
        return;
    }
    else
    {
        Console.WriteLine($"Проверка не пройдена, имеется лишняя открывающая скобка - {braces.Peek()}, по индексу - {text.IndexOf(braces.Peek())}");
        return;
    }
}
}
}

void position(string text) {
    Console.WriteLine("Введите подстроку");
    string substring = Console.ReadLine();
    int count = 0;
    int pos = 0;
    for (int i = 0; i < text.Length; i++)
    {
        if(substring[count] != text[i]) 
        {
            count = 0;
            pos = 0;
        }
        if(substring[count] == text[i]) 
        {
            pos = i - substring.Length + 1;
            count++;
        }
        if(count == substring.Length) {
            Console.WriteLine($"Позиция: {pos + 1}");
            return;
        }
    }
    if(pos == 0) 
    {
        Console.WriteLine("Подстрока не найдена");
        return;
    }
    Console.WriteLine($"Позиция: {pos + 1}");
}
    
void insertString(string text) 
{
    int countT = 0;
    int countS = 0;
    int countI = 0;
    Console.WriteLine("Введите строку для конкатенации");
    string inputStr = Console.ReadLine();
    Console.WriteLine("Введите позицию вставки строки");
    int pos = int.Parse(Console.ReadLine());
    string[] resultStr = new string[text.Length + inputStr.Length];
    for (int i = 0; i < resultStr.Length; i++)
    {
        if(i + 1 == pos) 
        {
            countI = i;
            for (int j = 0; j < inputStr.Length; j++)
            {
                resultStr[countI] = inputStr[countS].ToString();
                countS++;
                countI++;
            }
            i = countI;
        }
        resultStr[i] = text[countT].ToString();
        countT++;
    }
    Console.Write("Результат: ");
    for (int i = 0; i < resultStr.Length; i++)
    {
        Console.Write(resultStr[i]);
    }
}

void cutString(string text) 
{
    Console.WriteLine("Введите длину копируемой строки: ");
    int len = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите номер позиции, начиная с которой необходимо скопировать строку: ");
    int pos = int.Parse(Console.ReadLine());
    int index = pos - 1;
    int count = 0;
    string[] strRes = new string[len];
    for (int i = 0; i < text.Length; i++)
    {
        if(count != len) {
            strRes[i] = text[index].ToString();
            count++;
            index++;
        } 
        
    }
    Console.Write("Результат: ");
    for (int i = 0; i < strRes.Length; i++)
    {
        Console.Write(strRes[i]);
    }

}


string word = Message("Введите строку для определения её длины: ");
// stringLenght(word);
// Console.ReadKey();
// word = Message("Введите строку, которую необходимо инвертировать: ");
// reverseString(word);
// Console.ReadKey();
Console.WriteLine("Загрузить проверку из файла? 1 - да / 0 - нет");
int choice = int.Parse(Console.ReadLine());
if (choice != 1) 
{
    word = Message("Введите строку для проверки баланса скобок:");
    balanceBrackets(word, choice);
}
else 
{
    balanceBrackets(word, choice);
}
// Console.ReadKey();
// word = Message("Введите строку для получения позиции подстроки: ");
// position(word);
// word = Message("Введите строку для конкатенации: ");
// insertString(word);
// Console.ReadKey();
// word = Message("Введите строку из которой необходимо скопировать n символов: ");
// cutString(word);
// Console.ReadKey();


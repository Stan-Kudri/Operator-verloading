/* Домашнее задание 12.1 На перегрузку операторов. Описать класс 
комплексных чисел.Реализовать операцию сложения, умножения, вычитания,
проверку на равенство двух комплексных чисел. Переопределить метод
ToString() для комплексного числа. Протестировать на простом примере.*/
using OperatorОverloading;

var comlex1 = new ComplexNumber(10, 5);
var comlex2 = new ComplexNumber(5, 12);
var comlex3 = new ComplexNumber(5, 12);

var complexCombine = comlex1 + comlex2;

Console.WriteLine(complexCombine);

Console.WriteLine(comlex3.Equals(comlex2));
Console.WriteLine(complexCombine.Equals(comlex1));
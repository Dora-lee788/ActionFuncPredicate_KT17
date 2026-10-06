using System;
using System.Collections.Generic;

namespace ActionFuncPredicate_KT17
{
        public class Program
        {
            public static void Main()
            {
                while (true)
                {
                    Console.WriteLine(
                        "\nОбработка очков\n1. Ввести очки и обработать их\n2. Показать разницу Predicate и Func\n0. Выход"
                    );
                
                    Console.Write("\nВыберите действие: ");
                    string choice = Console.ReadLine()!;
                
                    try
                    {
                        if (choice == "0")
                        {
                            Console.WriteLine("\nПрограмма завершена");
                            break;
                        }
                        
                        if (choice == "1")
                        {
                            List<int> scores = new List<int>();
                        
                            Console.Write(
                                "\nВведите количество результатов: "
                            );
                        
                            int count = int.Parse(Console.ReadLine()!);
                        
                            if (count <= 0)
                            {
                                throw new ArgumentException(
                                    "Количество результатов должно быть больше 0"
                                );
                            }
                            
                            for (int i = 0; i < count; i++)
                            {
                                Console.Write(
                                    $"Введите результат {i + 1}: "
                                );
                            
                                int score = int.Parse(Console.ReadLine()!);
                            
                                if (score < 0 || score > 100)
                                {
                                    throw new ArgumentException(
                                        "Количество очков должно быть от 0 до 100"
                                    );
                                }
                                
                                scores.Add(score);
                            }
                            
                            Action<int> printScore = score =>
                                Console.WriteLine($"Очки: {score}");
                        
                            Func<int, int> applyBonus = score =>
                                score + 10;
                        
                            Predicate<int> isPassing = score =>
                                score >= 60;
                        
                            Console.WriteLine(
                                "\nРезультат Action:"
                            );
                        
                            foreach (int score in scores)
                            {
                                printScore(score);
                            }
                            
                            Console.WriteLine(
                                "\nРезультат Func:"
                            );
                        
                            foreach (int score in scores)
                            {
                                Console.WriteLine(
                                    $"Результат для {score}: {applyBonus(score)}"
                                );
                            }

                            int passingScore = scores.Find(isPassing);
                        
                            Console.WriteLine(
                                $"\nПервое проходное значение: {passingScore}"
                            );
                        }
                        else if (choice == "2")
                        {
                            bool IsPassing(int score)
                            {
                                return score >= 60;
                            }
                        
                            Predicate<int> predicate = IsPassing;
                            Func<int, bool> func = IsPassing;
                        
                            Console.WriteLine(
                                $"\nPredicate<int> для 70: {predicate(70)}\nFunc<int, bool> для 70: {func(70)}"
                            );
                        
                            Console.WriteLine(
                                "\nPredicate<int> и Func<int, bool> имеют одинаковую сигнатуру, но являются разными типами делегатов"
                            );
                        
                            Console.WriteLine(
                                "\nFunc<int, bool> нельзя напрямую присвоить переменной Predicate<int>, потому что это разные типы делегатов"
                            );
                        
                        }
                        else
                        {
                            Console.WriteLine(
                                "\nОшибка: такого пункта меню нет"
                            );
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(
                            "\nОшибка: нужно ввести целое число"
                        );
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine(
                            "\nОшибка: введено слишком большое число"
                        );
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(
                            $"\nОшибка: {ex.Message}"
                        );
                    }
                }
            }
        }
 }

    

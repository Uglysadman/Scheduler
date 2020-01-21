using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Schedule schedule = new Schedule();
            while (true)
            {
                Console.WriteLine("1 - Добавить задание в расписание");
                if (schedule.Tasks.Count > 0)
                {
                    Console.WriteLine("2 - Удалить задание из расписания");
                    Console.WriteLine("3 - Редактировать задание из расписания");
                    Console.WriteLine("4 - Отобразить расписание");
                    Console.WriteLine("5 - Сортировать расписание по дате добавления");
                    Console.WriteLine("6 - Сортировать расписание по дате завершения задания");
                    Console.WriteLine("7 - Сохранить в расписание в файл");
                }
                Console.WriteLine("8 - Загрузить расписание из файла");
                Console.WriteLine("9 - Выход");
                Console.Write("Ваш выбор: ");
                try
                {
                    int keyCode = Convert.ToInt32(Console.ReadLine());
                    switch (keyCode)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.Write("Введите название задания: ");
                                string nameTask = Console.ReadLine();
                                Console.Write("Введите дату завершения задания в формате(dd.mm.yyyy ): ");
                                DateTime completionDate = Convert.ToDateTime(Console.ReadLine());
                                schedule.AddTask(nameTask, completionDate);
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.Write("Введите название удаляемой задачи: ");
                                string nameTask = Console.ReadLine();
                                schedule.DeleteTask(nameTask);
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.Write("Введите название редактируемой задачи: ");
                                string nameTask = Console.ReadLine();
                                Console.Write("Введите новое название задачи: ");
                                string newNameTask = Console.ReadLine();
                                Console.Write("Введите новую дату завершения задания в формате(dd.mm.yyyy ):");
                                DateTime completionDate = Convert.ToDateTime(Console.ReadLine());
                                schedule.EditTask(nameTask, new Task(newNameTask, completionDate));
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Console.WriteLine(schedule.PrintTasksList());
                                Console.Write("Нажмите любую клавишу для продолжения ...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                schedule.SortTasksByCreationDate();
                                Console.WriteLine(schedule.PrintTasksList());
                                Console.Write("Нажмите любую клавишу для продолжения ...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                        case 9: return;

                        default:
                            {
                                Console.WriteLine("Вы ввели неверный код !");
                                Thread.Sleep(2500);
                                Console.Clear();
                                break;
                            }
                    }
                } catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }
    }
}

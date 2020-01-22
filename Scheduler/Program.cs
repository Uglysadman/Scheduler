using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;



namespace Scheduler
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static Schedule schedule = new Schedule();

        static bool CheckTasksExist(Schedule schedule)
        {
            if (schedule.Tasks.Count == 0)
            {
                Console.WriteLine("Такой команды нет !");
                WaitInteraction();
                return false;
            }
            return true;
        }

        static void WaitInteraction()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу ...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
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
                    Console.WriteLine("7 - Отобразить список текущих дел");
                    Console.WriteLine("8 - Отобразить список просроченных дел");
                    Console.WriteLine("9 - Сохранить в расписание в файл");
                }
                Console.WriteLine("10 - Загрузить расписание из файла");
                Console.WriteLine("11 - Выход");
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
                                if (!CheckTasksExist(schedule)) { return; } ;
                                Console.Clear();
                                Console.Write("Введите название удаляемой задачи: ");
                                string nameTask = Console.ReadLine();
                                schedule.DeleteTask(nameTask);
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                if (!CheckTasksExist(schedule)) { break; };
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
                        case 5:
                        case 6:
                            {
                                if (!CheckTasksExist(schedule)) { break; };
                                switch (keyCode)
                                {
                                    case 5:
                                        {
                                            schedule.SortTasksByCreationDate();
                                            break;
                                        }
                                    case 6:
                                        {
                                            schedule.SortTasksByCompletionDate();
                                            break;
                                        }
                                }
                                Console.Clear();
                                Console.WriteLine(schedule.PrintTasksList());
                                break;
                            }
                        case 7:
                            {
                                if (!CheckTasksExist(schedule)) { break; };
                                Console.Clear();
                                Console.WriteLine(schedule.PrintCurrentTasks());
                                break;
                            }
                        case 8:
                            {
                                if (!CheckTasksExist(schedule)) { break; };
                                Console.Clear();
                                Console.WriteLine(schedule.PrintOverdueTasks());
                                break;
                            }
                        case 9:
                            {
                                if (!CheckTasksExist(schedule)) { break; };
                                Console.Clear();
                                string path = "Schedule.bin";
                                FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                                BinaryFormatter bformatter = new BinaryFormatter();
                                bformatter.Serialize(fileStream, schedule);
                                fileStream.Close();
                                Console.WriteLine("Расписание было успешно сохранено в файл Schedule.bin в папке с .exe");
                                break;
                            }
                        case 10:
                            {
                                break;
                            }

                        case 11: return;

                        default:
                            {
                                Console.WriteLine("Вы ввели неверный код !");
                                break;
                            }
                    }
                } catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                WaitInteraction();
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab_5
{
    class Program
    {
        static DBworker db = new DBworker();
        static void Main(string[] args)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnection"].ConnectionString;
            //string sql = "SELECT * FROM Library";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    // Создаем объект DataAdapter
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //    // Создаем объект Dataset
            //    DataSet ds = new DataSet();
            //    // Заполняем Dataset
            //    //adapter.Fill(ds);

            //    foreach(DataColumn column in ds.Tables[1].Columns)
            //    {
            //        Console.Write("\t{0}", column.ColumnName);
            //    }
            //    Console.WriteLine();
            //    foreach(DataRow dr in ds.Tables)
            //    {
            //        var cells = dr.ItemArray;
            //        foreach(object cell in cells)
            //        {
            //            Console.Write("\t{0}", cell);
            //        }
            //        Console.WriteLine();
            //    }
            //}

            //Console.WriteLine("Подключение закрыто...");


            //bool b = db.Add(3, "Замовлення книги, 20");
            //if (b)
            //{
            //    Console.WriteLine("Succes");
            //}
            //else
            //{
            //    Console.WriteLine("Failed");
            //}
            //db.Show(3);
            //if(!db.Delete(3, 0))
            //{
            //    Console.WriteLine("Delete failed");
            //}
            //if(db.Edit(3,0,"Замовлення журналу, 10"))
            //{
            //    Console.WriteLine("Edit success");
            //}
            //else
            //{
            //    Console.WriteLine("Edit failed");
            //}
            //db.Show(3);

            GlobalMenu();

            Console.Read();
        }


        private static void Menu()
        {

        }

        private static void GlobalMenu()
        {
            Console.Clear();

            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Select table:");
                int last = 0;
                for (int i = 0; i < db.Tables.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {db.Tables[i]}");
                    last = i;
                }
                Console.WriteLine($"{last + 2}. Exit");
                int index;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out index))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input number isn't corcect");
                    Console.WriteLine();
                }
                else if (index < 1 || index > db.Tables.Length + 1)
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine($"Input less than 1 or more than {db.Tables.Length + 1}");
                    Console.WriteLine();
                }
                else if (index == last + 2)
                {
                    repeat = false;
                }
                else
                {
                    //Console.WriteLine(index);

                    TableMenu(index - 1);
                    Console.Clear();
                    repeat = true;
                }
            }

        }

        private static void TableMenu(int tableNum)
        {
            Console.Clear();

            bool repeat = true;

            while (repeat)
            {
                db.Show(tableNum);
                Console.WriteLine(new string('-', 50));

                Console.WriteLine("Select function:");
                Console.WriteLine("1. Add new row");
                Console.WriteLine("2. Delete row");
                Console.WriteLine("3. Edit row");
                Console.WriteLine("4. Back to previous menu");

                int index;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out index))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input number isn't corcect");
                    Console.WriteLine();

                }
                else
                {
                    switch (index)
                    {
                        case 1:
                            {
                                repeat = true;
                                Add(tableNum);
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                repeat = true;
                                Delete(tableNum);
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                repeat = true;
                                Edit(tableNum);
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                repeat = false;
                                //GlobalMenu();
                                break;
                            }
                        default:
                            {
                                repeat = true;
                                Console.WriteLine();
                                Console.WriteLine("Input less than 1 or more than 4");
                                Console.WriteLine();
                                break;
                            }
                    }
                }

            }

        }

        private static void Add(int tableNum)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Enter new values in one string\n### dividing values using symbol ','\n### enter all columns except table ID");

                string input = Console.ReadLine();

                if (!db.Add(tableNum, input))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input data isn't correct. Try again");
                    Console.WriteLine();
                }
                else
                {
                    repeat = false;
                }

            }
        }

        private static void Delete(int tableNum)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Select No. of row, which will be deleted or 0 if table doesn't have any rows");

                int rowNum;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out rowNum))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input number isn't corcect");
                    Console.WriteLine();

                }
                else if (!db.Delete(tableNum, rowNum - 1))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input number less than 0 or more than latest row number");
                    Console.WriteLine();
                }
                else
                {
                    repeat = false;
                }

            }
        }

        private static void Edit(int tableNum)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Select No. of row, which will be edit or 0 if table is empty");

                int rowNum;
                string input1 = Console.ReadLine();

                Console.WriteLine("Enter new values in one string\n### dividing values using symbol ','\n### enter all columns except table ID");

                string input2 = Console.ReadLine();


                if (!int.TryParse(input1, out rowNum))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input number isn't corcect");
                    Console.WriteLine();

                }
                else if (!db.Edit(tableNum, rowNum - 1, input2))
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input data isn't correct. Try again");
                    Console.WriteLine();
                }
                else
                {
                    repeat = false;
                }

            }
        }

    }


}

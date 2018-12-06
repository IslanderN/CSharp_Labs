using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class DBworker
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnection"].ConnectionString;

        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public string[] Tables { get; private set; } = new string[] { "Library", "Publication", "Reference_Room", "Service" };

        //public DBworker()
        //{
        //    //ds.ta
        //}


        public bool Add(int tableNum, string row)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ////???
                connection.Open();


                //adapter.SelectCommand = new SqlCommand(GetSQL(tableNum), connection);
                //adapter.Fill(ds);

                //DataTable dt = ds.Tables[0];

                //string[] rowData = Spliting(row);
                //if (rowData == null)
                //{
                //    return false;
                //}

                //DataRow newRow = dt.NewRow();
                //for (int i = 0; i < rowData.Length; i++)
                //{
                //    //newRow[i].GetType().

                //    TypeConverter converter = TypeDescriptor.GetConverter(newRow[i].GetType());
                //    if (converter.CanConvertFrom(typeof(string)))
                //    {
                //        newRow[i] = converter.ConvertFromString(rowData[i]);
                //    }
                //    else
                //    {
                //        Console.WriteLine("Cannot convert {0}", newRow[i].GetType());
                //        return false;
                //    }

                //}
                //dt.Rows.Add(newRow);

                //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                //adapter.Update(ds);


                //return true;

                adapter.SelectCommand = new SqlCommand(GetSQL(tableNum), connection);
                adapter.Fill(ds);

                DataRow newRow;

                switch (tableNum)
                {
                    case 0:
                        {
                            newRow = AddLibrary(row, ds.Tables[0].NewRow());
                            if (newRow == null)
                            {
                                connection.Close();
                                return false;
                            }
                            break;
                        }
                    case 1:
                        {
                            newRow = AddPublication(row, ds.Tables[0].NewRow());
                            if (newRow == null)
                            {
                                connection.Close();
                                return false;
                            }

                            break;
                        }
                    case 2:
                        {
                            newRow = AddReferenceRoom(row, ds.Tables[0].NewRow());
                            if (newRow == null)
                            {
                                connection.Close();
                                return false;
                            }
                            break;
                        }
                    case 3:
                        {
                            newRow = AddService(row, ds.Tables[0].NewRow());
                            if (newRow == null)
                            {
                                connection.Close();
                                return false;
                            }
                            break;
                        }
                    default:
                        {
                            connection.Close();
                            return false;

                        }
                }


                ds.Tables[0].Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);

            }
            return true;
        }

        private DataRow AddLibrary(string row, DataRow newRow)
        {
            string[] rowData = row.Split(',');

            string address;
            int allExemplar;
            int avaliableExemplar;
            int abonnementExemplar;

            if (rowData.Length < 4)
            {
                return null;
            }

            address = rowData[0];

            if (!int.TryParse(rowData[1].Replace(" ", string.Empty), out allExemplar))
            {
                return null;
            }
            if (!int.TryParse(rowData[2].Replace(" ", string.Empty), out avaliableExemplar))
            {
                return null;
            }
            if (!int.TryParse(rowData[3].Replace(" ", string.Empty), out abonnementExemplar))
            {
                return null;
            }

            //DataTable dt = ds.Tables[0];
            //DataRow newRow = dt.NewRow();

            newRow["address"] = address;
            newRow["all_exemplar_number"] = allExemplar;
            newRow["available_exemplar_number"] = avaliableExemplar;
            newRow["abonnement_exemplar_number"] = abonnementExemplar;

            //dt.Rows.Add(newRow);

            return newRow;

        }

        private DataRow AddPublication(string row, DataRow newRow)
        {
            string[] rowData = row.Split(',');

            string name;
            float price;
            int libraryId;

            if (rowData.Length < 3)
            {
                return null;
            }
            name = rowData[0];
            if (!float.TryParse(rowData[1].Replace(" ", string.Empty), NumberStyles.Any, CultureInfo.InvariantCulture, out price))
            {
                return null;
            }
            if (!int.TryParse(rowData[2].Replace(" ", string.Empty), out libraryId))
            {
                return null;
            }

            //DataTable dt = ds.Tables[0];
            //DataRow newRow = dt.NewRow();

            newRow["Name"] = name;
            newRow["Price"] = price;
            newRow["Library_ID"] = libraryId;

            //dt.Rows.Add(newRow);

            return newRow;
        }

        private DataRow AddReferenceRoom(string row, DataRow newRow)
        {
            string[] rowData = row.Split(',');

            int seatingCapacity;
            int exemplarNumber;
            int libraryId;

            if (rowData.Length < 3 || !int.TryParse(rowData[0].Replace(" ", string.Empty), out seatingCapacity))
            {
                return null;
            }
            if (!int.TryParse(rowData[1].Replace(" ", string.Empty), out exemplarNumber))
            {
                return null;
            }
            if (!int.TryParse(rowData[2].Replace(" ", string.Empty), out libraryId))
            {
                return null;
            }

            //DataTable dt = ds.Tables[0];
            //DataRow newRow = dt.NewRow();

            newRow["Seating_Capacity"] = seatingCapacity;
            newRow["exemplar_number"] = exemplarNumber;
            newRow["Library_ID"] = libraryId;

            //dt.Rows.Add(newRow);
            return newRow;
        }

        private DataRow AddService(string row, DataRow newRow)
        {
            string[] rowData = row.Split(',');

            string name;
            float price;

            if (rowData.Length < 2)
            {
                return null;
            }
            name = rowData[0];
            if (!float.TryParse(rowData[1].Replace(" ", string.Empty), NumberStyles.Any, CultureInfo.InvariantCulture, out price))
            {
                return null;
            }

            //DataTable dt = ds.Tables[0];
            //DataRow newRow = dt.NewRow();


            newRow["Name"] = name;
            newRow["Price"] = price;

            //dt.Rows.Add(newRow);
            return newRow;
        }

        //private string[] Spliting(string row)
        //{
        //    string[] split = row.Split(',');
        //    if (split.Length != ds.Tables[0].Columns.Count - 1)
        //    {
        //        Console.WriteLine($"{split.Length} != {ds.Tables[0].Columns.Count}");
        //        return null;
        //    }

        //    //for(int i =0;i < ds.Tables[0].Columns.Count; i++)
        //    //{
        //    //    var column = ds.Tables[0].Columns[i];
        //    //    if(split[i].GetType() != column.)
        //    //    {
        //    //        Console.WriteLine($"{split[i].GetType()} != {column.GetType()}");
        //    //        return null;
        //    //    }
        //    //}
        //    return split;
        //}



        public void Show(int tableNum)
        {
            const int size = -30;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GetSQL(tableNum), connection);
                SqlDataReader reader = command.ExecuteReader();


                Console.Write("No.\t");
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i),size}");
                }
                Console.WriteLine();

                if (reader.HasRows)
                {

                    int index = 0;
                    while (reader.Read())
                    {
                        index++;
                        Console.Write(index + "\t");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetValue(i),size}");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }
        }

        public bool Delete(int tableNum, int rowIndex)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                adapter.SelectCommand = new SqlCommand(GetSQL(tableNum), connection);
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count <= rowIndex)
                {
                    connection.Close();

                    if (dt.Rows.Count == 0)
                    {
                        return true;
                    }

                    return false;
                }

                //dt.Rows.Remove();
                dt.Rows[rowIndex].Delete();

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);

                //ds.AcceptChanges();
            }


            return true;
        }

        public bool Edit(int tableNum, int rowIndex, string row)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                adapter.SelectCommand = new SqlCommand(GetSQL(tableNum), connection);
                adapter.Fill(ds);

                if(rowIndex >= ds.Tables[0].Rows.Count)
                {
                    connection.Close();

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return true;
                    }
                    return false;
                }

                //DataTable dt = ds.Tables[0];
                DataRow editRow = ds.Tables[0].Rows[rowIndex];

                switch (tableNum)
                {
                    case 0:
                        {
                            
                            if (AddLibrary(row, editRow) == null)
                            {
                                connection.Close();
                                return false;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (AddPublication(row, editRow) == null)
                            {
                                connection.Close();
                                return false;
                            }

                            break;
                        }
                    case 2:
                        {
                            
                            if (AddReferenceRoom(row, editRow) == null)
                            {
                                connection.Close();
                                return false;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (AddService(row, editRow) == null)
                            {
                                connection.Close();
                                return false;
                            }
                            break;
                        }
                    default:
                        {
                            connection.Close();
                            return false;

                        }
                }

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);

            }
            return true;
        }

        private string GetSQL(int tableNum)
        {
            if (tableNum < 0 || tableNum >= Tables.Length)
            {
                throw new Exception("This number of table or less than 0 either more than Table length");
            }
            return "Select * From " + Tables[tableNum];
        }
    }
}

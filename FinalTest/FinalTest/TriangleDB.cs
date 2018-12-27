using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace FinalTest
{
    class TriangleDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TriangleConnection"].ConnectionString;
        SqlConnection connection;


        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        DataSet dsPoint = new DataSet();
        SqlDataAdapter adaptPoint = new SqlDataAdapter();

        Dictionary<int, double> areas = new Dictionary<int, double>();

        public TriangleDB()
        {
            connection = new SqlConnection(connectionString);
        }

        private void Connect()
        {
            
            connection.Open();

            adapter.SelectCommand = new SqlCommand(GetTriangle(), connection);
            adapter.Fill(ds);

            adaptPoint.SelectCommand = new SqlCommand(GetPoint(), connection);
            adaptPoint.Fill(dsPoint);
        }
        private void Close()
        {
            connection.Close();
        }

        private double Side(int x1, int y1,int x2,int y2)
        {
            double a = x1 - x2;
            double b = y1 - y2;
            return Math.Sqrt(a * a + b * b);
        }
        private double PivPerimetr(double a, double b, double c)
        {
            return (a + b + c) / 2;
        }

        private double Square(double a, double b, double c)
        {
            double pp = PivPerimetr(a, b, c);

            return Math.Sqrt(pp * (pp - a) * (pp - b) * (pp - c));
        }

        private void CalculateAreas()
        {
            DataTable triangle = ds.Tables[0];
            DataTable points = dsPoint.Tables[0];

            foreach(DataRow dr in triangle.Rows)
            {
                int x1 = (int)points.Rows[(int)(dr.ItemArray[1]) - 1].ItemArray[1];
                int y1 = (int)points.Rows[(int)(dr.ItemArray[1]) - 1].ItemArray[2];
                int x2 = (int)points.Rows[(int)(dr.ItemArray[2]) - 1].ItemArray[1];
                int y2 = (int)points.Rows[(int)(dr.ItemArray[2]) - 1].ItemArray[2];
                int x3 = (int)points.Rows[(int)(dr.ItemArray[3]) - 1].ItemArray[1];
                int y3 = (int)points.Rows[(int)(dr.ItemArray[3]) - 1].ItemArray[2];

                double side1 = Side(x1, y1, x2, y2);
                double side2 = Side(x2, y2, x3, y3);
                double side3 = Side(x1, y1, x3, y3);

                double s = Square(side1, side2, side3);

                areas.Add((int)(dr.ItemArray[0]) - 1, s);

            }
        }
        
        public void FindTriangleSquare(double square)
        {
            Connect();
            
            CalculateAreas();

            double min = 100000000;
            double s = 0;
            int minId = 0;

            foreach(var a in areas)
            {
                double r = Math.Abs(a.Value - square);
                if (r < min)
                {
                    min = r;
                    s = a.Value;
                    minId = a.Key;
                }
            }

            OutputTriangle(minId, s);


            Close();
        }

        private void OutputTriangle(int id, double square)
        {

            DataTable triangle = ds.Tables[0];
            DataTable points = dsPoint.Tables[0];

            var dr = triangle.Rows[id];

            int x1 = (int)points.Rows[(int)(dr.ItemArray[1]) - 1].ItemArray[1];
            int y1 = (int)points.Rows[(int)(dr.ItemArray[1]) - 1].ItemArray[2];
            int x2 = (int)points.Rows[(int)(dr.ItemArray[2]) - 1].ItemArray[1];
            int y2 = (int)points.Rows[(int)(dr.ItemArray[2]) - 1].ItemArray[2];
            int x3 = (int)points.Rows[(int)(dr.ItemArray[3]) - 1].ItemArray[1];
            int y3 = (int)points.Rows[(int)(dr.ItemArray[3]) - 1].ItemArray[2];


            Console.WriteLine($"Triangle:\npoints:\n{x1} {y1}\n{x2} {y2}\n{x3} {y3}\nSquare = {square}");
        }

        //private bool SearchPoint(int id, DataTable points)
        //{
        //    foreach(DataRow dr in points.Rows)
        //    {
        //        if(id == (int)dr.ItemArray[0])
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public void Test()
        {
            Connect();

            foreach(DataTable dt in ds.Tables)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr.ItemArray[0]);
                }
            }

            Close();
        }
        private string GetTriangle()
        {
            return "Select * From Triangle";
        }
        private string GetPoint()
        {
            return "Select * From Point";
        }

    }
}

using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdoNetSample1
{
    class Program
    {
        SqlConnection conn = null;
        public Program()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data
 Source=(localdb)\MSSQLLocalDB;
 Initial Catalog=Library;
 Integrated Security=SSPI;";
        }
        public void ReadData()
        {
            SqlDataReader rdr = null;

            string Author = Console.ReadLine();


            try
            {
                //открыть соединение
                conn.Open();
                string sql = @"select * from Books where AuthorId = @p1";
                //создать новый объект command с запросом select
                SqlCommand cmd = new SqlCommand(sql, conn);
                //выполнить запрос select, сохранив
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@p1"; //сопоставление с параметром
                                              //в запросе
                param.SqlDbType = System.Data.SqlDbType.NVarChar;
                //тип параметра
                param1.Value = Author; //значение параметра

                cmd.Parameters.Add(param1);
                //возвращенный результат
                rdr = cmd.ExecuteReader();
                int line = 0; //счетчик строк
                              //извлечь полученные строки
                while (rdr.Read())
                {
                    //формируем шапку таблицы перед выводом
                    //первой строки
                    if (line == 0)
                    {
                        //цикл по числу прочитанных полей
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            //вывести в консольное окно имена полей
                            Console.Write(rdr.GetName(i).
                            ToString() + " ");
                        }
                    }
                    Console.WriteLine();
                    line++;
                    Console.WriteLine(rdr[1] + " " + rdr[2]);
                }
                Console.WriteLine("Обработано записей: " +
                line.ToString());
            }
            finally
            {
                //закрыть reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                //закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.InsertQuery();
            pr.ReadData();
        }
        public void InsertQuery()
        {
            try
            {
                //открыть соединение
                conn.Open();
                //подготовить запрос insert
                //в переменной типа string
                string insertString = @"insert into
 Authors (FirstName, LastName)
 values ('Roger', 'Zelazny')";
                //создать объект command,
                //инициализировав оба свойства
                SqlCommand cmd =
                new SqlCommand(insertString, conn);

                //выполнить запрос, занесенный
                //в объект command
                cmd.ExecuteNonQuery();
            }
            finally
            {// закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}



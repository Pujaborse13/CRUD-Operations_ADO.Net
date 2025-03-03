using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp
{
   internal class CRUD_Operations
    {       
        public void Crud_OP()
        {

            SqlConnection sqlConnection;
            string connectionString = @"Server=DESKTOP-U16P3F3\SQLEXPRESS; Database=UserData; Integrated Security=True; TrustServerCertificate=True;";

             try
              {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    Console.WriteLine("Coonnection establish Sucessfully");

                //CRUD Operations 
                
                //Create = C           
                Console.Write("Enter your name :");
                string userName = Console.ReadLine();
                Console.Write("Enter your age :");
                int userAge = int.Parse(Console.ReadLine());
                string insertQuery = "Insert Into Details(user_name,user_age) Values('" + userName + "'," + userAge + ")";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Data Sucessfully inserted into Table");

                //Retrive = R
                string displayQuery = "SELECT * FROM Details";
                SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                SqlDataReader dataReader = displayCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine("ID :" + dataReader.GetValue(0).ToString());
                    Console.WriteLine("Name :" + dataReader.GetValue(1).ToString());
                    Console.WriteLine("Age :" + dataReader.GetValue(2).ToString());

                }

                dataReader.Close();

                //Update = U
                int u_id;
                int u_age;
                Console.Write("Enter User id that you want to update");
                u_id = int.Parse(Console.ReadLine());

                Console.Write("Enter User Age that you want to Set");
                u_age = int.Parse(Console.ReadLine());


                string updateQuery = "UPDATE Details SET user_age = " + u_age + " WHERE user_id =" + u_id + "";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);

                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Data Updated Sucessfully");


                //Delete = D

                int d_id;

                    Console.Write("Enter user id that you want to delete");
                    d_id = int.Parse(Console.ReadLine());

                    string deleteQuery = "DELETE FROM details Where user_id = " + d_id + "";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);

                    deleteCommand.ExecuteNonQuery();
                    Console.WriteLine("Deletion sucessfully !");


                    sqlConnection.Close();

                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }



            }
        }


}


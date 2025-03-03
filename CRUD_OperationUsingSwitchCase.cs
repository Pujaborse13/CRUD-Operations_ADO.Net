using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp
{
   public class CRUD_OperationUsingSwitchCase
   {
        public void Crud_OPUsingSwicth()

        {
            string connectionString = @"Server=DESKTOP-U16P3F3\SQLEXPRESS; Database=UserData; Integrated Security=True; TrustServerCertificate=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString); ;
            sqlConnection.Open();

            try
            {
                Console.WriteLine("Coonnection establish Sucessfully");
                string answer;

                do
                {
                    Console.WriteLine("Select  from the options Below");
                    Console.WriteLine("1.Creation \n2.Retrive \n3.Update \n4.Delete");
                    Console.WriteLine("_________________________________________________");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:

                            //Create CRUD
                            //Create = C           
                            Console.Write("Enter your name :");
                            string userName = Console.ReadLine();
                            Console.Write("Enter your age :");
                            int userAge = int.Parse(Console.ReadLine());

                            string insertQuery = "INSERT INTO Details(user_name,user_age) VALUES('" + userName + "'," + userAge + ")";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data sucessfully inserted into Table");
                            break;

                        case 2:
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
                            break;


                        case 3:



                            //Update = U
                            int u_id;
                            int u_age;
                            Console.WriteLine("Enter User id that you want to update");
                            u_id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter User Age that you want to Set");
                            u_age = int.Parse(Console.ReadLine());


                            string updateQuery = "UPDATE Details SET user_age = " + u_age + " WHERE user_id =" + u_id + "";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);

                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data Updated Sucessfully");
                            break;


                        case 4:

                            //Delete = D

                            int d_id;

                            Console.WriteLine("Enter user id that you want to delete");
                            d_id = int.Parse(Console.ReadLine());

                            string deleteQuery = "DELETE FROM details WHERE user_id = " + d_id + "";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);

                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deletion sucessfully !");
                            break;




                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    Console.WriteLine("Do you Want To Continue Y/N?");
                    answer = Console.ReadLine();

                }
                while (answer != "N");


            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            finally
            {
                sqlConnection.Close();
            }

        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;

namespace CapPizzaStore.Models
{
    public class DBConnection
    {
        private OleDbConnection aConnection = new OleDbConnection();

        public void InsertPizzaOrder(CartItem item, double totalCost)
        {
            aConnection.ConnectionString = @"Provider=SQLOLEDB;Data Source=NOVINSKII-HP;Initial Catalog=LuwinskiPizza;Integrated Security=SSPI;";

            using (OleDbConnection aCon = new OleDbConnection(aConnection.ConnectionString))
            {
                using (OleDbCommand aCommand = new OleDbCommand("InsertOrder", aCon))
                {
                    aCon.Open();
                    aCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    while (aReader.Read())
                    {
                        aCon.Open();
                        aCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        aCommand.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = item.ViewModel.Name;
                        aCommand.Parameters.AddWithValue("@amt", SqlDbType.Int).Value = item.Quant;
                        aCommand.Parameters.AddWithValue("@desc", SqlDbType.VarChar).Value = item.Pizza.GetDescription();
                        aCommand.Parameters.AddWithValue("@cost", SqlDbType.Decimal).Value = item.Pizza.GetCost();
                        aCommand.Parameters.AddWithValue("@time", SqlDbType.DateTime).Value = item.ViewModel.DeliveryTime;
                        aCommand.Parameters.AddWithValue("@deliver", SqlDbType.Bit).Value = item.ViewModel.Delivery;
                        aCommand.Parameters.AddWithValue("@addy", SqlDbType.VarChar).Value = item.ViewModel.Address;
                        aCommand.Parameters.AddWithValue("@city", SqlDbType.VarChar).Value = item.ViewModel.City;
                        aCommand.Parameters.AddWithValue("@zip", SqlDbType.VarChar).Value = item.ViewModel.Zip;
                        aCommand.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = item.ViewModel.Phone;
                        aCommand.Parameters.AddWithValue("@total", SqlDbType.VarChar).Value = totalCost;
                        aCommand.ExecuteNonQuery();
                        aConnection.Close(); 

                    }

                    aConnection.Close();
                }
            }

            return;
        }
    }
}
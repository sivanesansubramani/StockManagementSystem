using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Inventory.Models;

namespace Inventory.Repository
{
    public class ProductStockRepository
    {
       
            public readonly string connectionString;


            public ProductStockRepository()
            {

                connectionString = @"Data Source = DESKTOP-Q5KI2MS; Initial Catalog = Inventory; Integrated Security = True";
            }


            public void InsertProductData(ProductDetailsModels bio)
            {
                try
                {

                    SqlConnection connectionObject = new SqlConnection(connectionString);

                    connectionObject.Open();
                    connectionObject.Execute($"exec InsertProduct '{bio.ProducatName}','{bio.VendorName}',{bio.RetailPrice},{bio.SellingPrice},{bio.ProductCount} ");


                    connectionObject.Close();

                }
                catch (SqlException e)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public List<ProductDetailsModels> Select()
            {
                try
                {
                    List<ProductDetailsModels> ListofPersonalData = new List<ProductDetailsModels>();

                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    ListofPersonalData = connection.Query<ProductDetailsModels>("exec SellectAllProducta", connectionString).ToList();
                    connection.Close();



                    return ListofPersonalData;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        public List<ProductDetailsModels> SelectCustomerDetails()
        {
            try
            {
                List<ProductDetailsModels> ListofPersonalData = new List<ProductDetailsModels>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                ListofPersonalData = connection.Query<ProductDetailsModels>("select * from ProductCustomerDB;", connectionString).ToList();
                connection.Close();



                return ListofPersonalData;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public List<ProductDetailsModels> SelectProduct()

        {
            try
            {
                List<ProductDetailsModels> ListofPersonalData = new List<ProductDetailsModels>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                ListofPersonalData = connection.Query<ProductDetailsModels>("select ProducatName from ProductDetailsDB;", connectionString).ToList();
                connection.Close();



                return ListofPersonalData;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public void ubdate(ProductDetailsModels bio)
            {
                try
                {
                    SqlConnection connectionObject = new SqlConnection(connectionString);



                    connectionObject.Open(); // Age = @Age, Address = @Address where id = @id

                    connectionObject.Execute($"exec UbdateProductStock {bio.Productid},'{bio.ProducatName}','{bio.VendorName}',{bio.RetailPrice},{bio.SellingPrice},{bio.ProductCount} ");


                    connectionObject.Close();
                }
                catch (SqlException e)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

        }

        public void ubdateSales(ProductDetailsModels bio)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);

                var PurchaseCount = bio.PurchaseCount;
                var ProducatName = bio.ProducatName;
                var CustomerName = bio.CustomerName;
                var VendorName = bio.VendorName;

                connectionObject.Open(); // Age = @Age, Address = @Address where id = @id

                connectionObject.Execute($"exec UbdatesalesStock '{ProducatName}','{VendorName}','{CustomerName}',{PurchaseCount}");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void delete(int Id)
            {
                try
                {
                    SqlConnection connectionObject = new SqlConnection(connectionString);

                 
                    connectionObject.Open();
                    connectionObject.Execute($"exec DeleteProduct {Id} ");


                    connectionObject.Close();
                }
                catch (SqlException e)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


            public ProductDetailsModels SelectSP(int id)
            {
                try
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    var res = connection.QueryFirst<ProductDetailsModels>($"exec SellectAllProductwithID {id}");
                    connection.Close();

                    return res;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        

    }
}

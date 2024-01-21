using ConsoleTables;
using E_CommerceAppUsingADO.NET.BL.Enums;
using E_CommerceAppUsingADO.NET.BL.Methods;
using E_CommerceAppUsingADO.NET.BL.Models;
using E_CommerceAppUsingADO.NET.BL.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.PL
{
     class ProductUI
    {
        public static void CRUDProduct()
        {
            Console.WriteLine("1-Add Product");
            Console.WriteLine("2-Update Product");
            Console.WriteLine("3-Delete Product");
            Console.WriteLine("4-Search Product");
            Console.WriteLine("5-Get All Product");
            int ch;
            do
            {
                ch = Console.ReadKey().KeyChar;
                CRUD prodcutOperation = (CRUD)ch;
                switch (prodcutOperation)
                {
                    case CRUD.Create:
                        Add();
                        break;
                    case CRUD.GetById:
                        SearchProduct();
                        break;
                    case CRUD.Update:
                        Update();
                        break;
                    case CRUD.Delete:
                        Delete();
                        break;
                }

            } while (ch >= 49 && ch <= 52);
        }
        public static void PrintProducts(List<Product> products)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var table = new ConsoleTable( " Name ", " Price ", " Quantity ", "Description" , "Category");
            foreach (Product product in products)
            {
                    table.AddRow(product.Name, product.Price,product.Quantity==0?"Out OF Stock":product.Quantity, product.Description, CategoryMethods.GetById(product.CategoryId).Name);
            }
            table.Write();
            Console.ResetColor();
        }
        public static void SearchProduct()
        {
            //string name =  ProductValidations.validProductName();
            //DataTable dataTable = Productmethods.GetByName(name);
            //if (!ProductValidations.FindProductByName(name))
            //    BaseValidation.DisplayTextWithRedColor("Product Not Found!");
            //else
            //{
            //    Product product = new Product();
            //    product.Id = Convert.ToInt32(dataTable.Rows[0][0]);
            //    product.Name = Convert.ToString(dataTable.Rows[0][1]);
            //    product.Quantity = Convert.ToInt32(dataTable.Rows[0][2]);
            //    product.Price = Convert.ToDecimal(dataTable.Rows[0][3]);
            //    product.Description = Convert.ToString(dataTable.Rows[0][4]);
            //    product.CategoryId = Convert.ToInt32(dataTable.Rows[0][5]);
            //    PrintProducts(new List<Product>() { product });

            //}
            Product product = ProductValidations.checkProductNameValidation();
            PrintProducts(new List<Product>() { product });
            Console.ReadKey();
         //   return dataTable.Rows.Count!=0;
        }
        public static void Add()
        {
            Productmethods.Create(AddOrUpdate());
            BaseValidation.DisplayTextWithGreenColor("Product Added Successfully......");
        }
        public static void Update()
        {
            Product product = new Product();
            int productId;
            //int count = 0;
            //string productName;
            //do {
            //     productName = ProductValidations.validProductName();
            //    count = Productmethods.GetByName(productName).Rows.Count;
            //    if (count == 0)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("This Product Not Exist");
            //        Console.ResetColor();
            //    }
            //} while (count==0);
            //int productId = Convert.ToInt32(Productmethods.GetByName(productName).Rows[0][0]);
            productId = ProductValidations.checkProductNameValidation().Id;
            product = AddOrUpdate();
            Productmethods.Update(product, productId);
            BaseValidation.DisplayTextWithGreenColor("Updated Successfully......");
        }
        public static void Delete()
        {
            int productId = ProductValidations.checkProductNameValidation().Id;
            Productmethods.Delete(productId);
            BaseValidation.DisplayTextWithGreenColor("Product Deleted .....");
        }
        public static Product AddOrUpdate()
        {
            Product product = new Product();
            product.Name= ProductValidations.validProductName();
            product.Price = ProductValidations.validProductPrice();
            product.Quantity = ProductValidations.validProductQuantity();
            product.Description = ProductValidations.validProductDescription();
            product.CategoryId = CategoryValidations.FindCatgoryIdByName().Id;
            return product;
        }
    }
}

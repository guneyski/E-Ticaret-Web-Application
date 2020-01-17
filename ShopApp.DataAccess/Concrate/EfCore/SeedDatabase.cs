using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrate.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Categories.Count()==0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories =
        {
            //new Category(){Name="Programlama Dili"},
            //new Category(){Name="Back-End"},
            //new Category(){Name="Front-End"},
            //new Category(){Name="Şirket"}
        };

        private static Product[] Products =
        {
            //new Product(){Name="Python", Price=1, ImageUrl="python.png", Description="<p>Etiket</p>"},
            //new Product(){Name="JavaScript", Price=1, ImageUrl="js.png", Description="<p>Etiket</p>"},
            //new Product(){Name="React Native", Price=1, ImageUrl="react-black.png", Description="<p>Etiket</p>"},
            //new Product(){Name="Java", Price=1, ImageUrl="java.svg_.png.png", Description="<p>Etiket</p>"},
            //new Product(){Name="HTML5", Price=1, ImageUrl="html5.png", Description="<p>Etiket</p>"},
            //new Product(){Name="CSS3", Price=1, ImageUrl="css3.png.png", Description="<p>Etiket</p>"},
            //new Product(){Name="Unity", Price=1, ImageUrl="unity.svg_.png.png", Description="<p>Etiket</p>"},
            //new Product(){Name="Docker", Price=1, ImageUrl="docker.png", Description="<p>Etiket</p>"},
            //new Product(){Name="NodeJs", Price=1, ImageUrl="node-new.jpg.png", Description="<p>Etiket</p>"},
            //new Product(){Name="Visual Studio", Price=1, ImageUrl="visual-studio.jpg.png", Description="<p>Etiket</p>"},
            //new Product(){Name="Google", Price=1, ImageUrl="google-logo.png", Description="<p>Etiket</p>"},
            //new Product(){Name="Linux", Price=1, ImageUrl="tux.png", Description="<p>Etiket</p>"},
            //new Product(){Name="C++", Price=1, ImageUrl="c.svg_.png.png", Description="<p>Etiket</p>"},
        };

        private static ProductCategory[] ProductCategory =
        {
            //new ProductCategory() {Product = Products[0],Category=Categories[0]},
            //new ProductCategory() {Product = Products[0],Category=Categories[1]},
            //new ProductCategory() {Product = Products[1],Category=Categories[0]},
            //new ProductCategory() {Product = Products[1],Category=Categories[1]},
            //new ProductCategory() {Product = Products[1],Category=Categories[2]},
            //new ProductCategory() {Product = Products[2],Category=Categories[2]},
            //new ProductCategory() {Product = Products[3],Category=Categories[0]},
            //new ProductCategory() {Product = Products[3],Category=Categories[1]},
            //new ProductCategory() {Product = Products[4],Category=Categories[2]},
            //new ProductCategory() {Product = Products[5],Category=Categories[2]},
            //new ProductCategory() {Product = Products[6],Category=Categories[3]},
            //new ProductCategory() {Product = Products[7],Category=Categories[3]},
            //new ProductCategory() {Product = Products[8],Category=Categories[1]},
            //new ProductCategory() {Product = Products[8],Category=Categories[2]},
            //new ProductCategory() {Product = Products[9],Category=Categories[3]},
            //new ProductCategory() {Product = Products[10],Category=Categories[3]},
            //new ProductCategory() {Product = Products[11],Category=Categories[3]},
            //new ProductCategory() {Product = Products[12],Category=Categories[0]},
            //new ProductCategory() {Product = Products[12],Category=Categories[1]},
        };
    }

}

using E_commerace.Domain.Entities.Products;
using E_commerace.Persistence.Context;
using E_commerace.Persistence.Identity.Context;
using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Identity;
using E_Commerace.Domain.Entities.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerace.Persistence.DbInitailzers
{
    public class DbInitializer(StoreDbContext storeDbContext, 
        AppIdentityDbContext appIdentityDbContext,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager



        ) : IDbInitializer
    {
        public void Initialize()
        {
            storeDbContext.Database.Migrate();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (!storeDbContext.ProductBrands.Any())
            {
                var brands = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\brands.json");
                var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brands, options);
                if (productBrands is not null && productBrands.Count > 0)
                {
                    storeDbContext.ProductBrands.AddRange(productBrands);

                }
            }
            if (!storeDbContext.ProductTypes.Any())
            {
                var types = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(types, options);
                if (productTypes is not null && productTypes.Count > 0)
                {
                    storeDbContext.ProductTypes.AddRange(productTypes);
                }
            }
            if (!storeDbContext.Products.Any())
            {
                var products = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\products.json");
                var productList = JsonSerializer.Deserialize<List<Product>>(products, options);
                if (productList is not null && productList.Count > 0)
                {
                    storeDbContext.Products.AddRange(productList);

                }
            }

                if (!storeDbContext.DeliveryMethods.Any())
                {
                    var deliveryMethods = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\delivery.json");
                    var deliveryMethodList = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethods, options);
                    if (deliveryMethodList is not null && deliveryMethodList.Count > 0)
                    {
                        storeDbContext.DeliveryMethods.AddRange(deliveryMethodList);

                    }
                }
                storeDbContext.SaveChanges();
        }

       public async Task  IdentityInitialize()
        {
            appIdentityDbContext.Database.Migrate();
            try
            {
                bool HasUsers = userManager.Users.Any();
                bool HasRoles = roleManager.Roles.Any();
             
                if (!HasRoles)
                {
                    var Roles = new List<IdentityRole>()
                {
                    new IdentityRole(){Name = "SuperAdmin"},
                    new IdentityRole(){Name = "Admin"}
                };

                    foreach (var Role in Roles)
                    {
                        if (!roleManager.RoleExistsAsync(Role.Name!).Result)
                        {
                          await  roleManager.CreateAsync(Role);
                        }
                    }
                }
                // ---------- USER ----------
                if (!HasUsers)
                {
                    var MainAdmin = new AppUser()
                    {
                        DisplayName = "Aliaa Tarek",
                        UserName = "AliaaTarek",
                        Email = "Aliaatarek@gmail.com",
                        PhoneNumber = "01123652635"
                    };

                 await    userManager.CreateAsync(MainAdmin, "P@ssw0rd");
                  await   userManager.AddToRoleAsync(MainAdmin, "SuperAdmin");

                    var Admin01 = new AppUser()
                    {
                        DisplayName = "Omar Mohamed",
                        UserName = "OmarMohamed",
                        Email = "OmarMohamed@gmail.com",
                        PhoneNumber = "01232589652"
                    };

                 await    userManager.CreateAsync(Admin01, "P@ssw0rd");
                 await    userManager.AddToRoleAsync(Admin01, "Admin");
                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding Failed : {ex}");

            }
        }
            
            
        }
    }

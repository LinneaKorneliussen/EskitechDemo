using EskitechDemo.Data;
using EskitechDemo.Models;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
    {
        if (await context.Products.AnyAsync())
        {
            return;
        }

        #region Data Products And Inventory
        var product1 = new Product("S1001", "Allmountainskidor", "Mångsidiga skidor för alla typer av terräng.", 5999.00m, ProductCategory.Skidor);
        var product2 = new Product("S1002", "Freestyle Snowboard", "Snowboard för tricks och åkning i park.", 3999.00m, ProductCategory.Snowboards);
        var product3 = new Product("S1003", "Alpina Skidpjäxor", "Pjäxor med hög prestanda för alpinskidåkning.", 2999.00m, ProductCategory.Skidpjäxor);
        var product4 = new Product("S1004", "Skidjacka", "Vattentät skidjacka med bra andningsförmåga.", 1999.00m, ProductCategory.Skidkläder);
        var product5 = new Product("S1005", "Vinterhandskar", "Vattentåliga och varma vinterhandskar.", 499.00m, ProductCategory.Vinterhandskar);
        var product6 = new Product("S1006", "Ryggsäck för skidåkning", "Ryggsäck designad för skidåkning och snowboard.", 899.00m, ProductCategory.Ryggsäckar);
        var product7 = new Product("S1007", "Skidstavar", "Lätta och hållbara skidstavar.", 599.00m, ProductCategory.Skidutrustning);
        var product8 = new Product("S1008", "Skidglasögon", "Skidglasögon med UV-skydd och anti-dimma.", 899.00m, ProductCategory.Skidutrustning);
        var product9 = new Product("S1009", "Alpina Skridskor", "Skridskor för både nybörjare och avancerade åkare.", 799.00m, ProductCategory.Skridskor);
        var product10 = new Product("S1010", "Snöskor", "Robusta snöskor för vintervandring i djup snö.", 1499.00m, ProductCategory.Snöskor);
        var product11 = new Product("S1011", "Skidjacka Vinter", "Varm och vattentålig skidjacka för vinterförhållanden.", 2499.00m, ProductCategory.Skidkläder);
        var product12 = new Product("S1012", "Skidbyxor", "Bekväma och funktionella skidbyxor för alla väder.", 1499.00m, ProductCategory.Skidkläder);
        var product13 = new Product("S1013", "Fleecejacka", "Mjuka och varma fleecejackor för skidåkning och vinterutomhusaktiviteter.", 899.00m, ProductCategory.Skidkläder);

        context.Products.AddRange(new[] { product1, product2, product3, product4, product5, product6, product7, product8, product9, product10, product11, product12, product13 });

        var inventory1_LagerA = new Inventory(100, "Lager A", product1);
        var inventory1_LagerB = new Inventory(50, "Lager B", product1); 
        product1.Inventories.Add(inventory1_LagerA);
        product1.Inventories.Add(inventory1_LagerB);

        var inventory2_LagerA = new Inventory(50, "Lager A", product2);
        var inventory2_LagerB = new Inventory(30, "Lager B", product2); 
        product2.Inventories.Add(inventory2_LagerA);
        product2.Inventories.Add(inventory2_LagerB);

        var inventory3_LagerA = new Inventory(75, "Lager A", product3);
        product3.Inventories.Add(inventory3_LagerA);

        var inventory4_LagerA = new Inventory(200, "Lager A", product4);
        var inventory4_LagerB = new Inventory(100, "Lager B", product4); 
        product4.Inventories.Add(inventory4_LagerA);
        product4.Inventories.Add(inventory4_LagerB);

        var inventory5_LagerA = new Inventory(50, "Lager A", product5);
        product5.Inventories.Add(inventory5_LagerA);

        var inventory6_LagerA = new Inventory(70, "Lager A", product6);
        product6.Inventories.Add(inventory6_LagerA);

        var inventory7_LagerA = new Inventory(60, "Lager A", product7);
        var inventory7_LagerB = new Inventory(30, "Lager B", product7); 
        product7.Inventories.Add(inventory7_LagerA);
        product7.Inventories.Add(inventory7_LagerB);

        var inventory8_LagerA = new Inventory(100, "Lager A", product8);
        product8.Inventories.Add(inventory8_LagerA);

        var inventory9_LagerA = new Inventory(90, "Lager A", product9);
        product9.Inventories.Add(inventory9_LagerA);

        var inventory10_LagerA = new Inventory(150, "Lager A", product10);
        product10.Inventories.Add(inventory10_LagerA);

        var inventory11_LagerA = new Inventory(120, "Lager A", product11);
        var inventory11_LagerB = new Inventory(60, "Lager B", product11); 
        product11.Inventories.Add(inventory11_LagerA);
        product11.Inventories.Add(inventory11_LagerB);

        var inventory12_LagerA = new Inventory(150, "Lager A", product12);
        product12.Inventories.Add(inventory12_LagerA);

        var inventory13_LagerA = new Inventory(100, "Lager A", product13);
        product13.Inventories.Add(inventory13_LagerA);

        context.Inventories.AddRange(new[] {
            inventory1_LagerA, inventory1_LagerB, inventory2_LagerA, inventory2_LagerB,
            inventory3_LagerA, inventory4_LagerA, inventory4_LagerB, inventory5_LagerA,
            inventory6_LagerA, inventory7_LagerA, inventory7_LagerB, inventory8_LagerA,
            inventory9_LagerA, inventory10_LagerA, inventory11_LagerA, inventory11_LagerB,
            inventory12_LagerA, inventory13_LagerA
        });
        #endregion

        await context.SaveChangesAsync();
    }
}

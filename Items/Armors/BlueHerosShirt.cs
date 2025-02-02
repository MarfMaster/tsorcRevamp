﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class BlueHerosShirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Hero's Shirt");
            Tooltip.SetDefault("Set bonus grants extended breath & swimming skills plus 6% all stats boost\nAlso, +3 life regen speed, faster movement & hunter vision while in water");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 16;
            Item.value = 2500;
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HerosShirt, 1);
            recipe.AddIngredient(ItemID.Flipper, 1);
            recipe.AddIngredient(ItemID.DivingHelmet, 1);
            recipe.AddIngredient(ItemID.MythrilBar, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 3000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();

            Terraria.Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.HerosShirt, 1);
            recipe2.AddIngredient(ItemID.DivingGear, 1);
            recipe2.AddIngredient(ItemID.MythrilBar, 3);
            recipe2.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 3000);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ItemID.HerosShirt, 1);
            recipe3.AddIngredient(ItemID.JellyfishDivingGear, 1);
            recipe3.AddIngredient(ItemID.MythrilBar, 3);
            recipe3.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 3000);
            recipe3.AddTile(TileID.DemonAltar);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe();
            recipe4.AddIngredient(ItemID.HerosShirt, 1);
            recipe4.AddIngredient(ItemID.ArcticDivingGear, 1);
            recipe4.AddIngredient(ItemID.MythrilBar, 3);
            recipe4.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 3000);
            recipe4.AddTile(TileID.DemonAltar);
            recipe4.Register();
        }
    }
}

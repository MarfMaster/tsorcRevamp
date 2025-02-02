﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class RedHerosShirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Hero's Shirt");
            Tooltip.SetDefault("The legendary clothes of the master.\nSet bonus: Lava, fire block & knockback immunity\nPlus extended breath, water walk, & swim\n+14% to all stats and +4 life regen while in lava & +2 in water");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 20;
            Item.value = 2500;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("BlueHerosShirt").Type, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 20000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
    }
}

﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientGoldenArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A lost prince's armor.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 8;
            Item.value = 1800000;
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldChainmail, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 500);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
    }
}

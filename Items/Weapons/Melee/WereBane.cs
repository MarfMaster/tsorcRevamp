﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Melee
{
    class WereBane : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WereBane");
            Tooltip.SetDefault("A sword used to kill werewolves instantly." +
                                "\nDoes 8x damage to werewolves.");
        }
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.damage = 32;
            Item.height = 42;
            Item.knockBack = 9;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.value = PriceByRarity.LightRed_4;
            Item.width = 42;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBroadsword, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 500);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (target.type == NPCID.Werewolf) damage *= 16;
        }
    }
}

﻿using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Magic
{
    class FreezeBolt3 : ModItem
    {

        public override string Texture => "tsorcRevamp/Items/Weapons/Magic/FreezeBolt2";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freeze Bolt III");
            Tooltip.SetDefault("Casts a super fast-moving bolt of ice");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.damage = 150;
            Item.knockBack = 8;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item21;
            Item.rare = ItemRarityID.Cyan;
            Item.shootSpeed = 11;
            Item.mana = 12;
            Item.value = PriceByRarity.Cyan_9;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<Projectiles.FreezeBolt>();
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("FreezeBolt2").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("SoulOfAttraidies").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("BlueTitanite").Type, 10);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 150000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
    }
}

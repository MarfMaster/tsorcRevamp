﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Ranged
{
    class ExpulsorCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Four shot burst" +
                                "\nOnly the first shot consumes ammo" +
                                "\nFires a spread of four bullets with each shot");
        }
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 16;
            Item.useTime = 4;
            Item.reuseDelay = 18;
            Item.damage = 50;
            Item.knockBack = 3;
            Item.crit = 5;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item11;
            Item.rare = ItemRarityID.Purple;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 13;
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.value = PriceByRarity.Purple_11;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("QuadroCannon").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("GuardianSoul").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("FlameOfTheAbyss").Type, 30);
            //recipe.AddIngredient(Mod.Find<ModItem>("SoulOfBlight").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("SoulOfChaos").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("CursedSoul").Type, 90);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 280000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockBack)
        {
            int ShotAmt = 4;
            int spread = 24;
            float spreadMult = 0.05f;
            type = ModContent.ProjectileType<Projectiles.PhazonRound>();
            for (int i = 0; i < ShotAmt; i++)
            {
                float vX = speed.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speed.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, new Vector2(vX, vY), type, damage, knockBack, player.whoAmI);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
            }
            return false;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !(player.itemAnimation < Item.useAnimation - 2);
        }
    }
}

﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Magic
{
    class Ice3Tome : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice 3 Tome");
            Tooltip.SetDefault("A lost tome fabled to deal great damage.\n" +
                                "\nSlows and occasionally freezes enemies" +
                                "Only mages will be able to realize this tome's full potential. \n" +
                                "Can be upgraded with 80,000 Dark Souls");

        }

        //This stores the original, true mana cost of the item. We have to change item.mana later to cause it to use less/none while it's not actually firing
        int storeManaCost3;
        public override void SetDefaults()
        {
            Item.autoReuse = true; //why was it the only one without autoreuse?
            Item.damage = 32;
            Item.height = 10;
            Item.knockBack = 0f;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.LightRed;
            Item.scale = 1;
            Item.channel = true;
            Item.shootSpeed = 16;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 30;
            storeManaCost3 = Item.mana;
            Item.useAnimation = 10;
            Item.UseSound = SoundID.Item21;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 10;
            Item.value = PriceByRarity.LightRed_4;
            Item.width = 34;
            Item.shoot = ModContent.ProjectileType<Projectiles.Ice3Ball>();
        }

        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Ice3Ball>()] < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("Ice2Tome").Type, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 25000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
    }
}

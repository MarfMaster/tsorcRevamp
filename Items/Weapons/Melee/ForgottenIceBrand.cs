﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Melee
{
    class ForgottenIceBrand : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sword imbued with ice.\n" + "Will randomly cast ice 2.");
        }
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.damage = 52;
            Item.height = 42;
            Item.knockBack = 4;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.scale = 1.05f;
            Item.useAnimation = 22;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.value = PriceByRarity.Pink_5;
            Item.width = 42;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.position.X, player.position.Y, (float)(-40 + Main.rand.Next(80)) / 10, 14.9f, ModContent.ProjectileType<Projectiles.Ice2Ball>(), 20, 2.0f, player.whoAmI);
            }
            return true;
        }
    }
}

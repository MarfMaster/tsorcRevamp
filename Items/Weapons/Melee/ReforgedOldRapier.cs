﻿using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Melee
{
    class ReforgedOldRapier : ModItem
    {
        public override string Texture => "tsorcRevamp/Items/Weapons/Melee/OldRapier";
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.width = 40;
            Item.height = 40;
            Item.knockBack = 3;
            Item.maxStack = 1;
            Item.DamageType = DamageClass.Melee;
            Item.scale = 1;
            Item.useAnimation = 12;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useTime = 15;
            Item.value = 200;
        }
    }
}

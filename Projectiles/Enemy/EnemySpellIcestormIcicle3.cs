﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace tsorcRevamp.Projectiles.Enemy
{
    class EnemySpellIcestormIcicle3 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.hostile = true;
            Projectile.penetrate = 16;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 400;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enemy Spell Ice Storm");

        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
        }
    }
}

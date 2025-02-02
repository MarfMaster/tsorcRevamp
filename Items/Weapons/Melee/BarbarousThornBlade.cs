﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Melee
{
    public class BarbarousThornBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barbarous Thorn Blade");
            Tooltip.SetDefault("A blade that lashes out with the fury of a mythical beast"
            + "\nRight-click to shoot briars");
        }
        public override void SetDefaults()
        {
            Item.damage = 36;
            Item.DamageType = DamageClass.Melee;
            Item.width = 44;
            Item.height = 44;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 3.5f;
            Item.value = 25000;
            Item.rare = ItemRarityID.Orange;
            Item.scale = .9f;
            Item.autoReuse = true;
            Item.useTurn = false;
            Item.shoot = 0;
            Item.UseSound = SoundID.Item7;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {

                Item.useStyle = 1;
                Item.shoot = ModContent.ProjectileType<Projectiles.Briar>();
                Item.shootSpeed = 8.5f;
                Item.useTime = 34;
                Item.useAnimation = 34;
                Item.UseSound = SoundID.Item1;

            }

            else
            {
                Item.useStyle = 3;
                Item.shoot = 0;
                Item.useTime = 17;
                Item.useAnimation = 17;
                Item.useTurn = false;
                Item.UseSound = SoundID.Item7;
            }

            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockBack)
        {
            //damage = (int)(damage * .85f);
            float numberProjectiles = 3; //Main.rand.Next(3); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(15); // Spread degrees.
            position += Vector2.Normalize(speed) * 30f; // Distance spawned from player
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = speed.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f; // The speed at which projectiles move.
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0) //quantity of particles
            {
                if (player.altFunctionUse == 2)
                {
                    int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 96/*ID of particle*/, 0f, 0f, 30, default(Color), 1.1f/*Size of particle */);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity.X += player.direction * 6f;
                    Main.dust[dust].velocity.Y += 0.2f;

                }
                else
                {
                    int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 96, 0f, 0f, 60, default(Color), 1.1f);
                    Main.dust[dust].noGravity = true;
                }
            }
        }
        Texture2D glowTexture;
        Texture2D baseTexture;
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (glowTexture == null || glowTexture.IsDisposed)
            {
                glowTexture = TransparentTextureHandler.TransparentTextures[TransparentTextureHandler.TransparentTextureType.BarbarousThornBladeGlowmask];
            }
            if (baseTexture == null || baseTexture.IsDisposed)
            {
                baseTexture = (Texture2D)Terraria.GameContent.TextureAssets.Item[Item.type];
            }

            spriteBatch.Draw(baseTexture, position, new Rectangle(0, 0, baseTexture.Width, baseTexture.Height), drawColor, 0f, origin, scale, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(glowTexture, position, new Rectangle(0, 0, glowTexture.Width, glowTexture.Height), Color.White, 0f, origin, scale, SpriteEffects.None, 0.1f);

            return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            if (glowTexture == null || glowTexture.IsDisposed)
            {
                glowTexture = TransparentTextureHandler.TransparentTextures[TransparentTextureHandler.TransparentTextureType.BarbarousThornBladeGlowmask];
            }
            if (baseTexture == null || baseTexture.IsDisposed)
            {
                baseTexture = (Texture2D)Terraria.GameContent.TextureAssets.Item[Item.type];
            }

            spriteBatch.Draw(baseTexture, Item.Center - Main.screenPosition, new Rectangle(0, 0, baseTexture.Width, baseTexture.Height), lightColor, rotation, new Vector2(Item.width / 2, Item.height / 2), Item.scale, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(glowTexture, Item.Center - Main.screenPosition, new Rectangle(0, 0, glowTexture.Width, glowTexture.Height), Color.White, rotation, new Vector2(Item.width / 2, Item.height / 2), Item.scale, SpriteEffects.None, 0.1f);

            return false;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Melee.YellowTail>());
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSoul>(), 6000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
    }
}

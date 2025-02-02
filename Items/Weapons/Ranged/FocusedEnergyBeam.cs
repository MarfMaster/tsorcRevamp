using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Ranged
{
    public class FocusedEnergyBeam : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Uses Tesla Bolts for ammo\n" +
                        "Fires a single high damage beam that obliterates weaker enemies on contact...\n" +
                        "A weapon from a civilization not of this world...");

        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.shoot = ProjectileID.PurificationPowder;

            Item.damage = 750;
            Item.width = 52;
            Item.height = 22;
            Item.knockBack = 9.0f;
            Item.maxStack = 1;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Red;
            Item.useAmmo = Mod.Find<ModItem>("TeslaBolt").Type;
            Item.shootSpeed = 30;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.UseSound = SoundID.Item12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = PriceByRarity.Red_10;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RedTitanite>(), 3);
            recipe.AddIngredient(ModContent.ItemType<WhiteTitanite>(), 3);
            recipe.AddIngredient(Mod.Find<ModItem>("CompactFrame").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("DestructionElement").Type);
            recipe.AddIngredient(ItemID.SpaceGun, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 90000);

            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}

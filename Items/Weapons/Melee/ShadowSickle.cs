using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Melee
{
    class ShadowSickle : ModItem
    {

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.damage = 60;
            Item.width = 32;
            Item.height = 32;
            Item.knockBack = 5;
            Item.DamageType = DamageClass.Melee;
            Item.scale = 1.1f;
            Item.useAnimation = 50;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 50;
            Item.value = 13500;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}

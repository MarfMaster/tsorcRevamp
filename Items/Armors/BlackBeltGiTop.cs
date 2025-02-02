using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class BlackBeltGiTop : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Adds Double Jump & Jump Boost Skills\nYou are a master of the zen arts, at one with the Tao\nSet bonus also adds +20% Melee damage, +20% Melee Speed, +7% Melee Crit and|nZen meditation adds amazing +13 Life Regen");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 2;
            Item.value = 5000;
            Item.rare = ItemRarityID.Orange;
        }

        public override void UpdateEquip(Player player)
        {
            player.hasJumpOption_Cloud = true;
            player.jumpBoost = true;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MythrilChainmail, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 3000);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }
    }
}

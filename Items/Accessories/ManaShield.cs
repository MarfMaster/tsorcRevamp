using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Accessories
{
    public class ManaShield : ModItem
    {

        public static int manaCost = 80;
        public static int regenDelay = 900;
        public static float damageResistance = 0.40f;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Focuses the user's mana into a protective shield" +
                                $"\nReduces incoming damage by {damageResistance * 100}%, but drains {manaCost} mana per hit" +
                                "\nInhibits both natural and artificial mana regen" +
                                $"\n[c/C80032:For melee warriors only], reduces other damage dramatically");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.value = PriceByRarity.Pink_5;
            Item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            Terraria.Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 6000);
            recipe.AddIngredient(ModContent.ItemType<EphemeralDust>(), 50);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();
        }

        public override void UpdateEquip(Player player)
        {
            //Iterate through the five main accessory slots
            for (int i = 3; i < (8 + player.extraAccessorySlots); i++)
            {
                //If they're wearing the accesories that totally break this concept, it won't function for them.
                if (player.armor[i].type == ItemID.MagicCuffs || player.armor[i].type == ItemID.CelestialCuffs || player.armor[i].type == ItemID.ManaRegenerationBand)
                {
                    player.GetModPlayer<tsorcRevampPlayer>().manaShield = 0;
                    return;
                }
            }

            base.UpdateEquip(player);
            player.GetModPlayer<tsorcRevampPlayer>().manaShield = 1;
            player.GetDamage(DamageClass.Ranged) *= 0.01f;
            player.GetDamage(DamageClass.Magic) *= 0.01f;
            player.GetDamage(DamageClass.Summon) *= 0.01f;
            if (player.statMana >= manaCost)
            {
                player.endurance += damageResistance;
            }
        }
    }
}

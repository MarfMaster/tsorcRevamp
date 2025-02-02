using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.NPCs.Bosses.SuperHardMode.GhostWyvernMage
{
    class GhostDragonBody2 : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.netAlways = true;
            NPC.npcSlots = 1;
            NPC.width = 45;
            NPC.height = 45;
            DrawOffsetY = GhostDragonHead.drawOffset;
            NPC.aiStyle = 6;
            NPC.knockBackResist = 0;
            NPC.timeLeft = 750;
            NPC.damage = 80;
            NPC.defense = 20;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath8;
            NPC.lifeMax = 35000;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = 10000;
            NPC.alpha = 190;
            NPC.buffImmune[BuffID.Poisoned] = true;
            NPC.buffImmune[BuffID.Confused] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
        }

        int fireDamage = 50;
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage / 2);
            fireDamage = (int)(fireDamage / 2);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghost Wyvern");
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        int Timer = -Main.rand.Next(800);

        public override bool CheckActive()
        {
            return false;
        }

        public override void AI()
        {

            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.behindTiles = true;
            int[] bodyTypes = new int[] { ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonLegs>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonLegs>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonLegs>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonLegs>(), ModContent.NPCType<GhostDragonBody>(), ModContent.NPCType<GhostDragonBody2>(), ModContent.NPCType<GhostDragonBody3>() };
            tsorcRevampGlobalNPC.AIWorm(NPC, ModContent.NPCType<GhostDragonHead>(), bodyTypes, ModContent.NPCType<GhostDragonTail>(), 23, -2f, 15f, 0.23f, true, false);

            Timer++;

            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;

                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            //if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
            //{
            //	npc.spriteDirection = 1;
            //}
            //if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
            //{
            //	npc.spriteDirection = -1;
            //}

            if (Timer >= 0)
            {
                if (Main.netMode != 2)
                {
                    float num48 = 4f;
                    Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
                    float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                    rotation += Main.rand.Next(-50, 50) / 100;
                    int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation) * num48) * -1), (float)((Math.Sin(rotation) * num48) * -1), ProjectileID.LostSoulHostile, fireDamage, 0f, Main.myPlayer);
                    Timer = -1200 - Main.rand.Next(200);
                }
            }

            //if (Main.rand.Next(2)==0)
            //{
            //	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, //100, Color.White, 2.0f);
            //	Main.dust[dust].noGravity = true;
            //}
        }

        public static Texture2D texture;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            GhostDragonHead.GhostEffect(NPC, spriteBatch, ref texture, 1.7f);
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            //GhostDragonHead.GhostEffect(npc, spriteBatch, ref texture, 1.1f);
        }
    }
}
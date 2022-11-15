
using System;
using Microsoft.Xna.Framework;
using RampageOfTheStars.Content.Projectiles.StarFist;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RampageOfTheStars.Content.Items.Weapons.Swords
{
	public class StarPunch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Barrage");
			Tooltip.SetDefault("Unleash a barrage of stars into your enemies!");
			
		}
		
		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.knockBack = 6;
			Item.DamageType = DamageClass.Melee;
			
			Item.shoot = ModContent.ProjectileType<StarFist>();
			Item.shootSpeed = 4f;
			
			Item.width = 40;
			Item.height = 40;
			
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			
			Item.useAnimation = 25;
			Item.useTime = 4;
			
			Item.value = 10000;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			
			Vector2 offset = new Vector2(MathF.Cos(Main.rand.Next(-7, 7)), MathF.Sin(Main.rand.Next(-7, 7)));
			position = player.Center + (offset * 10);
			
			Vector2 heading = (target + (offset * 10)) - position;
			
			heading.Normalize();
			heading *= velocity.Length() * ((Math.Abs(Math.Sign(player.velocity.X)) / 1.8f) + 1); // w: 36 h: 32
			
			Projectile.NewProjectile(source, position, heading, type, damage / 2, knockback, player.whoAmI, 0f, ceilingLimit);
			
			
			return false;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DirtBlock, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}

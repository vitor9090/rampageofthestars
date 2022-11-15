using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using RampageOfTheStars.Content.Dusts.star_dust;


namespace RampageOfTheStars.Content.Projectiles.StarFist
{
	public class StarFist : ModProjectile
	{
	
		const int maxTimeAlive = 25;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Fist");
		}
		
		public override void SetDefaults()
		{
			Projectile.aiStyle = -1;
			Projectile.timeLeft = maxTimeAlive;

			Projectile.width = 32;
			Projectile.height = 36;
			
			Projectile.friendly = true;
			Projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			Projectile.ai[0]++;
			// Projectile.timeLeft is the time left in real time
			Projectile.scale = Projectile.ai[0] / maxTimeAlive;
			Projectile.alpha = Projectile.timeLeft / maxTimeAlive;
			if ((Projectile.ai[0] % 10) == 0)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width / 2, Projectile.height / 2, ModContent.DustType<StarDust>(), 0, 0);
			}
 
			Projectile.rotation = Projectile.velocity.ToRotation();
			
		}
		
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
		}
	}
}

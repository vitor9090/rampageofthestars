using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace RampageOfTheStars.Content.Dusts.star_dust
{
	public class StarDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
			dust.rotation = Main.rand.Next(0, 360);
		}
		
		public override bool Update(Dust dust)
		{
			// dust.position += dust.velocity;
			dust.scale *= 0.99f;
			dust.velocity *= 0.95f;
			
			dust.rotation += 0.01f;
				
			Lighting.AddLight(dust.position, dust.scale, dust.scale, dust.scale);
			
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			
			return false;
		}
	}
}

using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Boxinator.Items;

namespace Boxinator
{
	public class Boxinator : Mod
	{
		public Boxinator()
		{
			ContentAutoloadingEnabled = true;
			GoreAutoloadingEnabled = true;
			MusicAutoloadingEnabled = true;
			BackgroundAutoloadingEnabled = true;
		}
	}
}
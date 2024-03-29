using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Boxinator.Items
{
	public class Boxinator : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Creates a basic and suitable house.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		
		public override void SetDefaults()
		{
			//DisplayName.SetDefault("Boxinator");
			Item.useStyle = 4;
			Item.useTime = 2;
			Item.useAnimation = 2;
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 300;
			Item.rare = 1;
			Item.consumable = true;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			Vector2 standingOn = new Vector2((int)Math.Floor(player.position.X/16f)-1,(int)Math.Ceiling((player.position.Y+player.height)/16f));
			for (int i = (int)standingOn.Y-6; i < (int)standingOn.Y+1; i++)
			{
				for (int j = (int)standingOn.X; j < (int)standingOn.X+9; j++)
				{
					if (i == (int)standingOn.Y || j == (int)standingOn.X || (i == (int)standingOn.Y-6 && !(j == (int)standingOn.X+1 || j == (int)standingOn.X+2)) || j == (int)standingOn.X+8) WorldGen.PlaceTile(j, i, 30);
					else if (!(i == (int)standingOn.Y-6 && (j == (int)standingOn.X+1 || j == (int)standingOn.X+2))) WorldGen.PlaceWall(j, i, 4);
				}
			}
			WorldGen.PlaceTile((int)standingOn.X+1, (int)standingOn.Y-6, 19);
			WorldGen.PlaceTile((int)standingOn.X+2, (int)standingOn.Y-6, 19);
			WorldGen.PlaceTile((int)standingOn.X+7, (int)standingOn.Y-5, 4);
			WorldGen.PlaceTile((int)standingOn.X+7, (int)standingOn.Y-1, 15);
			WorldGen.PlaceTile((int)standingOn.X+5, (int)standingOn.Y-1, 18);
			NetMessage.SendTileSquare(-1, (int)standingOn.X, (int)standingOn.Y-6, 9, 7, TileChangeType.None);
			//Main.NewText(""+Main.tile[(int)(player.position.X/16f),(int)((player.position.Y+player.height)/16f)].type+", "+Main.tile[(int)(player.position.X/16f),(int)((player.position.Y+player.height)/16f)].wall);
			return true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddRecipeGroup("Wood", 100);
			recipe.Register();
		}
	}
}
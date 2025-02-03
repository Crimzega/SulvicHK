using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SulvicHK.Data{

	public class StagwayHelper{

		private static List<Stagway> stagways = new List<Stagway>{
			new Stagway{
				stationName = "Dirtmouth",
				mapPos = Vector2.zero
			},
			new Stagway{
				stationName = "Forgotten Crossroads",
				mapPos = new Vector2(5f, 2f)
			},
			new Stagway{
				stationName = "Greenpath",
				mapPos = new Vector2(4f, 3f)
			},
			new Stagway{
				stationName = "Fungal Wastes",
				mapPos = new Vector2(7f, 1f)
			},
			new Stagway{
				stationName = "City of Tears",
				mapPos = new Vector2(8f, 5f)
			},
			new Stagway{
				stationName = "The Resting Grounds",
				mapPos = new Vector2(6f, 6f)
			},
			new Stagway{
				stationName = "Deepnest",
				mapPos = new Vector2(10f, 7f)
			},
			new Stagway{
				stationName = "The Royal Waterways",
				mapPos = new Vector2(11f, 5f)
			},
			new Stagway{
				stationName = "Howling Cliffs",
				mapPos = new Vector2(3f, 8f)
			},
			new Stagway{
				stationName = "Crystal Peak",
				mapPos = new Vector2(12f, 9f)
			},
			new Stagway{
				stationName = "The Hive",
				mapPos = new Vector2(13f, 3f)
			},
			new Stagway{
				stationName = "Ancient Basin",
				mapPos = new Vector2(9f, 11f)
			}
		};
		public static Stagway offMap = new Stagway {
			stationName = "Undefined",
			mapPos = -Vector2.one
		};

		public static Stagway GetStagway(PlayerData data) => GetStagway(data.stagPosition);

		public static Stagway GetStagway(int index) => index == -1? offMap: stagways[index];

		public static float GetDistance(Stagway stagway, Stagway stagway1) => Vector2.Distance(stagway.mapPos, stagway1.mapPos);

		public static bool StagwaysMatch(Stagway stagway, Stagway stagway1) => stagway.stationName.Equals(stagway1.stationName);

	}

}

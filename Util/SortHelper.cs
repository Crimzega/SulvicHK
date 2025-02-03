using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SulvicHK.Util
{
	public class SortHelper{

		private static Vector3 playerPos = HeroController.instance.transform.position;

		public static int SortByPlayer(Vector3 vec, Vector3 vec1) => Vector3.Distance(vec, playerPos).CompareTo(Vector3.Distance(vec1, playerPos));

		public static int SortByPlayer(Collider2D collider, Collider2D collider1) => SortByPlayer(collider.transform.position, collider1.transform.position);

	}
}

using System.Runtime.InteropServices;
using UnityEngine;

namespace SulvicHK.Data{

	[StructLayout(LayoutKind.Sequential)]
	public struct Stagway{
		public string stationName;
		public Vector2 mapPos;
	}

}

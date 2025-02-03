using System.Runtime.InteropServices;
using Modding;

namespace SulvicHK.Handling{

	public class NotchHandler{

		[StructLayout(LayoutKind.Sequential)]
		private struct NotchList{
			public bool fogCanyon, shroomOgres, grimm;
			public int salubras, slys;
		}

		private int trueCount, resultCount;
		private NotchList theList;
		private PlayerData playerData = PlayerData.instance;

		public NotchHandler(){ theList = new NotchList(); }

		private int GetNotchCount(){ return 3 + resultCount; }

		private void CollectInfo(){
			theList.fogCanyon = playerData.notchFogCanyon;
			theList.shroomOgres = playerData.notchShroomOgres;
			theList.grimm = playerData.gotGrimmNotch;
			if(playerData.salubraNotch1) theList.salubras++;
			if(playerData.salubraNotch2) theList.salubras++;
			if(playerData.salubraNotch3) theList.salubras++;
			if(playerData.salubraNotch4) theList.salubras++;
			if(playerData.slyNotch1) theList.slys++;
			if(playerData.slyNotch2) theList.slys++;
		}

		private void ClearData(){
			theList.fogCanyon = theList.shroomOgres = theList.grimm = false;
			theList.salubras = theList.slys = 0;
		}

		private void CountNotches(){
			if(theList.fogCanyon) trueCount++;
			if(theList.shroomOgres) trueCount++;
			if(theList.grimm) trueCount++;
			trueCount += theList.salubras + theList.slys;
			resultCount = trueCount;
		}

		public void Load(){
			ModHooks.CharmUpdateHook += OnNotchCollected;
		}

		public void OnNotchCollected(PlayerData data, HeroController controller){
			CollectInfo();
			CountNotches();
			if(trueCount >= 1) resultCount += 2;
			if(trueCount >= 2) resultCount++;
			if(trueCount >= 3) resultCount++;
			data.SetInt("charmSlots", GetNotchCount());
		}

		public void Unload(){
			playerData.SetInt("charmSlots", 3 + trueCount);
			ClearData();
			ModHooks.CharmUpdateHook -= OnNotchCollected;
		}

	}

}

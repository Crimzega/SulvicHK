using System;
using GlobalEnums;
using Modding;
using SulvicHK.Data;
using UnityEngine;

namespace SulvicHK.Handling{

	public class FlowerHandler{

		private const float DEFAULT_TIME_RESET = 8.0f;
		private const int DEFAULT_CHANCES = 10, DEFAULT_PROTECTION = 12;
		private bool stillHasProtection;
		private int chancesLeft = DEFAULT_CHANCES, protectionCount = DEFAULT_PROTECTION;
		private PlayerData playerData = PlayerData.instance;
		private float timeReset;
		private Stagway currStagway = StagwayHelper.offMap, targetStagway = StagwayHelper.offMap;
		private bool isRidingStag = false;

		public FlowerHandler(){}

		public int ChancesLeft{ get => chancesLeft; }

		public void Load(){
			ModHooks.TakeDamageHook += OnDamage;
			ModHooks.HeroUpdateHook += OnHeroUpdate;
			ModHooks.SetPlayerIntHook += OnRidingStag;
		}

		public int OnDamage(ref int hazardType, int damage){
			HazardType type = (HazardType)hazardType;
			if(type != HazardType.NON_HAZARD) protectionCount -= hazardType + 1;
			return damage;
		}

		public int OnRidingStag(string name, int val){
			switch(name){
				case "stagPosition":
					currStagway = StagwayHelper.GetStagway(PlayerData.instance);
					targetStagway = StagwayHelper.GetStagway(val);
					isRidingStag = StagwayHelper.StagwaysMatch(currStagway, targetStagway);
				break;
			}
			return val;
		}

		private void HandleStagways(){
			bool matches = StagwayHelper.StagwaysMatch(currStagway, targetStagway);
			if (stillHasProtection){
				bool validCurr = StagwayHelper.StagwaysMatch(currStagway, StagwayHelper.offMap);
				bool validTarget = StagwayHelper.StagwaysMatch(targetStagway, StagwayHelper.offMap);
				if(validCurr && validTarget && !matches){
					float dist = StagwayHelper.GetDistance(currStagway, targetStagway);
					if(isRidingStag) protectionCount -= 2;
					int extraDamage = Mathf.Min(Mathf.FloorToInt(dist / 1.5f), 3);
					protectionCount -= extraDamage;
				}
			}
			if(!matches){
				currStagway = targetStagway;
				isRidingStag = false;
			}
		}

		public void OnHeroUpdate(){
			HandleStagways();
			if(playerData.hasXunFlower) stillHasProtection = protectionCount > 0;
			if(!stillHasProtection){
				playerData.xunFlowerBroken = !(playerData.hasXunFlower = false);
				chancesLeft--;
				timeReset = DEFAULT_TIME_RESET;
			}
			if(chancesLeft <= 0){
				if(timeReset > 0) timeReset -= 0.0002f;
				else{
					timeReset = DEFAULT_TIME_RESET;
					chancesLeft = DEFAULT_CHANCES;
					protectionCount = DEFAULT_PROTECTION;
					stillHasProtection = true;
				}
			}
		}

		public void Unload(){
			ModHooks.TakeDamageHook -= OnDamage;
			ModHooks.HeroUpdateHook -= OnHeroUpdate;
		}

	}

}

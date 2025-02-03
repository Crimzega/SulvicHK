using System;
using Modding;
using SulvicHK.Util;
using UnityEngine;

namespace SulvicHK.Handling{

	public class XunInteractHandler{

		private Vector3 playerPos;

		public void Load(){
			ModHooks.HeroUpdateHook += OnInteractWith;
		}

		public void OnInteractWith(){

			if(InputHandler.Instance.inputActions.up.IsPressed){
				playerPos = HeroController.instance.transform.position;
				float interactRange = 2f;
				Collider2D[] colliders = Physics2D.OverlapCircleAll(playerPos, interactRange);
				Array.Sort<Collider2D>(colliders, SortHelper.SortByPlayer);
			}
		}

		public void Unload(){
			ModHooks.HeroUpdateHook -= OnInteractWith;
		}

	}

}

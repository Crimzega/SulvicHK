using Modding;
using SulvicHK.Handling;
using UnityEngine;

namespace SulvicHK{

    public class SulvicHK: Mod, ITogglableMod, IMod{

        private static GameManager manager = GameManager.instance;
        public static SulvicHK instance = new SulvicHK("SulvicHK");
        public FlowerHandler flowerHandler;
        public NotchHandler notchHandler;
        public XunInteractHandler interactHandler;

        public SulvicHK(string name): base(name){
            flowerHandler = new FlowerHandler();
            notchHandler = new NotchHandler();
            interactHandler = new XunInteractHandler();
        }

        public override string GetVersion() => "1.0.0";

		public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects){
            flowerHandler.Load();
            notchHandler.Load();
            interactHandler.Load();
		}

		public void Unload(){
            flowerHandler.Unload();
            notchHandler.Unload();
            interactHandler.Unload();
        }

	}

}

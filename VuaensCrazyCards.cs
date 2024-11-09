using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using VuaensCrazyCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;


namespace VuaensCrazyCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class VuaensCrazyCards : BaseUnityPlugin
    {
        private const string ModId = "com.vuaen.Crazycards.Id";
        private const string ModName = "VuaensCrazyCards";
        public const string Version = "0.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "VCC";
        public static VuaensCrazyCards instance {  get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            CustomCard.BuildCard<FlingingBlock>();
            CustomCard.BuildCard<SpeedBurst>();
            CustomCard.BuildCard<BigExplosion>();
            CustomCard.BuildCard<SpreadReducer>();
            CustomCard.BuildCard<TheBlock>();
            CustomCard.BuildCard<TheWasp>();
            CustomCard.BuildCard<TheAnt>();
            CustomCard.BuildCard<TheBoss>();
            CustomCard.BuildCard<TheSnail>();
            CustomCard.BuildCard<Luigi>();
            CustomCard.BuildCard<GodHelpUsAll>();
            CustomCard.BuildCard<UpgradedMag>();
            CustomCard.BuildCard<WholeMilk>();
            CustomCard.BuildCard<StrangeBackpack>();
            CustomCard.BuildCard<Monkey>();
            CustomCard.BuildCard<YouTuber>();
            CustomCard.BuildCard<StubbedToe>();
            instance = this;
        }
        public static (GameObject AddToProjectile, GameObject effect, Explosion explosion) LoadExplosion(string name, Gun? gun = null)
        {
            // load explosion effect from Explosive Bullet card
            GameObject? explosiveBullet = (GameObject)Resources.Load("0 cards/Explosive bullet");

            Gun explosiveGun = explosiveBullet.GetComponent<Gun>();

            if (gun != null)
            {
                // change the gun sounds
                gun.soundGun.AddSoundImpactModifier(explosiveGun.soundImpactModifier);
            }

            // load assets
            GameObject A_ExplosionSpark = explosiveGun.objectsToSpawn[0].AddToProjectile;
            GameObject explosionCustom = Instantiate(explosiveGun.objectsToSpawn[0].effect);
            explosionCustom.transform.position = new Vector3(1000, 0, 0);
            explosionCustom.hideFlags = HideFlags.HideAndDontSave;
            explosionCustom.name = name;
            DestroyImmediate(explosionCustom.GetComponent<RemoveAfterSeconds>());
            Explosion explosion = explosionCustom.GetComponent<Explosion>();

            return (A_ExplosionSpark, explosionCustom, explosion);
        }
    }
}

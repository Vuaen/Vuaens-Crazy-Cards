using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace VuaensCrazyCards.Cards
{
    class SpeedBurst : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            gun.damage = 0.5f;
            gun.bursts = +5;
            gun.timeBetweenBullets = +.02f;
            gun.ammo = +15;
            gun.spread = +1.5f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }


        protected override string GetTitle()
        {
            return "Burst on me Daddy";
        }
        protected override string GetDescription()
        {
            return "Tack Shooter";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "A lot more",
                    stat = "ammo",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Crazy amount of",
                    stat = "burst",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                 new CardInfoStat()
                {
                    positive = false,
                    amount = "+50%",
                    stat = "spread",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                   new CardInfoStat()
                {
                    positive = false,
                    amount = "Half",
                    stat = "Damage",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return VuaensCrazyCards.ModInitials;
        }
    }
}

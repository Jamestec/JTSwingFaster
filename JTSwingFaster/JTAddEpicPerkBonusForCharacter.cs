using HarmonyLib;
using Helpers;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace JTSwingFaster
{
    [HarmonyPatch(typeof(PerkHelper))]
    [HarmonyPatch("AddEpicPerkBonusForCharacter")]
    class JTAddEpicPerkBonusForCharacter
    {
        private static readonly TextObject _textPerkBonuses = new TextObject("{=Avy8Gua1}Perks");
        static bool Prefix(PerkObject perk, CharacterObject character, SkillObject skillType, bool applyPrimaryBonus, ref ExplainedNumber bonuses)
        {
			if (!character.GetPerkValue(perk))
			{
				return true;
			}
			int skillValue = character.GetSkillValue(skillType);

			bool added = false;
			Settings settings = GlobalSettings<Settings>.Instance;
			if (applyPrimaryBonus) // 1.4.1 Primary is damage, secondary is speed, 1.4.2 this is swapped
			{
				if (settings.ModOneHandedDamage && DefaultPerks.OneHanded.WayOfTheSword == perk)
				{
					float inc = settings.OneHandedDamagePercent * (skillValue - settings.OneHandedDamageBegin);
					AddToStat(ref bonuses, perk.IncrementType, inc, _textPerkBonuses);
					added = true;
					if (settings.ShowPercentMessageOneHandedDamage && character.IsPlayerCharacter)
					{
						Logs.percentMessage($"WayOfTheSword: +{inc}%");
					}
				}
				else if (settings.ModTwoHandedDamage && DefaultPerks.TwoHanded.WayOfTheGreatAxe == perk)
				{
					float inc = settings.TwoHandedDamagePercent * (skillValue - settings.TwoHandedDamageBegin);
					AddToStat(ref bonuses, perk.IncrementType, inc, _textPerkBonuses);
					added = true;
					if (settings.ShowPercentMessageTwoHandedDamage && character.IsPlayerCharacter)
					{
						Logs.percentMessage($"WayOfTheGreatAxe: +{inc}%");
					}
				}
			} else
            {
				if (settings.ModOneHandedSpeed && DefaultPerks.OneHanded.WayOfTheSword == perk)
				{
					float inc = settings.OneHandedSpeedPercent * (skillValue - settings.OneHandedSpeedBegin);
					AddToStat(ref bonuses, perk.IncrementType, inc, _textPerkBonuses);
					added = true;
					if (settings.ShowPercentMessageOneHandedSpeed && character.IsPlayerCharacter)
					{
						Logs.percentMessage($"WayOfTheSword: +{inc}%");
					}
				}
				else if (settings.ModTwoHandedSpeed && DefaultPerks.TwoHanded.WayOfTheGreatAxe == perk)
				{
					float inc = settings.TwoHandedSpeedPercent * (skillValue - settings.TwoHandedSpeedBegin);
					AddToStat(ref bonuses, perk.IncrementType, inc, _textPerkBonuses);
					added = true;
					if (settings.ShowPercentMessageTwoHandedSpeed && character.IsPlayerCharacter)
					{
						Logs.percentMessage($"WayOfTheGreatAxe: +{inc}%");
					}
				}
			}
			if (settings.ForceVanilla) return true;
			return !added;
		}
		private static void AddToStat(ref ExplainedNumber stat, SkillEffect.EffectIncrementType effectIncrementType, float number, TextObject text)
		{
			switch (effectIncrementType)
			{
				case SkillEffect.EffectIncrementType.Add:
					stat.Add(number, text);
					break;
				case SkillEffect.EffectIncrementType.AddFactor: // For Way of the ..., should always be AddFactor (this is multiply)
					stat.AddFactor(number * 0.01f, text);
					break;
			}
		}
	}
}

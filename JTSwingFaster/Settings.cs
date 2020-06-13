using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;
using System.ComponentModel;

namespace JTSwingFaster
{
    class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => "JTSwingFaster";
        public override string DisplayName => "JTSwingFaster";
        public override string FolderName => "JTSwingFaster";
        public override string Format => "json";

        [SettingPropertyBool("Always enable vanilla perk changes", Order = 0, RequireRestart = false, HintText = "True = vanilla + this mod, False = this mod")]
        public bool ForceVanilla
        {
            get;
            set;
        } = false;

        #region onehandedspeed
        [SettingPropertyBool("Modify One Handed Speed", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify One Handed Speed", GroupOrder = 0, IsMainToggle = true)]
        public bool ModOneHandedSpeed
        {
            get;
            set;
        } = true;
        [SettingPropertyFloatingInteger("% speed increase per level", -10f, 10f, "0.###", Order = 1, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify One Handed Speed")]
        public float OneHandedSpeedPercent
        {
            get;
            set;
        } = 1f;
        [SettingPropertyInteger("Level to start % increase", 0, 300, "0", Order = 2, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify One Handed Speed")]
        public int OneHandedSpeedBegin
        {
            get;
            set;
        } = 250;
        #endregion

        #region onehandeddamage
        [SettingPropertyBool("Modify One Handed Damage", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify One Handed Damage", GroupOrder = 1, IsMainToggle = true)]
        public bool ModOneHandedDamage
        {
            get;
            set;
        } = true;
        [SettingPropertyFloatingInteger("% Damage increase per level", -10f, 10f, "0.###", Order = 1, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify One Handed Damage")]
        public float OneHandedDamagePercent
        {
            get;
            set;
        } = 2f;
        [SettingPropertyInteger("Level to start % increase", 0, 300, "0", Order = 2, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify One Handed Damage")]
        public int OneHandedDamageBegin
        {
            get;
            set;
        } = 250;
        #endregion

        #region twohandedspeed
        [SettingPropertyBool("Modify One Handed Speed", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify Two Handed Speed", GroupOrder = 2, IsMainToggle = true)]
        public bool ModTwoHandedSpeed
        {
            get;
            set;
        } = true;
        [SettingPropertyFloatingInteger("% speed increase per level", -10f, 10f, "0.###", Order = 1, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify Two Handed Speed")]
        public float TwoHandedSpeedPercent
        {
            get;
            set;
        } = 1f;
        [SettingPropertyInteger("Level to start % increase", 0, 300, "0", Order = 2, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify Two Handed Speed")]
        public int TwoHandedSpeedBegin
        {
            get;
            set;
        } = 250;
        #endregion

        #region twohandeddamage
        [SettingPropertyBool("Modify Two Handed Damage", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify Two Handed Damage", GroupOrder = 3, IsMainToggle = true)]
        public bool ModTwoHandedDamage
        {
            get;
            set;
        } = true;
        [SettingPropertyFloatingInteger("% Damage increase per level", -10f, 10f, "0.###", Order = 1, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify Two Handed Damage")]
        public float TwoHandedDamagePercent
        {
            get;
            set;
        } = 2f;
        [SettingPropertyInteger("Level to start % increase", 0, 300, "0", Order = 2, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Modify Two Handed Damage")]
        public int TwoHandedDamageBegin
        {
            get;
            set;
        } = 250;
        #endregion

        [SettingPropertyBool("Show % increase messages", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Show % increase messages", GroupOrder = 4, IsMainToggle = true)]
        public bool ShowPercentMessages
        {
            get;
            set;
        } = true;
        [SettingPropertyBool("Show one handed speed", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Show % increase messages")]
        public bool ShowPercentMessageOneHandedSpeed
        {
            get;
            set;
        } = true;
        [SettingPropertyBool("Show one handed damage", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Show % increase messages")]
        public bool ShowPercentMessageOneHandedDamage
        {
            get;
            set;
        } = true;
        [SettingPropertyBool("Show two handed speed", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Show % increase messages")]
        public bool ShowPercentMessageTwoHandedSpeed
        {
            get;
            set;
        } = true;
        [SettingPropertyBool("Show two handed damage", Order = 0, RequireRestart = false, HintText = "")]
        [SettingPropertyGroup("Show % increase messages")]
        public bool ShowPercentMessageTwoHandedDamage
        {
            get;
            set;
        } = true;
    }
}
using UnityEngine;
using UnityModManagerNet;

namespace _MOD_NAME_
{
#if SETTINGS_ON

	public enum HighMediumLow
	{
		High,
		Medium,
		Low,
		Custom
	}

	[DrawFields(DrawFieldMask.Public)]
	public class SubOptions
	{
		public float SubFloat = 300f;
		public bool subBool;
	}

	public class Settings : UnityModManager.ModSettings, IDrawable
	{
		// This is just a simple brush through the options. See: https://wiki.nexusmods.com/index.php/How_to_render_mod_options_(UMM)
		[Header("Top options")]
		[Draw("Boolean Option")] public bool boolOption = true;
		[Draw("Sub-options", Collapsible = true)] public SubOptions ModelsSettings = new SubOptions();

		[Header("Bottom options")]
		[Draw("Another bool with some space above"), Space(20)] public bool SMAAEnable = true;
		[Draw("enum Option")] public HighMediumLow SMAAQuality = HighMediumLow.High;
		[Draw("Slider float Option", Precision = 3, Min = 0, Max = 1, VisibleOn = "SMAAQuality|Custom", Type = DrawType.Slider)] public double CustomQuality = 0.5;

		public override void Save(UnityModManager.ModEntry modEntry)
		{
			Save(this, modEntry);
		}


		public void OnChange()
		{

		}
	}

#endif
}

using UnityEngine;
using Spine.Unity.AttachmentTools;
using Spine;
using Spine.Unity;
public class ChangeHeroSkin : MonoBehaviour
{
	#region Header
	[SpineSkin] public string DressSkin = "default";
	[SpineSkin] public string Weapon = "default";
	public SkeletonAnimation skeletonAnimation;
	Skeleton skeleton;
	Skin characterSkin;
	private Material runtimeMaterial;
	private Texture2D runtimeAtlas;
	public static ChangeHeroSkin Instance;
	#endregion
	public enum ItemSlot{None, Weapon, DressSkin}
	public void Awake()
	{if (Instance == null){Instance = this;} skeletonAnimation = this.GetComponent<SkeletonAnimation>();}
	public void OptimizeSkin()
	{
		Skin previousSkin = skeletonAnimation.Skeleton.Skin;
		if (runtimeMaterial){Destroy(runtimeMaterial);}
		if (runtimeAtlas){Destroy(runtimeAtlas);}	
		Skin repackedSkin = previousSkin.GetRepackedSkin("Repacked skin", skeletonAnimation.SkeletonDataAsset.atlasAssets[0].PrimaryMaterial, out runtimeMaterial, out runtimeAtlas);
		previousSkin.Clear();
		skeletonAnimation.Skeleton.Skin = repackedSkin;
		skeletonAnimation.Skeleton.SetSlotsToSetupPose();
		skeletonAnimation.AnimationState.Apply(skeletonAnimation.Skeleton);
		AtlasUtilities.ClearCache();
		Resources.UnloadUnusedAssets();
	}
	public void UpdateCharacterSkin()
	{
		skeleton = skeletonAnimation.Skeleton;
		if(skeleton == null){print("Nothing happens");}
		SkeletonData skeletonData = skeleton.Data;
		characterSkin = new Skin("character-base");
		characterSkin.AddSkin(skeletonData.FindSkin(DressSkin));
	}
	void AddEquipmentSkinsTo(Skin combinedSkin)
	{
		skeleton = skeletonAnimation.Skeleton;
		SkeletonData skeletonData = skeleton.Data;
		if (!string.IsNullOrEmpty(DressSkin)) combinedSkin.AddSkin(skeletonData.FindSkin(DressSkin));
		if (!string.IsNullOrEmpty(Weapon)) combinedSkin.AddSkin(skeletonData.FindSkin(Weapon));
	}
	public void UpdateCombinedSkin()
	{
		skeleton = skeletonAnimation.Skeleton;
		if(skeleton == null){print("Nothing happens");}
		Skin resultCombinedSkin = new Skin("character-combined");
		resultCombinedSkin.AddSkin(characterSkin);
		AddEquipmentSkinsTo(resultCombinedSkin);
		skeleton.SetSkin(resultCombinedSkin);
		skeleton.SetSlotsToSetupPose();
	}
}
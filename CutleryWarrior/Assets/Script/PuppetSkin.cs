using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity.AttachmentTools;
using Spine;
using Spine.Unity;
public class PuppetSkin : MonoBehaviour
{
    #region Header
	[SpineSkin] public string DressSkin = "default";
	[SpineSkin] public string Weapon = "default";
	SkeletonGraphic _skeletonGraphic;
	Skeleton skeleton;
	Skin characterSkin;
	private Material runtimeMaterial;
	private Texture2D runtimeAtlas;
	public static PuppetSkin Instance;
	#endregion
	public enum ItemSlot{None,Weapon,DressSkin}
	public void Awake()
	{if (Instance == null){Instance = this;}_skeletonGraphic = this.GetComponent<SkeletonGraphic>();}

	public  void OnEnable()
	{
	if (GameManager.instance.CharacterID == 1)
    {	UpdateCharacterSkinUI(GameManager.instance.Inv.Puppets_F.DressSkin);
}
    else if (GameManager.instance.CharacterID == 2)
    {	UpdateCharacterSkinUI(GameManager.instance.Inv.Puppets_K.DressSkin);
}
    else if (GameManager.instance.CharacterID == 3)
    {	UpdateCharacterSkinUI(GameManager.instance.Inv.Puppets_S.DressSkin);
}
	}
	
	#region ChangeSkin
	public void OptimizeSkin()
	{
		Skin previousSkin = _skeletonGraphic.Skeleton.Skin;
		if (runtimeMaterial)
		Destroy(runtimeMaterial);
		if (runtimeAtlas)
		Destroy(runtimeAtlas);
		Skin repackedSkin = previousSkin.GetRepackedSkin("Repacked skin", _skeletonGraphic.SkeletonDataAsset.atlasAssets[0].PrimaryMaterial, out runtimeMaterial, out runtimeAtlas);
		previousSkin.Clear();
		_skeletonGraphic.Skeleton.Skin = repackedSkin;
		_skeletonGraphic.Skeleton.SetSlotsToSetupPose();
		_skeletonGraphic.AnimationState.Apply(_skeletonGraphic.Skeleton);
		AtlasUtilities.ClearCache();
		Resources.UnloadUnusedAssets();
	}
	public void UpdateCharacterSkinUI(string CH)
	{
	_skeletonGraphic.Skeleton.SetSkin(CH);
	characterSkin = new Skin(CH);
	_skeletonGraphic.LateUpdate();
	}
	public void UpdateCombinedSkinUI()
	{
	skeleton = _skeletonGraphic.Skeleton;
	if(skeleton == null){print("niente");}
	Skin resultCombinedSkin = new Skin("character-combined");
	resultCombinedSkin.AddSkin(characterSkin);
	AddEquipmentSkinsTo(resultCombinedSkin);
	skeleton.SetSkin(resultCombinedSkin);
	skeleton.SetSlotsToSetupPose();
	_skeletonGraphic.Initialize(false);
	}
	void AddEquipmentSkinsTo(Skin combinedSkin)
	{
		skeleton = _skeletonGraphic.Skeleton;
		SkeletonData skeletonData = skeleton.Data;
		if (!string.IsNullOrEmpty(DressSkin)) combinedSkin.AddSkin(skeletonData.FindSkin(DressSkin));
		if (!string.IsNullOrEmpty(Weapon)) combinedSkin.AddSkin(skeletonData.FindSkin(Weapon));
	}
	#endregion
}
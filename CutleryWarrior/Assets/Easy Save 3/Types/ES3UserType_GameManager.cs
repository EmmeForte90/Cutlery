using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("GM", "GM_Data", "MouseCursorIcon", "StartGame", "player", "Minimap", "GameManagerExist", "Inv", "QuM", "M_F", "M_K", "M_S", "N_Target", "savedPosition", "savedPositionEscape", "sceneName", "notChange", "CharacterID", "F_Hero", "F_HeroP", "F_HeroAI", "MP_F", "Rust_F", "Fork", "F_SkillW", "OrderFork", "F_Unlock", "F_ExpTextM", "F_ExpText", "F_LVTextM", "F_hpTextM", "F_mpTextM", "F_Def", "F_Atk", "F_Pois", "F_Rust", "F_Sleep", "F_Stun", "F_Hp", "F_Mp", "F_ExpScrol", "ch_F", "ch_FAc", "Manager_F", "S_Hero", "S_HeroP", "S_HeroAI", "MP_S", "Rust_S", "Spoon", "S_SkillW", "OrderSpoon", "S_Unlock", "S_ExpTextM", "S_ExpText", "S_LVTextM", "S_hpTextM", "S_mpTextM", "S_Def", "S_Atk", "S_Pois", "S_Rust", "S_Sleep", "S_Stun", "S_Hp", "S_Mp", "S_ExpScrol", "ch_S", "ch_SAc", "Manager_S", "K_Hero", "K_HeroP", "K_HeroAI", "MP_K", "Rust_K", "Knife", "K_SkillW", "OrderKnife", "K_Unlock", "K_ExpTextM", "K_ExpText", "K_LVTextM", "K_hpTextM", "K_mpTextM", "K_Def", "K_Atk", "K_Pois", "K_Rust", "K_Sleep", "K_Stun", "K_Hp", "K_Mp", "K_ExpScrol", "ch_K", "ch_KAc", "Manager_K", "rotationSwitcher", "SwitcherUI", "Skill_FI", "Skill_FIB", "Skill_KI", "Skill_KIB", "Skill_SI", "Skill_SIB", "IdENM", "stopInput", "battle", "Day", "isRun", "Interact", "NotParty", "F_Die", "K_Die", "S_Die", "NotTouchOption", "Pause", "LittleM", "TimerM", "Ord", "Itm", "Esc", "callFadeIn", "callFadeOut", "money", "moneyTextM", "IDPorta", "Cooldown", "vcam", "instance")]
	public class ES3UserType_GameManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_GameManager() : base(typeof(GameManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (GameManager)obj;
			
			writer.WritePropertyByRef("GM", instance.GM);
			writer.WritePropertyByRef("GM_Data", instance.GM_Data);
			writer.WritePropertyByRef("MouseCursorIcon", instance.MouseCursorIcon);
			writer.WriteProperty("StartGame", instance.StartGame, ES3Type_bool.Instance);
			writer.WritePropertyByRef("player", instance.player);
			writer.WritePropertyByRef("Minimap", instance.Minimap);
			writer.WriteProperty("GameManagerExist", GameManager.GameManagerExist, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Inv", instance.Inv);
			writer.WritePropertyByRef("QuM", instance.QuM);
			writer.WritePropertyByRef("M_F", instance.M_F);
			writer.WritePropertyByRef("M_K", instance.M_K);
			writer.WritePropertyByRef("M_S", instance.M_S);
			writer.WriteProperty("N_Target", instance.N_Target, ES3Type_int.Instance);
			writer.WriteProperty("savedPosition", instance.savedPosition, ES3Type_Vector3.Instance);
			writer.WritePropertyByRef("savedPositionEscape", instance.savedPositionEscape);
			writer.WriteProperty("sceneName", instance.sceneName, ES3Type_string.Instance);
			writer.WriteProperty("notChange", instance.notChange, ES3Type_bool.Instance);
			writer.WriteProperty("CharacterID", instance.CharacterID, ES3Type_int.Instance);
			writer.WritePropertyByRef("F_Hero", instance.F_Hero);
			writer.WritePropertyByRef("F_HeroP", instance.F_HeroP);
			writer.WritePropertyByRef("F_HeroAI", instance.F_HeroAI);
			writer.WritePropertyByRef("MP_F", instance.MP_F);
			writer.WritePropertyByRef("Rust_F", instance.Rust_F);
			writer.WritePropertyByRef("Fork", instance.Fork);
			writer.WritePropertyByRef("F_SkillW", instance.F_SkillW);
			writer.WriteProperty("OrderFork", instance.OrderFork, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("F_Unlock", instance.F_Unlock, ES3Type_bool.Instance);
			writer.WritePropertyByRef("F_ExpTextM", instance.F_ExpTextM);
			writer.WritePropertyByRef("F_ExpText", instance.F_ExpText);
			writer.WritePropertyByRef("F_LVTextM", instance.F_LVTextM);
			writer.WritePropertyByRef("F_hpTextM", instance.F_hpTextM);
			writer.WritePropertyByRef("F_mpTextM", instance.F_mpTextM);
			writer.WritePropertyByRef("F_Def", instance.F_Def);
			writer.WritePropertyByRef("F_Atk", instance.F_Atk);
			writer.WritePropertyByRef("F_Pois", instance.F_Pois);
			writer.WritePropertyByRef("F_Rust", instance.F_Rust);
			writer.WritePropertyByRef("F_Sleep", instance.F_Sleep);
			writer.WritePropertyByRef("F_Stun", instance.F_Stun);
			writer.WritePropertyByRef("F_Hp", instance.F_Hp);
			writer.WritePropertyByRef("F_Mp", instance.F_Mp);
			writer.WritePropertyByRef("F_ExpScrol", instance.F_ExpScrol);
			writer.WritePrivateFieldByRef("ch_F", instance);
			writer.WritePrivateFieldByRef("ch_FAc", instance);
			writer.WritePrivateFieldByRef("Manager_F", instance);
			writer.WritePropertyByRef("S_Hero", instance.S_Hero);
			writer.WritePropertyByRef("S_HeroP", instance.S_HeroP);
			writer.WritePropertyByRef("S_HeroAI", instance.S_HeroAI);
			writer.WritePropertyByRef("MP_S", instance.MP_S);
			writer.WritePropertyByRef("Rust_S", instance.Rust_S);
			writer.WritePropertyByRef("Spoon", instance.Spoon);
			writer.WritePropertyByRef("S_SkillW", instance.S_SkillW);
			writer.WriteProperty("OrderSpoon", instance.OrderSpoon, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("S_Unlock", instance.S_Unlock, ES3Type_bool.Instance);
			writer.WritePropertyByRef("S_ExpTextM", instance.S_ExpTextM);
			writer.WritePropertyByRef("S_ExpText", instance.S_ExpText);
			writer.WritePropertyByRef("S_LVTextM", instance.S_LVTextM);
			writer.WritePropertyByRef("S_hpTextM", instance.S_hpTextM);
			writer.WritePropertyByRef("S_mpTextM", instance.S_mpTextM);
			writer.WritePropertyByRef("S_Def", instance.S_Def);
			writer.WritePropertyByRef("S_Atk", instance.S_Atk);
			writer.WritePropertyByRef("S_Pois", instance.S_Pois);
			writer.WritePropertyByRef("S_Rust", instance.S_Rust);
			writer.WritePropertyByRef("S_Sleep", instance.S_Sleep);
			writer.WritePropertyByRef("S_Stun", instance.S_Stun);
			writer.WritePropertyByRef("S_Hp", instance.S_Hp);
			writer.WritePropertyByRef("S_Mp", instance.S_Mp);
			writer.WritePropertyByRef("S_ExpScrol", instance.S_ExpScrol);
			writer.WritePrivateFieldByRef("ch_S", instance);
			writer.WritePrivateFieldByRef("ch_SAc", instance);
			writer.WritePrivateFieldByRef("Manager_S", instance);
			writer.WritePropertyByRef("K_Hero", instance.K_Hero);
			writer.WritePropertyByRef("K_HeroP", instance.K_HeroP);
			writer.WritePropertyByRef("K_HeroAI", instance.K_HeroAI);
			writer.WritePropertyByRef("MP_K", instance.MP_K);
			writer.WritePropertyByRef("Rust_K", instance.Rust_K);
			writer.WritePropertyByRef("Knife", instance.Knife);
			writer.WritePropertyByRef("K_SkillW", instance.K_SkillW);
			writer.WriteProperty("OrderKnife", instance.OrderKnife, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("K_Unlock", instance.K_Unlock, ES3Type_bool.Instance);
			writer.WritePropertyByRef("K_ExpTextM", instance.K_ExpTextM);
			writer.WritePropertyByRef("K_ExpText", instance.K_ExpText);
			writer.WritePropertyByRef("K_LVTextM", instance.K_LVTextM);
			writer.WritePropertyByRef("K_hpTextM", instance.K_hpTextM);
			writer.WritePropertyByRef("K_mpTextM", instance.K_mpTextM);
			writer.WritePropertyByRef("K_Def", instance.K_Def);
			writer.WritePropertyByRef("K_Atk", instance.K_Atk);
			writer.WritePropertyByRef("K_Pois", instance.K_Pois);
			writer.WritePropertyByRef("K_Rust", instance.K_Rust);
			writer.WritePropertyByRef("K_Sleep", instance.K_Sleep);
			writer.WritePropertyByRef("K_Stun", instance.K_Stun);
			writer.WritePropertyByRef("K_Hp", instance.K_Hp);
			writer.WritePropertyByRef("K_Mp", instance.K_Mp);
			writer.WritePropertyByRef("K_ExpScrol", instance.K_ExpScrol);
			writer.WritePrivateFieldByRef("ch_K", instance);
			writer.WritePrivateFieldByRef("ch_KAc", instance);
			writer.WritePrivateFieldByRef("Manager_K", instance);
			writer.WritePropertyByRef("rotationSwitcher", instance.rotationSwitcher);
			writer.WritePropertyByRef("SwitcherUI", instance.SwitcherUI);
			writer.WriteProperty("Skill_FI", instance.Skill_FI, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("Skill_FIB", instance.Skill_FIB, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("Skill_KI", instance.Skill_KI, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("Skill_KIB", instance.Skill_KIB, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("Skill_SI", instance.Skill_SI, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("Skill_SIB", instance.Skill_SIB, ES3Type_GameObjectArray.Instance);
			writer.WriteProperty("IdENM", instance.IdENM, ES3Type_int.Instance);
			writer.WriteProperty("stopInput", instance.stopInput, ES3Type_bool.Instance);
			writer.WriteProperty("battle", instance.battle, ES3Type_bool.Instance);
			writer.WriteProperty("Day", instance.Day, ES3Type_bool.Instance);
			writer.WriteProperty("isRun", instance.isRun, ES3Type_bool.Instance);
			writer.WriteProperty("Interact", instance.Interact, ES3Type_bool.Instance);
			writer.WriteProperty("NotParty", instance.NotParty, ES3Type_bool.Instance);
			writer.WriteProperty("F_Die", instance.F_Die, ES3Type_bool.Instance);
			writer.WriteProperty("K_Die", instance.K_Die, ES3Type_bool.Instance);
			writer.WriteProperty("S_Die", instance.S_Die, ES3Type_bool.Instance);
			writer.WriteProperty("NotTouchOption", instance.NotTouchOption, ES3Type_bool.Instance);
			writer.WritePrivateFieldByRef("Pause", instance);
			writer.WritePrivateFieldByRef("LittleM", instance);
			writer.WritePrivateFieldByRef("TimerM", instance);
			writer.WritePrivateFieldByRef("Ord", instance);
			writer.WritePrivateFieldByRef("Itm", instance);
			writer.WritePrivateFieldByRef("Esc", instance);
			writer.WritePrivateFieldByRef("callFadeIn", instance);
			writer.WritePrivateFieldByRef("callFadeOut", instance);
			writer.WriteProperty("money", instance.money, ES3Type_int.Instance);
			writer.WritePropertyByRef("moneyTextM", instance.moneyTextM);
			writer.WriteProperty("IDPorta", instance.IDPorta, ES3Type_int.Instance);
			writer.WriteProperty("Cooldown", instance.Cooldown, ES3Type_float.Instance);
			writer.WritePropertyByRef("vcam", instance.vcam);
			writer.WritePropertyByRef("instance", GameManager.instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (GameManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "GM":
						instance.GM = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "GM_Data":
						instance.GM_Data = reader.Read<GameManager>();
						break;
					case "MouseCursorIcon":
						instance.MouseCursorIcon = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "StartGame":
						instance.StartGame = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "player":
						instance.player = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Minimap":
						instance.Minimap = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "GameManagerExist":
						GameManager.GameManagerExist = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Inv":
						instance.Inv = reader.Read<Inventory>();
						break;
					case "QuM":
						instance.QuM = reader.Read<Inventory>();
						break;
					case "M_F":
						instance.M_F = reader.Read<EquipM_F>();
						break;
					case "M_K":
						instance.M_K = reader.Read<EquipM_K>();
						break;
					case "M_S":
						instance.M_S = reader.Read<EquipM_S>();
						break;
					case "N_Target":
						instance.N_Target = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "savedPosition":
						instance.savedPosition = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "savedPositionEscape":
						instance.savedPositionEscape = reader.Read<UnityEngine.Transform>(ES3Type_Transform.Instance);
						break;
					case "sceneName":
						instance.sceneName = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "notChange":
						instance.notChange = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "CharacterID":
						instance.CharacterID = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "F_Hero":
						instance.F_Hero = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "F_HeroP":
						instance.F_HeroP = reader.Read<CharacterMove>();
						break;
					case "F_HeroAI":
						instance.F_HeroAI = reader.Read<CharacterFollow>();
						break;
					case "MP_F":
						instance.MP_F = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Rust_F":
						instance.Rust_F = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Fork":
						instance.Fork = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "F_SkillW":
						instance.F_SkillW = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "OrderFork":
						instance.OrderFork = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "F_Unlock":
						instance.F_Unlock = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "F_ExpTextM":
						instance.F_ExpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_ExpText":
						instance.F_ExpText = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_LVTextM":
						instance.F_LVTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_hpTextM":
						instance.F_hpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_mpTextM":
						instance.F_mpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Def":
						instance.F_Def = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Atk":
						instance.F_Atk = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Pois":
						instance.F_Pois = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Rust":
						instance.F_Rust = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Sleep":
						instance.F_Sleep = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Stun":
						instance.F_Stun = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "F_Hp":
						instance.F_Hp = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "F_Mp":
						instance.F_Mp = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "F_ExpScrol":
						instance.F_ExpScrol = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "ch_F":
					instance = (GameManager)reader.SetPrivateField("ch_F", reader.Read<CharacterMove>(), instance);
					break;
					case "ch_FAc":
					instance = (GameManager)reader.SetPrivateField("ch_FAc", reader.Read<CharacterFollow>(), instance);
					break;
					case "Manager_F":
					instance = (GameManager)reader.SetPrivateField("Manager_F", reader.Read<ManagerCharacter>(), instance);
					break;
					case "S_Hero":
						instance.S_Hero = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "S_HeroP":
						instance.S_HeroP = reader.Read<CharacterMove>();
						break;
					case "S_HeroAI":
						instance.S_HeroAI = reader.Read<CharacterFollow>();
						break;
					case "MP_S":
						instance.MP_S = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Rust_S":
						instance.Rust_S = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Spoon":
						instance.Spoon = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "S_SkillW":
						instance.S_SkillW = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "OrderSpoon":
						instance.OrderSpoon = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "S_Unlock":
						instance.S_Unlock = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "S_ExpTextM":
						instance.S_ExpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_ExpText":
						instance.S_ExpText = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_LVTextM":
						instance.S_LVTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_hpTextM":
						instance.S_hpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_mpTextM":
						instance.S_mpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Def":
						instance.S_Def = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Atk":
						instance.S_Atk = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Pois":
						instance.S_Pois = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Rust":
						instance.S_Rust = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Sleep":
						instance.S_Sleep = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Stun":
						instance.S_Stun = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "S_Hp":
						instance.S_Hp = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "S_Mp":
						instance.S_Mp = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "S_ExpScrol":
						instance.S_ExpScrol = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "ch_S":
					instance = (GameManager)reader.SetPrivateField("ch_S", reader.Read<CharacterMove>(), instance);
					break;
					case "ch_SAc":
					instance = (GameManager)reader.SetPrivateField("ch_SAc", reader.Read<CharacterFollow>(), instance);
					break;
					case "Manager_S":
					instance = (GameManager)reader.SetPrivateField("Manager_S", reader.Read<ManagerCharacter>(), instance);
					break;
					case "K_Hero":
						instance.K_Hero = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "K_HeroP":
						instance.K_HeroP = reader.Read<CharacterMove>();
						break;
					case "K_HeroAI":
						instance.K_HeroAI = reader.Read<CharacterFollow>();
						break;
					case "MP_K":
						instance.MP_K = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Rust_K":
						instance.Rust_K = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Knife":
						instance.Knife = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "K_SkillW":
						instance.K_SkillW = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "OrderKnife":
						instance.OrderKnife = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "K_Unlock":
						instance.K_Unlock = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "K_ExpTextM":
						instance.K_ExpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_ExpText":
						instance.K_ExpText = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_LVTextM":
						instance.K_LVTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_hpTextM":
						instance.K_hpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_mpTextM":
						instance.K_mpTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Def":
						instance.K_Def = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Atk":
						instance.K_Atk = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Pois":
						instance.K_Pois = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Rust":
						instance.K_Rust = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Sleep":
						instance.K_Sleep = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Stun":
						instance.K_Stun = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "K_Hp":
						instance.K_Hp = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "K_Mp":
						instance.K_Mp = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "K_ExpScrol":
						instance.K_ExpScrol = reader.Read<UnityEngine.UI.Scrollbar>();
						break;
					case "ch_K":
					instance = (GameManager)reader.SetPrivateField("ch_K", reader.Read<CharacterMove>(), instance);
					break;
					case "ch_KAc":
					instance = (GameManager)reader.SetPrivateField("ch_KAc", reader.Read<CharacterFollow>(), instance);
					break;
					case "Manager_K":
					instance = (GameManager)reader.SetPrivateField("Manager_K", reader.Read<ManagerCharacter>(), instance);
					break;
					case "rotationSwitcher":
						instance.rotationSwitcher = reader.Read<UIRotationSwitcher>();
						break;
					case "SwitcherUI":
						instance.SwitcherUI = reader.Read<SwitchCharacter>();
						break;
					case "Skill_FI":
						instance.Skill_FI = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "Skill_FIB":
						instance.Skill_FIB = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "Skill_KI":
						instance.Skill_KI = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "Skill_KIB":
						instance.Skill_KIB = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "Skill_SI":
						instance.Skill_SI = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "Skill_SIB":
						instance.Skill_SIB = reader.Read<UnityEngine.GameObject[]>(ES3Type_GameObjectArray.Instance);
						break;
					case "IdENM":
						instance.IdENM = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "stopInput":
						instance.stopInput = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "battle":
						instance.battle = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Day":
						instance.Day = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isRun":
						instance.isRun = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Interact":
						instance.Interact = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "NotParty":
						instance.NotParty = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "F_Die":
						instance.F_Die = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "K_Die":
						instance.K_Die = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "S_Die":
						instance.S_Die = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "NotTouchOption":
						instance.NotTouchOption = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Pause":
					instance = (GameManager)reader.SetPrivateField("Pause", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "LittleM":
					instance = (GameManager)reader.SetPrivateField("LittleM", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "TimerM":
					instance = (GameManager)reader.SetPrivateField("TimerM", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "Ord":
					instance = (GameManager)reader.SetPrivateField("Ord", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "Itm":
					instance = (GameManager)reader.SetPrivateField("Itm", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "Esc":
					instance = (GameManager)reader.SetPrivateField("Esc", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "callFadeIn":
					instance = (GameManager)reader.SetPrivateField("callFadeIn", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "callFadeOut":
					instance = (GameManager)reader.SetPrivateField("callFadeOut", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "money":
						instance.money = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "moneyTextM":
						instance.moneyTextM = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "IDPorta":
						instance.IDPorta = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Cooldown":
						instance.Cooldown = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "vcam":
						instance.vcam = reader.Read<Cinemachine.CinemachineVirtualCamera>();
						break;
					case "instance":
						GameManager.instance = reader.Read<GameManager>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_GameManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameManagerArray() : base(typeof(GameManager[]), ES3UserType_GameManager.Instance)
		{
			Instance = this;
		}
	}
}
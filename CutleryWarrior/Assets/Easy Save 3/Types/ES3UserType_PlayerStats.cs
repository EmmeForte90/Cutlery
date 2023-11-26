using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("HaveData", "CanLoading", "NameScene", "savedPosition", "F_Unlock", "S_Unlock", "K_Unlock", "Money", "WhatMusic", "StartData", "F_LV", "F_HP", "F_curHP", "F_MP", "F_curMP", "F_curRage", "F_Rage", "F_CostMP", "F_Exp", "F_curExp", "F_attack", "F_defense", "F_poisonResistance", "F_paralysisResistance", "F_sleepResistance", "F_rustResistance", "F_HPCont", "F_curHPCont", "F_MPCont", "F_curMPCont", "F_CostMPCont", "F_ExpCont", "F_curExpCont", "F_attackCont", "F_defenseCont", "F_poisonResistanceCont", "F_paralysisResistanceCont", "F_sleepResistanceCont", "F_rustResistanceCont", "S_LV", "S_HP", "S_curHP", "S_MP", "S_curMP", "S_curRage", "S_Rage", "S_CostMP", "S_Exp", "S_curExp", "S_attack", "S_defense", "S_poisonResistance", "S_paralysisResistance", "S_sleepResistance", "S_rustResistance", "S_HPCont", "S_curHPCont", "S_MPCont", "S_curMPCont", "S_CostMPCont", "S_ExpCont", "S_curExpCont", "S_attackCont", "S_defenseCont", "S_poisonResistanceCont", "S_paralysisResistanceCont", "S_sleepResistanceCont", "S_rustResistanceCont", "K_LV", "K_HP", "K_curHP", "K_MP", "K_curMP", "K_CostMP", "K_curRage", "K_Rage", "K_Exp", "K_curExp", "K_attack", "K_defense", "K_poisonResistance", "K_paralysisResistance", "K_sleepResistance", "K_rustResistance", "K_HPCont", "K_curHPCont", "K_MPCont", "K_curMPCont", "K_CostMPCont", "K_ExpCont", "K_curExpCont", "K_attackCont", "K_defenseCont", "K_poisonResistanceCont", "K_paralysisResistanceCont", "K_sleepResistanceCont", "K_rustResistanceCont", "Enemies", "Treasure", "Skill_F", "Skill_K", "Skill_S", "I_itemList", "I_quantityList", "IBattle_itemList", "IBattle_quantityList", "F_itemList", "F_quantityList", "S_itemList", "S_quantityList", "K_itemList", "K_quantityList", "Key_itemList", "Key_quantityList", "Quest_itemList", "Quest_quantityList", "EventsDesert", "SwitchDesert", "questDatabase", "quest", "QuestActive", "QuestComplete", "QuestSegnal", "items", "instance", "DataManager")]
	public class ES3UserType_PlayerStats : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerStats() : base(typeof(PlayerStats)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerStats)obj;
			
			writer.WriteProperty("HaveData", instance.HaveData, ES3Type_bool.Instance);
			writer.WriteProperty("CanLoading", instance.CanLoading, ES3Type_bool.Instance);
			writer.WriteProperty("NameScene", instance.NameScene, ES3Type_string.Instance);
			writer.WriteProperty("savedPosition", instance.savedPosition, ES3Type_Vector3.Instance);
			writer.WriteProperty("F_Unlock", instance.F_Unlock, ES3Type_bool.Instance);
			writer.WriteProperty("S_Unlock", instance.S_Unlock, ES3Type_bool.Instance);
			writer.WriteProperty("K_Unlock", instance.K_Unlock, ES3Type_bool.Instance);
			writer.WriteProperty("Money", instance.Money, ES3Type_int.Instance);
			writer.WriteProperty("WhatMusic", instance.WhatMusic, ES3Type_int.Instance);
			writer.WriteProperty("StartData", instance.StartData, ES3Type_bool.Instance);
			writer.WriteProperty("F_LV", instance.F_LV, ES3Type_int.Instance);
			writer.WriteProperty("F_HP", instance.F_HP, ES3Type_float.Instance);
			writer.WriteProperty("F_curHP", instance.F_curHP, ES3Type_float.Instance);
			writer.WriteProperty("F_MP", instance.F_MP, ES3Type_float.Instance);
			writer.WriteProperty("F_curMP", instance.F_curMP, ES3Type_float.Instance);
			writer.WriteProperty("F_curRage", instance.F_curRage, ES3Type_float.Instance);
			writer.WriteProperty("F_Rage", instance.F_Rage, ES3Type_float.Instance);
			writer.WriteProperty("F_CostMP", instance.F_CostMP, ES3Type_float.Instance);
			writer.WriteProperty("F_Exp", instance.F_Exp, ES3Type_float.Instance);
			writer.WriteProperty("F_curExp", instance.F_curExp, ES3Type_float.Instance);
			writer.WriteProperty("F_attack", instance.F_attack, ES3Type_float.Instance);
			writer.WriteProperty("F_defense", instance.F_defense, ES3Type_float.Instance);
			writer.WriteProperty("F_poisonResistance", instance.F_poisonResistance, ES3Type_float.Instance);
			writer.WriteProperty("F_paralysisResistance", instance.F_paralysisResistance, ES3Type_float.Instance);
			writer.WriteProperty("F_sleepResistance", instance.F_sleepResistance, ES3Type_float.Instance);
			writer.WriteProperty("F_rustResistance", instance.F_rustResistance, ES3Type_float.Instance);
			writer.WriteProperty("F_HPCont", instance.F_HPCont, ES3Type_float.Instance);
			writer.WriteProperty("F_curHPCont", instance.F_curHPCont, ES3Type_float.Instance);
			writer.WriteProperty("F_MPCont", instance.F_MPCont, ES3Type_float.Instance);
			writer.WriteProperty("F_curMPCont", instance.F_curMPCont, ES3Type_float.Instance);
			writer.WriteProperty("F_CostMPCont", instance.F_CostMPCont, ES3Type_float.Instance);
			writer.WriteProperty("F_ExpCont", instance.F_ExpCont, ES3Type_float.Instance);
			writer.WriteProperty("F_curExpCont", instance.F_curExpCont, ES3Type_float.Instance);
			writer.WriteProperty("F_attackCont", instance.F_attackCont, ES3Type_float.Instance);
			writer.WriteProperty("F_defenseCont", instance.F_defenseCont, ES3Type_float.Instance);
			writer.WriteProperty("F_poisonResistanceCont", instance.F_poisonResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("F_paralysisResistanceCont", instance.F_paralysisResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("F_sleepResistanceCont", instance.F_sleepResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("F_rustResistanceCont", instance.F_rustResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("S_LV", instance.S_LV, ES3Type_int.Instance);
			writer.WriteProperty("S_HP", instance.S_HP, ES3Type_float.Instance);
			writer.WriteProperty("S_curHP", instance.S_curHP, ES3Type_float.Instance);
			writer.WriteProperty("S_MP", instance.S_MP, ES3Type_float.Instance);
			writer.WriteProperty("S_curMP", instance.S_curMP, ES3Type_float.Instance);
			writer.WriteProperty("S_curRage", instance.S_curRage, ES3Type_float.Instance);
			writer.WriteProperty("S_Rage", instance.S_Rage, ES3Type_float.Instance);
			writer.WriteProperty("S_CostMP", instance.S_CostMP, ES3Type_float.Instance);
			writer.WriteProperty("S_Exp", instance.S_Exp, ES3Type_float.Instance);
			writer.WriteProperty("S_curExp", instance.S_curExp, ES3Type_float.Instance);
			writer.WriteProperty("S_attack", instance.S_attack, ES3Type_float.Instance);
			writer.WriteProperty("S_defense", instance.S_defense, ES3Type_float.Instance);
			writer.WriteProperty("S_poisonResistance", instance.S_poisonResistance, ES3Type_float.Instance);
			writer.WriteProperty("S_paralysisResistance", instance.S_paralysisResistance, ES3Type_float.Instance);
			writer.WriteProperty("S_sleepResistance", instance.S_sleepResistance, ES3Type_float.Instance);
			writer.WriteProperty("S_rustResistance", instance.S_rustResistance, ES3Type_float.Instance);
			writer.WriteProperty("S_HPCont", instance.S_HPCont, ES3Type_float.Instance);
			writer.WriteProperty("S_curHPCont", instance.S_curHPCont, ES3Type_float.Instance);
			writer.WriteProperty("S_MPCont", instance.S_MPCont, ES3Type_float.Instance);
			writer.WriteProperty("S_curMPCont", instance.S_curMPCont, ES3Type_float.Instance);
			writer.WriteProperty("S_CostMPCont", instance.S_CostMPCont, ES3Type_float.Instance);
			writer.WriteProperty("S_ExpCont", instance.S_ExpCont, ES3Type_float.Instance);
			writer.WriteProperty("S_curExpCont", instance.S_curExpCont, ES3Type_float.Instance);
			writer.WriteProperty("S_attackCont", instance.S_attackCont, ES3Type_float.Instance);
			writer.WriteProperty("S_defenseCont", instance.S_defenseCont, ES3Type_float.Instance);
			writer.WriteProperty("S_poisonResistanceCont", instance.S_poisonResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("S_paralysisResistanceCont", instance.S_paralysisResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("S_sleepResistanceCont", instance.S_sleepResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("S_rustResistanceCont", instance.S_rustResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("K_LV", instance.K_LV, ES3Type_int.Instance);
			writer.WriteProperty("K_HP", instance.K_HP, ES3Type_float.Instance);
			writer.WriteProperty("K_curHP", instance.K_curHP, ES3Type_float.Instance);
			writer.WriteProperty("K_MP", instance.K_MP, ES3Type_float.Instance);
			writer.WriteProperty("K_curMP", instance.K_curMP, ES3Type_float.Instance);
			writer.WriteProperty("K_CostMP", instance.K_CostMP, ES3Type_float.Instance);
			writer.WriteProperty("K_curRage", instance.K_curRage, ES3Type_float.Instance);
			writer.WriteProperty("K_Rage", instance.K_Rage, ES3Type_float.Instance);
			writer.WriteProperty("K_Exp", instance.K_Exp, ES3Type_float.Instance);
			writer.WriteProperty("K_curExp", instance.K_curExp, ES3Type_float.Instance);
			writer.WriteProperty("K_attack", instance.K_attack, ES3Type_float.Instance);
			writer.WriteProperty("K_defense", instance.K_defense, ES3Type_float.Instance);
			writer.WriteProperty("K_poisonResistance", instance.K_poisonResistance, ES3Type_float.Instance);
			writer.WriteProperty("K_paralysisResistance", instance.K_paralysisResistance, ES3Type_float.Instance);
			writer.WriteProperty("K_sleepResistance", instance.K_sleepResistance, ES3Type_float.Instance);
			writer.WriteProperty("K_rustResistance", instance.K_rustResistance, ES3Type_float.Instance);
			writer.WriteProperty("K_HPCont", instance.K_HPCont, ES3Type_float.Instance);
			writer.WriteProperty("K_curHPCont", instance.K_curHPCont, ES3Type_float.Instance);
			writer.WriteProperty("K_MPCont", instance.K_MPCont, ES3Type_float.Instance);
			writer.WriteProperty("K_curMPCont", instance.K_curMPCont, ES3Type_float.Instance);
			writer.WriteProperty("K_CostMPCont", instance.K_CostMPCont, ES3Type_float.Instance);
			writer.WriteProperty("K_ExpCont", instance.K_ExpCont, ES3Type_float.Instance);
			writer.WriteProperty("K_curExpCont", instance.K_curExpCont, ES3Type_float.Instance);
			writer.WriteProperty("K_attackCont", instance.K_attackCont, ES3Type_float.Instance);
			writer.WriteProperty("K_defenseCont", instance.K_defenseCont, ES3Type_float.Instance);
			writer.WriteProperty("K_poisonResistanceCont", instance.K_poisonResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("K_paralysisResistanceCont", instance.K_paralysisResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("K_sleepResistanceCont", instance.K_sleepResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("K_rustResistanceCont", instance.K_rustResistanceCont, ES3Type_float.Instance);
			writer.WriteProperty("Enemies", instance.Enemies, ES3Type_boolArray.Instance);
			writer.WriteProperty("Treasure", instance.Treasure, ES3Type_boolArray.Instance);
			writer.WriteProperty("Skill_F", instance.Skill_F, ES3Type_boolArray.Instance);
			writer.WriteProperty("Skill_K", instance.Skill_K, ES3Type_boolArray.Instance);
			writer.WriteProperty("Skill_S", instance.Skill_S, ES3Type_boolArray.Instance);
			writer.WriteProperty("I_itemList", instance.I_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("I_quantityList", instance.I_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("IBattle_itemList", instance.IBattle_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("IBattle_quantityList", instance.IBattle_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("F_itemList", instance.F_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("F_quantityList", instance.F_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("S_itemList", instance.S_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("S_quantityList", instance.S_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("K_itemList", instance.K_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("K_quantityList", instance.K_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("Kay_itemList", instance.Kay_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("Key_quantityList", instance.Key_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("Quest_itemList", instance.Quest_itemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Item>)));
			writer.WriteProperty("Quest_quantityList", instance.Quest_quantityList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WriteProperty("EventsDesert", instance.EventsDesert, ES3Type_boolArray.Instance);
			writer.WriteProperty("SwitchDesert", instance.SwitchDesert, ES3Type_boolArray.Instance);
			writer.WriteProperty("questDatabase", instance.questDatabase, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Quests>)));
			writer.WriteProperty("quest", instance.quest, ES3Type_boolArray.Instance);
			writer.WriteProperty("QuestActive", instance.QuestActive, ES3Type_boolArray.Instance);
			writer.WriteProperty("QuestComplete", instance.QuestComplete, ES3Type_boolArray.Instance);
			writer.WriteProperty("QuestSegnal", instance.QuestSegnal, ES3Type_boolArray.Instance);
			writer.WriteProperty("items", instance.items, ES3Type_boolArray.Instance);
			writer.WritePropertyByRef("instance", PlayerStats.instance);
			writer.WriteProperty("DataManager", PlayerStats.DataManager, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerStats)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "HaveData":
						instance.HaveData = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "CanLoading":
						instance.CanLoading = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "NameScene":
						instance.NameScene = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "savedPosition":
						instance.savedPosition = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "F_Unlock":
						instance.F_Unlock = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "S_Unlock":
						instance.S_Unlock = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "K_Unlock":
						instance.K_Unlock = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Money":
						instance.Money = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "WhatMusic":
						instance.WhatMusic = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "StartData":
						instance.StartData = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "F_LV":
						instance.F_LV = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "F_HP":
						instance.F_HP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curHP":
						instance.F_curHP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_MP":
						instance.F_MP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curMP":
						instance.F_curMP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curRage":
						instance.F_curRage = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_Rage":
						instance.F_Rage = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_CostMP":
						instance.F_CostMP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_Exp":
						instance.F_Exp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curExp":
						instance.F_curExp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_attack":
						instance.F_attack = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_defense":
						instance.F_defense = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_poisonResistance":
						instance.F_poisonResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_paralysisResistance":
						instance.F_paralysisResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_sleepResistance":
						instance.F_sleepResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_rustResistance":
						instance.F_rustResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_HPCont":
						instance.F_HPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curHPCont":
						instance.F_curHPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_MPCont":
						instance.F_MPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curMPCont":
						instance.F_curMPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_CostMPCont":
						instance.F_CostMPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_ExpCont":
						instance.F_ExpCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_curExpCont":
						instance.F_curExpCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_attackCont":
						instance.F_attackCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_defenseCont":
						instance.F_defenseCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_poisonResistanceCont":
						instance.F_poisonResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_paralysisResistanceCont":
						instance.F_paralysisResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_sleepResistanceCont":
						instance.F_sleepResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "F_rustResistanceCont":
						instance.F_rustResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_LV":
						instance.S_LV = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "S_HP":
						instance.S_HP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curHP":
						instance.S_curHP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_MP":
						instance.S_MP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curMP":
						instance.S_curMP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curRage":
						instance.S_curRage = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_Rage":
						instance.S_Rage = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_CostMP":
						instance.S_CostMP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_Exp":
						instance.S_Exp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curExp":
						instance.S_curExp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_attack":
						instance.S_attack = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_defense":
						instance.S_defense = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_poisonResistance":
						instance.S_poisonResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_paralysisResistance":
						instance.S_paralysisResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_sleepResistance":
						instance.S_sleepResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_rustResistance":
						instance.S_rustResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_HPCont":
						instance.S_HPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curHPCont":
						instance.S_curHPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_MPCont":
						instance.S_MPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curMPCont":
						instance.S_curMPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_CostMPCont":
						instance.S_CostMPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_ExpCont":
						instance.S_ExpCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_curExpCont":
						instance.S_curExpCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_attackCont":
						instance.S_attackCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_defenseCont":
						instance.S_defenseCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_poisonResistanceCont":
						instance.S_poisonResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_paralysisResistanceCont":
						instance.S_paralysisResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_sleepResistanceCont":
						instance.S_sleepResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "S_rustResistanceCont":
						instance.S_rustResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_LV":
						instance.K_LV = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "K_HP":
						instance.K_HP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curHP":
						instance.K_curHP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_MP":
						instance.K_MP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curMP":
						instance.K_curMP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_CostMP":
						instance.K_CostMP = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curRage":
						instance.K_curRage = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_Rage":
						instance.K_Rage = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_Exp":
						instance.K_Exp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curExp":
						instance.K_curExp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_attack":
						instance.K_attack = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_defense":
						instance.K_defense = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_poisonResistance":
						instance.K_poisonResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_paralysisResistance":
						instance.K_paralysisResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_sleepResistance":
						instance.K_sleepResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_rustResistance":
						instance.K_rustResistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_HPCont":
						instance.K_HPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curHPCont":
						instance.K_curHPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_MPCont":
						instance.K_MPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curMPCont":
						instance.K_curMPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_CostMPCont":
						instance.K_CostMPCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_ExpCont":
						instance.K_ExpCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_curExpCont":
						instance.K_curExpCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_attackCont":
						instance.K_attackCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_defenseCont":
						instance.K_defenseCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_poisonResistanceCont":
						instance.K_poisonResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_paralysisResistanceCont":
						instance.K_paralysisResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_sleepResistanceCont":
						instance.K_sleepResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "K_rustResistanceCont":
						instance.K_rustResistanceCont = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Enemies":
						instance.Enemies = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "Treasure":
						instance.Treasure = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "Skill_F":
						instance.Skill_F = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "Skill_K":
						instance.Skill_K = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "Skill_S":
						instance.Skill_S = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "I_itemList":
						instance.I_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "I_quantityList":
						instance.I_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "IBattle_itemList":
						instance.IBattle_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "IBattle_quantityList":
						instance.IBattle_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "F_itemList":
						instance.F_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "F_quantityList":
						instance.F_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "S_itemList":
						instance.S_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "S_quantityList":
						instance.S_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "K_itemList":
						instance.K_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "K_quantityList":
						instance.K_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "Kay_itemList":
						instance.Kay_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "Key_quantityList":
						instance.Key_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "Quest_itemList":
						instance.Quest_itemList = reader.Read<System.Collections.Generic.List<Item>>();
						break;
					case "Quest_quantityList":
						instance.Quest_quantityList = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "EventsDesert":
						instance.EventsDesert = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "SwitchDesert":
						instance.SwitchDesert = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "questDatabase":
						instance.questDatabase = reader.Read<System.Collections.Generic.List<Quests>>();
						break;
					case "quest":
						instance.quest = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "QuestActive":
						instance.QuestActive = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "QuestComplete":
						instance.QuestComplete = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "QuestSegnal":
						instance.QuestSegnal = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "items":
						instance.items = reader.Read<System.Boolean[]>(ES3Type_boolArray.Instance);
						break;
					case "instance":
						PlayerStats.instance = reader.Read<PlayerStats>(ES3UserType_PlayerStats.Instance);
						break;
					case "DataManager":
						PlayerStats.DataManager = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerStatsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerStatsArray() : base(typeof(PlayerStats[]), ES3UserType_PlayerStats.Instance)
		{
			Instance = this;
		}
	}
}
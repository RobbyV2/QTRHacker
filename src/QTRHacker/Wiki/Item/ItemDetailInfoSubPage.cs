﻿using Newtonsoft.Json.Linq;
using QTRHacker.Controls;
using QTRHacker.Res;
using QTRHacker.Wiki.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTRHacker.Wiki.Item
{
	public class ItemDetailInfoSubPage : TabPage
	{
		public InfoView ItemIcon2InfoView, ItemPickaxeInfoView, ItemAxeInfoView, ItemHammerInfoView, ItemDamageInfoView, ItemDefenseInfoView, ItemCritInfoView, ItemUseTimeInfoView, ItemKnockbackInfoView;
		public InfoView ItemHealLifeInfoView, ItemHealManaInfoView, ItemManaConsumeInfoView, ItemBaitInfoView, ItemShootInfoView, ItemShootSpeedInfoView, ItemCreateTileInfoView, ItemBuffTypeInfoView, ItemBuffTimeInfoView, ItemUseAnimationInfoView, ItemPlaceStyleInfoView, ItemCreateWallInfoView, ItemTileBoostInfoView;
		public InfoView ItemDescription2InfoView;

		public ItemDetailInfoSubPage() : base(HackContext.CurrentLanguage["ItemDetailInfo"])
		{
			BackColor = ItemsTabPage.GlobalBack;
			ItemIcon2InfoView = new InfoView(new PictureBox() { SizeMode = PictureBoxSizeMode.CenterImage }, InfoView.TipDock.Top);
			ItemIcon2InfoView.Text = HackContext.CurrentLanguage["Icon"];
			ItemIcon2InfoView.Bounds = new Rectangle(5, 5, 80, 80);
			ItemIcon2InfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;


			ItemPickaxeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false);
			ItemPickaxeInfoView.Text = HackContext.CurrentLanguage["Pick"];
			ItemPickaxeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemPickaxeInfoView.Bounds = new Rectangle(0, 0, 170, 20);

			ItemAxeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false);
			ItemAxeInfoView.Text = HackContext.CurrentLanguage["Axe"];
			ItemAxeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemAxeInfoView.Bounds = new Rectangle(0, 20, 170, 20);

			ItemHammerInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false);
			ItemHammerInfoView.Text = HackContext.CurrentLanguage["Hammer"];
			ItemHammerInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemHammerInfoView.Bounds = new Rectangle(0, 40, 170, 20);

			InfoView ItemDetailInfoView = new InfoView(new Panel() { BorderStyle = BorderStyle.None }, InfoView.TipDock.Top);
			Panel ItemDetailInfoViewContent = (ItemDetailInfoView.View as Panel);

			ItemDetailInfoViewContent.Controls.Add(ItemPickaxeInfoView);
			ItemDetailInfoViewContent.Controls.Add(ItemAxeInfoView);
			ItemDetailInfoViewContent.Controls.Add(ItemHammerInfoView);
			ItemDetailInfoView.Text = HackContext.CurrentLanguage["Details"];
			ItemDetailInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemDetailInfoView.Bounds = new Rectangle(90, 5, 170, 80);

			ItemDamageInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemDamageInfoView.Text = HackContext.CurrentLanguage["Damage"];
			ItemDamageInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemDamageInfoView.Bounds = new Rectangle(0, 0, 127, 20);

			ItemDefenseInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemDefenseInfoView.Text = HackContext.CurrentLanguage["Defense"];
			ItemDefenseInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemDefenseInfoView.Bounds = new Rectangle(128, 0, 127, 20);


			ItemCritInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemCritInfoView.Text = HackContext.CurrentLanguage["Crit"];
			ItemCritInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemCritInfoView.Bounds = new Rectangle(0, 20, 127, 20);

			ItemKnockbackInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemKnockbackInfoView.Text = HackContext.CurrentLanguage["KnockBack"];
			ItemKnockbackInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemKnockbackInfoView.Bounds = new Rectangle(128, 20, 127, 20);


			ItemShootInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemShootInfoView.Text = HackContext.CurrentLanguage["Shoot"];
			ItemShootInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemShootInfoView.Bounds = new Rectangle(0, 40, 127, 20);

			ItemShootSpeedInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemShootSpeedInfoView.Text = HackContext.CurrentLanguage["ShootSpeed"];
			ItemShootSpeedInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemShootSpeedInfoView.Bounds = new Rectangle(128, 40, 127, 20);


			ItemUseTimeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemUseTimeInfoView.Text = HackContext.CurrentLanguage["UseTime"];
			ItemUseTimeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemUseTimeInfoView.Bounds = new Rectangle(0, 60, 127, 20);

			ItemUseAnimationInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemUseAnimationInfoView.Text = HackContext.CurrentLanguage["UseAnimation"];
			ItemUseAnimationInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemUseAnimationInfoView.Bounds = new Rectangle(128, 60, 127, 20);


			ItemHealLifeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemHealLifeInfoView.Text = HackContext.CurrentLanguage["HealLife"];
			ItemHealLifeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemHealLifeInfoView.Bounds = new Rectangle(0, 80, 127, 20);

			ItemHealManaInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemHealManaInfoView.Text = HackContext.CurrentLanguage["HealMana"];
			ItemHealManaInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemHealManaInfoView.Bounds = new Rectangle(128, 80, 127, 20);


			ItemCreateTileInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemCreateTileInfoView.Text = HackContext.CurrentLanguage["CreateTile"];
			ItemCreateTileInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemCreateTileInfoView.Bounds = new Rectangle(0, 100, 127, 20);

			ItemPlaceStyleInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemPlaceStyleInfoView.Text = HackContext.CurrentLanguage["PlaceStyle"];
			ItemPlaceStyleInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemPlaceStyleInfoView.Bounds = new Rectangle(128, 100, 127, 20);


			ItemCreateWallInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemCreateWallInfoView.Text = HackContext.CurrentLanguage["CreateWall"];
			ItemCreateWallInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemCreateWallInfoView.Bounds = new Rectangle(0, 120, 127, 20);

			ItemTileBoostInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemTileBoostInfoView.Text = HackContext.CurrentLanguage["TileBoost"];
			ItemTileBoostInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemTileBoostInfoView.Bounds = new Rectangle(128, 120, 127, 20);


			ItemBuffTypeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemBuffTypeInfoView.Text = HackContext.CurrentLanguage["Buff"];
			ItemBuffTypeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemBuffTypeInfoView.Bounds = new Rectangle(0, 140, 127, 20);

			ItemBuffTimeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemBuffTimeInfoView.Text = HackContext.CurrentLanguage["BuffTime"];
			ItemBuffTimeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemBuffTimeInfoView.Bounds = new Rectangle(128, 140, 127, 20);


			ItemManaConsumeInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemManaConsumeInfoView.Text = HackContext.CurrentLanguage["ManaConsume"];
			ItemManaConsumeInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemManaConsumeInfoView.Bounds = new Rectangle(0, 160, 127, 20);

			ItemBaitInfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, TextAlign = HorizontalAlignment.Center }, InfoView.TipDock.Left, false, 60);
			ItemBaitInfoView.Text = HackContext.CurrentLanguage["Bait"];
			ItemBaitInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemBaitInfoView.Bounds = new Rectangle(128, 160, 127, 20);


			InfoView ItemPropertiesInfoView = new InfoView(new Panel() { BorderStyle = BorderStyle.None }, InfoView.TipDock.Top);
			Panel ItemPropertiesInfoViewContent = (ItemPropertiesInfoView.View as Panel);
			ItemPropertiesInfoViewContent.Controls.Add(ItemDamageInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemDefenseInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemCritInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemKnockbackInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemShootInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemShootSpeedInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemUseTimeInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemUseAnimationInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemHealLifeInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemHealManaInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemCreateTileInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemPlaceStyleInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemCreateWallInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemTileBoostInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemBuffTypeInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemBuffTimeInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemManaConsumeInfoView);
			ItemPropertiesInfoViewContent.Controls.Add(ItemBaitInfoView);
			ItemPropertiesInfoView.Text = HackContext.CurrentLanguage["Properties"];
			ItemPropertiesInfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemPropertiesInfoView.Bounds = new Rectangle(5, 105, 255, 10 * 20);



			ItemDescription2InfoView = new InfoView(new TextBox() { BorderStyle = BorderStyle.FixedSingle, BackColor = ItemsTabPage.GlobalBack, ForeColor = Color.Black, Multiline = true }, InfoView.TipDock.Left);
			ItemDescription2InfoView.Text = HackContext.CurrentLanguage["Description"];
			ItemDescription2InfoView.TipLabel.BackColor = ItemsTabPage.ThemeColor;
			ItemDescription2InfoView.Bounds = new Rectangle(5, 320, 255, 80);

			Controls.Add(ItemIcon2InfoView);
			Controls.Add(ItemDetailInfoView);
			Controls.Add(ItemPropertiesInfoView);
			Controls.Add(ItemDescription2InfoView);
		}

		public void ResetData()
		{
			(ItemIcon2InfoView.View as PictureBox).Image = null;
			string desc = "";
			(ItemDescription2InfoView.View as TextBox).Text = desc;



			(ItemPickaxeInfoView.View as TextBox).Text = "";
			(ItemAxeInfoView.View as TextBox).Text = "";
			(ItemHammerInfoView.View as TextBox).Text = "";
			(ItemDamageInfoView.View as TextBox).Text = "";
			(ItemDefenseInfoView.View as TextBox).Text = "";
			(ItemCritInfoView.View as TextBox).Text = "";
			(ItemKnockbackInfoView.View as TextBox).Text = "";
			(ItemShootInfoView.View as TextBox).Text = "";
			(ItemShootSpeedInfoView.View as TextBox).Text = "";
			(ItemUseTimeInfoView.View as TextBox).Text = "";
			(ItemUseAnimationInfoView.View as TextBox).Text = "";
			(ItemHealLifeInfoView.View as TextBox).Text = "";
			(ItemHealManaInfoView.View as TextBox).Text = "";
			(ItemCreateTileInfoView.View as TextBox).Text = "";
			(ItemPlaceStyleInfoView.View as TextBox).Text = "";
			(ItemCreateWallInfoView.View as TextBox).Text = "";
			(ItemTileBoostInfoView.View as TextBox).Text = "";
			(ItemBuffTypeInfoView.View as TextBox).Text = "";
			(ItemBuffTimeInfoView.View as TextBox).Text = "";
			(ItemManaConsumeInfoView.View as TextBox).Text = "";
			(ItemBaitInfoView.View as TextBox).Text = "";
		}

		public void SetData(int id)
		{
			(ItemIcon2InfoView.View as PictureBox).Image = GameResLoader.GetItemImage(id);

			string desc = HackContext.GameLocLoader_en.GetItemTooltip(ItemsTabPage.ItemIDToS[id]).ToString();
			(ItemDescription2InfoView.View as TextBox).Text = desc;

			(ItemPickaxeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Pick.ToString();
			(ItemAxeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Axe.ToString();
			(ItemHammerInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Hammer.ToString();
			(ItemDamageInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Damage.ToString();
			(ItemDefenseInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Defense.ToString();
			(ItemCritInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Crit.ToString();
			(ItemKnockbackInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].KnockBack.ToString();
			(ItemShootInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Shoot.ToString();
			(ItemShootSpeedInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].ShootSpeed.ToString();
			(ItemUseTimeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].UseTime.ToString();
			(ItemUseAnimationInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].UseAnimation.ToString();
			(ItemHealLifeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].HealLife.ToString();
			(ItemHealManaInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].HealMana.ToString();
			(ItemCreateTileInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].CreateTile.ToString();
			(ItemPlaceStyleInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].PlaceStyle.ToString();
			(ItemCreateWallInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].CreateWall.ToString();
			(ItemTileBoostInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].TileBoost.ToString();
			(ItemBuffTypeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].BuffType.ToString();
			(ItemBuffTimeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].BuffTime.ToString();
			(ItemManaConsumeInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Mana.ToString();
			(ItemBaitInfoView.View as TextBox).Text = ItemsTabPage.ItemDatum[id].Bait.ToString();
		}
	}
}

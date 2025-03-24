using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THBAlbums;
using THBAlbums.Models;
using static MusicBeePlugin.Plugin;
using ReaLTaiizor;
namespace MusicBeePlugin
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AlName = new ReaLTaiizor.Controls.CrownLabel();
            this.Circle = new ReaLTaiizor.Controls.CrownLabel();
            this.Date = new ReaLTaiizor.Controls.CrownLabel();
            this.Year = new ReaLTaiizor.Controls.CrownLabel();
            this.Event = new ReaLTaiizor.Controls.CrownLabel();
            this.EventPage = new ReaLTaiizor.Controls.CrownLabel();
            this.Rate = new ReaLTaiizor.Controls.CrownLabel();
            this.Number = new ReaLTaiizor.Controls.CrownLabel();
            this.Disc = new ReaLTaiizor.Controls.CrownLabel();
            this.Track = new ReaLTaiizor.Controls.CrownLabel();
            this.Time = new ReaLTaiizor.Controls.CrownLabel();
            this.Property = new ReaLTaiizor.Controls.CrownLabel();
            this.Style = new ReaLTaiizor.Controls.CrownLabel();
            this.Only = new ReaLTaiizor.Controls.CrownLabel();
            this.Price = new ReaLTaiizor.Controls.CrownLabel();
            this.EventPrice = new ReaLTaiizor.Controls.CrownLabel();
            this.ShopPrice = new ReaLTaiizor.Controls.CrownLabel();
            this.Note = new ReaLTaiizor.Controls.CrownLabel();
            this.Official = new ReaLTaiizor.Controls.CrownLabel();
            this.CoverChar = new ReaLTaiizor.Controls.CrownLabel();
            this.dreamTextBox_AlName = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Circle = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Date = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Year = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Rate = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Number = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Event = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_EventPage = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Disc = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Track = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Time = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Property = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Style = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Only = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Price = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_EventPrice = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_ShopPrice = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Note = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_Official = new ReaLTaiizor.Controls.DreamTextBox();
            this.dreamTextBox_CoverChar = new ReaLTaiizor.Controls.DreamTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.airButton_SaveTag = new ReaLTaiizor.Controls.AirButton();
            this.airButton1 = new ReaLTaiizor.Controls.AirButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AlName
            // 
            this.AlName.AutoSize = true;
            this.AlName.ForeColor = System.Drawing.Color.Black;
            this.AlName.Location = new System.Drawing.Point(12, 146);
            this.AlName.Name = "AlName";
            this.AlName.Size = new System.Drawing.Size(53, 12);
            this.AlName.TabIndex = 0;
            this.AlName.Text = "专辑名称";
            // 
            // Circle
            // 
            this.Circle.AutoSize = true;
            this.Circle.ForeColor = System.Drawing.Color.Black;
            this.Circle.Location = new System.Drawing.Point(12, 173);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(53, 12);
            this.Circle.TabIndex = 1;
            this.Circle.Text = "制作社团";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.ForeColor = System.Drawing.Color.Black;
            this.Date.Location = new System.Drawing.Point(12, 227);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(53, 12);
            this.Date.TabIndex = 5;
            this.Date.Text = "发售时间";
            // 
            // Year
            // 
            this.Year.AutoSize = true;
            this.Year.ForeColor = System.Drawing.Color.Black;
            this.Year.Location = new System.Drawing.Point(12, 200);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(53, 12);
            this.Year.TabIndex = 4;
            this.Year.Text = "发售年份";
            // 
            // Event
            // 
            this.Event.AutoSize = true;
            this.Event.ForeColor = System.Drawing.Color.Black;
            this.Event.Location = new System.Drawing.Point(182, 38);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(29, 12);
            this.Event.TabIndex = 9;
            this.Event.Text = "展会";
            // 
            // EventPage
            // 
            this.EventPage.AutoSize = true;
            this.EventPage.ForeColor = System.Drawing.Color.Black;
            this.EventPage.Location = new System.Drawing.Point(182, 11);
            this.EventPage.Name = "EventPage";
            this.EventPage.Size = new System.Drawing.Size(53, 12);
            this.EventPage.TabIndex = 8;
            this.EventPage.Text = "展会词条";
            // 
            // Rate
            // 
            this.Rate.AutoSize = true;
            this.Rate.ForeColor = System.Drawing.Color.Black;
            this.Rate.Location = new System.Drawing.Point(182, 92);
            this.Rate.Name = "Rate";
            this.Rate.Size = new System.Drawing.Size(29, 12);
            this.Rate.TabIndex = 13;
            this.Rate.Text = "分级";
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.ForeColor = System.Drawing.Color.Black;
            this.Number.Location = new System.Drawing.Point(182, 65);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(53, 12);
            this.Number.TabIndex = 12;
            this.Number.Text = "专辑编号";
            // 
            // Disc
            // 
            this.Disc.AutoSize = true;
            this.Disc.ForeColor = System.Drawing.Color.Black;
            this.Disc.Location = new System.Drawing.Point(332, 38);
            this.Disc.Name = "Disc";
            this.Disc.Size = new System.Drawing.Size(53, 12);
            this.Disc.TabIndex = 17;
            this.Disc.Text = "专辑碟数";
            // 
            // Track
            // 
            this.Track.AutoSize = true;
            this.Track.ForeColor = System.Drawing.Color.Black;
            this.Track.Location = new System.Drawing.Point(332, 11);
            this.Track.Name = "Track";
            this.Track.Size = new System.Drawing.Size(65, 12);
            this.Track.TabIndex = 16;
            this.Track.Text = "专辑音轨数";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.ForeColor = System.Drawing.Color.Black;
            this.Time.Location = new System.Drawing.Point(332, 92);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(65, 12);
            this.Time.TabIndex = 21;
            this.Time.Text = "专辑总时长";
            // 
            // Property
            // 
            this.Property.AutoSize = true;
            this.Property.ForeColor = System.Drawing.Color.Black;
            this.Property.Location = new System.Drawing.Point(332, 65);
            this.Property.Name = "Property";
            this.Property.Size = new System.Drawing.Size(53, 12);
            this.Property.TabIndex = 20;
            this.Property.Text = "专辑类型";
            // 
            // Style
            // 
            this.Style.AutoSize = true;
            this.Style.ForeColor = System.Drawing.Color.Black;
            this.Style.Location = new System.Drawing.Point(182, 146);
            this.Style.Name = "Style";
            this.Style.Size = new System.Drawing.Size(53, 12);
            this.Style.TabIndex = 25;
            this.Style.Text = "专辑风格";
            // 
            // Only
            // 
            this.Only.AutoSize = true;
            this.Only.ForeColor = System.Drawing.Color.Black;
            this.Only.Location = new System.Drawing.Point(182, 119);
            this.Only.Name = "Only";
            this.Only.Size = new System.Drawing.Size(53, 12);
            this.Only.TabIndex = 24;
            this.Only.Text = "专辑选材";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.ForeColor = System.Drawing.Color.Black;
            this.Price.Location = new System.Drawing.Point(182, 200);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(53, 12);
            this.Price.TabIndex = 29;
            this.Price.Text = "发售价格";
            // 
            // EventPrice
            // 
            this.EventPrice.AutoSize = true;
            this.EventPrice.ForeColor = System.Drawing.Color.Black;
            this.EventPrice.Location = new System.Drawing.Point(182, 173);
            this.EventPrice.Name = "EventPrice";
            this.EventPrice.Size = new System.Drawing.Size(53, 12);
            this.EventPrice.TabIndex = 28;
            this.EventPrice.Text = "会场售价";
            // 
            // ShopPrice
            // 
            this.ShopPrice.AutoSize = true;
            this.ShopPrice.ForeColor = System.Drawing.Color.Black;
            this.ShopPrice.Location = new System.Drawing.Point(332, 200);
            this.ShopPrice.Name = "ShopPrice";
            this.ShopPrice.Size = new System.Drawing.Size(53, 12);
            this.ShopPrice.TabIndex = 40;
            this.ShopPrice.Text = "通贩售价";
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.ForeColor = System.Drawing.Color.Black;
            this.Note.Location = new System.Drawing.Point(332, 173);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(29, 12);
            this.Note.TabIndex = 37;
            this.Note.Text = "备注";
            // 
            // Official
            // 
            this.Official.AutoSize = true;
            this.Official.ForeColor = System.Drawing.Color.Black;
            this.Official.Location = new System.Drawing.Point(332, 146);
            this.Official.Name = "Official";
            this.Official.Size = new System.Drawing.Size(53, 12);
            this.Official.TabIndex = 36;
            this.Official.Text = "官网页面";
            // 
            // CoverChar
            // 
            this.CoverChar.AutoSize = true;
            this.CoverChar.ForeColor = System.Drawing.Color.Black;
            this.CoverChar.Location = new System.Drawing.Point(332, 119);
            this.CoverChar.Name = "CoverChar";
            this.CoverChar.Size = new System.Drawing.Size(53, 12);
            this.CoverChar.TabIndex = 32;
            this.CoverChar.Text = "封面角色";
            // 
            // dreamTextBox_AlName
            // 
            this.dreamTextBox_AlName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_AlName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_AlName.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_AlName.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_AlName.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_AlName.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_AlName.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_AlName.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_AlName.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_AlName.Location = new System.Drawing.Point(71, 141);
            this.dreamTextBox_AlName.Name = "dreamTextBox_AlName";
            this.dreamTextBox_AlName.Size = new System.Drawing.Size(102, 21);
            this.dreamTextBox_AlName.TabIndex = 41;
            // 
            // dreamTextBox_Circle
            // 
            this.dreamTextBox_Circle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Circle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Circle.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Circle.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Circle.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Circle.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Circle.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Circle.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Circle.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Circle.Location = new System.Drawing.Point(71, 168);
            this.dreamTextBox_Circle.Name = "dreamTextBox_Circle";
            this.dreamTextBox_Circle.Size = new System.Drawing.Size(102, 21);
            this.dreamTextBox_Circle.TabIndex = 42;
            // 
            // dreamTextBox_Date
            // 
            this.dreamTextBox_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Date.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Date.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Date.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Date.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Date.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Date.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Date.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Date.Location = new System.Drawing.Point(71, 222);
            this.dreamTextBox_Date.Name = "dreamTextBox_Date";
            this.dreamTextBox_Date.Size = new System.Drawing.Size(102, 21);
            this.dreamTextBox_Date.TabIndex = 44;
            // 
            // dreamTextBox_Year
            // 
            this.dreamTextBox_Year.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Year.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Year.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Year.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Year.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Year.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Year.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Year.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Year.Location = new System.Drawing.Point(71, 195);
            this.dreamTextBox_Year.Name = "dreamTextBox_Year";
            this.dreamTextBox_Year.Size = new System.Drawing.Size(102, 21);
            this.dreamTextBox_Year.TabIndex = 43;
            // 
            // dreamTextBox_Rate
            // 
            this.dreamTextBox_Rate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Rate.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Rate.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Rate.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Rate.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Rate.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Rate.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Rate.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Rate.Location = new System.Drawing.Point(236, 87);
            this.dreamTextBox_Rate.Name = "dreamTextBox_Rate";
            this.dreamTextBox_Rate.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_Rate.TabIndex = 48;
            // 
            // dreamTextBox_Number
            // 
            this.dreamTextBox_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Number.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Number.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Number.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Number.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Number.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Number.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Number.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Number.Location = new System.Drawing.Point(236, 60);
            this.dreamTextBox_Number.Name = "dreamTextBox_Number";
            this.dreamTextBox_Number.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_Number.TabIndex = 47;
            // 
            // dreamTextBox_Event
            // 
            this.dreamTextBox_Event.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Event.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Event.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Event.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Event.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Event.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Event.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Event.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Event.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Event.Location = new System.Drawing.Point(236, 33);
            this.dreamTextBox_Event.Name = "dreamTextBox_Event";
            this.dreamTextBox_Event.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_Event.TabIndex = 46;
            // 
            // dreamTextBox_EventPage
            // 
            this.dreamTextBox_EventPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_EventPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_EventPage.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_EventPage.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_EventPage.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_EventPage.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_EventPage.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_EventPage.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_EventPage.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_EventPage.Location = new System.Drawing.Point(236, 6);
            this.dreamTextBox_EventPage.Name = "dreamTextBox_EventPage";
            this.dreamTextBox_EventPage.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_EventPage.TabIndex = 45;
            // 
            // dreamTextBox_Disc
            // 
            this.dreamTextBox_Disc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_Disc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Disc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Disc.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Disc.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Disc.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Disc.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Disc.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Disc.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Disc.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Disc.Location = new System.Drawing.Point(403, 33);
            this.dreamTextBox_Disc.Name = "dreamTextBox_Disc";
            this.dreamTextBox_Disc.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_Disc.TabIndex = 56;
            // 
            // dreamTextBox_Track
            // 
            this.dreamTextBox_Track.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_Track.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Track.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Track.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Track.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Track.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Track.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Track.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Track.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Track.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Track.Location = new System.Drawing.Point(403, 6);
            this.dreamTextBox_Track.Name = "dreamTextBox_Track";
            this.dreamTextBox_Track.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_Track.TabIndex = 55;
            // 
            // dreamTextBox_Time
            // 
            this.dreamTextBox_Time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Time.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Time.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Time.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Time.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Time.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Time.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Time.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Time.Location = new System.Drawing.Point(403, 87);
            this.dreamTextBox_Time.Name = "dreamTextBox_Time";
            this.dreamTextBox_Time.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_Time.TabIndex = 54;
            // 
            // dreamTextBox_Property
            // 
            this.dreamTextBox_Property.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_Property.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Property.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Property.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Property.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Property.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Property.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Property.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Property.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Property.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Property.Location = new System.Drawing.Point(403, 60);
            this.dreamTextBox_Property.Name = "dreamTextBox_Property";
            this.dreamTextBox_Property.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_Property.TabIndex = 53;
            // 
            // dreamTextBox_Style
            // 
            this.dreamTextBox_Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Style.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Style.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Style.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Style.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Style.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Style.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Style.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Style.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Style.Location = new System.Drawing.Point(236, 142);
            this.dreamTextBox_Style.Name = "dreamTextBox_Style";
            this.dreamTextBox_Style.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_Style.TabIndex = 52;
            // 
            // dreamTextBox_Only
            // 
            this.dreamTextBox_Only.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Only.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Only.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Only.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Only.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Only.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Only.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Only.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Only.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Only.Location = new System.Drawing.Point(236, 114);
            this.dreamTextBox_Only.Name = "dreamTextBox_Only";
            this.dreamTextBox_Only.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_Only.TabIndex = 51;
            // 
            // dreamTextBox_Price
            // 
            this.dreamTextBox_Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Price.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Price.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Price.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Price.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Price.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Price.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Price.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Price.Location = new System.Drawing.Point(236, 196);
            this.dreamTextBox_Price.Name = "dreamTextBox_Price";
            this.dreamTextBox_Price.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_Price.TabIndex = 50;
            // 
            // dreamTextBox_EventPrice
            // 
            this.dreamTextBox_EventPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_EventPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_EventPrice.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_EventPrice.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_EventPrice.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_EventPrice.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_EventPrice.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_EventPrice.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_EventPrice.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_EventPrice.Location = new System.Drawing.Point(236, 169);
            this.dreamTextBox_EventPrice.Name = "dreamTextBox_EventPrice";
            this.dreamTextBox_EventPrice.Size = new System.Drawing.Size(90, 21);
            this.dreamTextBox_EventPrice.TabIndex = 49;
            // 
            // dreamTextBox_ShopPrice
            // 
            this.dreamTextBox_ShopPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_ShopPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_ShopPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_ShopPrice.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_ShopPrice.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_ShopPrice.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_ShopPrice.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_ShopPrice.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_ShopPrice.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_ShopPrice.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_ShopPrice.Location = new System.Drawing.Point(403, 195);
            this.dreamTextBox_ShopPrice.Name = "dreamTextBox_ShopPrice";
            this.dreamTextBox_ShopPrice.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_ShopPrice.TabIndex = 61;
            // 
            // dreamTextBox_Note
            // 
            this.dreamTextBox_Note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_Note.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Note.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Note.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Note.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Note.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Note.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Note.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Note.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Note.Location = new System.Drawing.Point(403, 168);
            this.dreamTextBox_Note.Name = "dreamTextBox_Note";
            this.dreamTextBox_Note.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_Note.TabIndex = 60;
            // 
            // dreamTextBox_Official
            // 
            this.dreamTextBox_Official.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_Official.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_Official.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_Official.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_Official.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_Official.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_Official.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_Official.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_Official.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_Official.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_Official.Location = new System.Drawing.Point(403, 141);
            this.dreamTextBox_Official.Name = "dreamTextBox_Official";
            this.dreamTextBox_Official.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_Official.TabIndex = 59;
            // 
            // dreamTextBox_CoverChar
            // 
            this.dreamTextBox_CoverChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dreamTextBox_CoverChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dreamTextBox_CoverChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox_CoverChar.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox_CoverChar.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox_CoverChar.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox_CoverChar.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox_CoverChar.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox_CoverChar.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox_CoverChar.ForeColor = System.Drawing.Color.Black;
            this.dreamTextBox_CoverChar.Location = new System.Drawing.Point(403, 114);
            this.dreamTextBox_CoverChar.Name = "dreamTextBox_CoverChar";
            this.dreamTextBox_CoverChar.Size = new System.Drawing.Size(122, 21);
            this.dreamTextBox_CoverChar.TabIndex = 57;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(10, 259);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(515, 298);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.TabStop = false;
            // 
            // airButton_SaveTag
            // 
            this.airButton_SaveTag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airButton_SaveTag.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton_SaveTag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airButton_SaveTag.Image = null;
            this.airButton_SaveTag.Location = new System.Drawing.Point(403, 222);
            this.airButton_SaveTag.Name = "airButton_SaveTag";
            this.airButton_SaveTag.NoRounding = false;
            this.airButton_SaveTag.Size = new System.Drawing.Size(122, 31);
            this.airButton_SaveTag.TabIndex = 64;
            this.airButton_SaveTag.Text = "保存到歌曲Tag";
            this.airButton_SaveTag.Transparent = false;
            this.airButton_SaveTag.Click += new System.EventHandler(this.airButton_SaveTag_Click);
            // 
            // airButton1
            // 
            this.airButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airButton1.Image = null;
            this.airButton1.Location = new System.Drawing.Point(184, 222);
            this.airButton1.Name = "airButton1";
            this.airButton1.NoRounding = false;
            this.airButton1.Size = new System.Drawing.Size(122, 31);
            this.airButton1.TabIndex = 65;
            this.airButton1.Text = "打开Tag编辑器";
            this.airButton1.Transparent = false;
            this.airButton1.Click += new System.EventHandler(this.airButton1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 568);
            this.Controls.Add(this.airButton1);
            this.Controls.Add(this.airButton_SaveTag);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dreamTextBox_ShopPrice);
            this.Controls.Add(this.dreamTextBox_Note);
            this.Controls.Add(this.dreamTextBox_Official);
            this.Controls.Add(this.dreamTextBox_CoverChar);
            this.Controls.Add(this.dreamTextBox_Disc);
            this.Controls.Add(this.dreamTextBox_Track);
            this.Controls.Add(this.dreamTextBox_Time);
            this.Controls.Add(this.dreamTextBox_Property);
            this.Controls.Add(this.dreamTextBox_Style);
            this.Controls.Add(this.dreamTextBox_Only);
            this.Controls.Add(this.dreamTextBox_Price);
            this.Controls.Add(this.dreamTextBox_EventPrice);
            this.Controls.Add(this.dreamTextBox_Rate);
            this.Controls.Add(this.dreamTextBox_Number);
            this.Controls.Add(this.dreamTextBox_Event);
            this.Controls.Add(this.dreamTextBox_EventPage);
            this.Controls.Add(this.dreamTextBox_Date);
            this.Controls.Add(this.dreamTextBox_Year);
            this.Controls.Add(this.dreamTextBox_Circle);
            this.Controls.Add(this.dreamTextBox_AlName);
            this.Controls.Add(this.AlName);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Event);
            this.Controls.Add(this.EventPage);
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.Disc);
            this.Controls.Add(this.Track);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Property);
            this.Controls.Add(this.Style);
            this.Controls.Add(this.Only);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.EventPrice);
            this.Controls.Add(this.ShopPrice);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.Official);
            this.Controls.Add(this.CoverChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Labels
        private ReaLTaiizor.Controls.CrownLabel AlName;
        private ReaLTaiizor.Controls.CrownLabel Circle;
        private ReaLTaiizor.Controls.CrownLabel Date;
        private ReaLTaiizor.Controls.CrownLabel Year;
        private ReaLTaiizor.Controls.CrownLabel Event;
        private ReaLTaiizor.Controls.CrownLabel EventPage;
        private ReaLTaiizor.Controls.CrownLabel Rate;
        private ReaLTaiizor.Controls.CrownLabel Number;
        private ReaLTaiizor.Controls.CrownLabel Disc;
        private ReaLTaiizor.Controls.CrownLabel Track;
        private ReaLTaiizor.Controls.CrownLabel Time;
        private ReaLTaiizor.Controls.CrownLabel Property;
        private ReaLTaiizor.Controls.CrownLabel Style;
        private ReaLTaiizor.Controls.CrownLabel Only;
        private ReaLTaiizor.Controls.CrownLabel Price;
        private ReaLTaiizor.Controls.CrownLabel EventPrice;
        private ReaLTaiizor.Controls.CrownLabel ShopPrice;
        private ReaLTaiizor.Controls.CrownLabel Note;
        private ReaLTaiizor.Controls.CrownLabel Official;
        private ReaLTaiizor.Controls.CrownLabel CoverChar;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_AlName;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Circle;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Date;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Year;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Rate;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Number;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Event;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_EventPage;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Disc;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Track;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Time;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Property;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Style;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Only;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Price;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_EventPrice;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_ShopPrice;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Note;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_Official;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox_CoverChar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ReaLTaiizor.Controls.AirButton airButton_SaveTag;
        private ReaLTaiizor.Controls.AirButton airButton1;
    }
}
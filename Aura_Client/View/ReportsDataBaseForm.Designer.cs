﻿namespace Aura_Client.View
{
    partial class ReportsDataBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsDataBaseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.prevMonthButton = new System.Windows.Forms.Button();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.organisationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonPurchasesContractsReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.singleSupplierContractsReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.failedPurchasesContractsReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.prevMonthButton);
            this.panel1.Controls.Add(this.yearComboBox);
            this.panel1.Controls.Add(this.monthComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 100);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(710, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prevMonthButton
            // 
            this.prevMonthButton.Location = new System.Drawing.Point(453, 39);
            this.prevMonthButton.Name = "prevMonthButton";
            this.prevMonthButton.Size = new System.Drawing.Size(31, 28);
            this.prevMonthButton.TabIndex = 2;
            this.prevMonthButton.Text = "<";
            this.prevMonthButton.UseVisualStyleBackColor = true;
            this.prevMonthButton.Click += new System.EventHandler(this.prevMonthButton_Click);
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.ItemHeight = 20;
            this.yearComboBox.Location = new System.Drawing.Point(617, 39);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(87, 28);
            this.yearComboBox.TabIndex = 1;
            this.yearComboBox.DropDownClosed += new System.EventHandler(this.yearComboBox_Leave);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.ItemHeight = 20;
            this.monthComboBox.Location = new System.Drawing.Point(490, 39);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(121, 28);
            this.monthComboBox.TabIndex = 0;
            this.monthComboBox.DropDownClosed += new System.EventHandler(this.yearComboBox_Leave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(12, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(12, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(980, 232);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.organisationID,
            this.inn,
            this.name,
            this.commonPurchasesContractsReport,
            this.singleSupplierContractsReport,
            this.failedPurchasesContractsReport});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(974, 226);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // organisationID
            // 
            this.organisationID.HeaderText = "id";
            this.organisationID.Name = "organisationID";
            this.organisationID.Width = 40;
            // 
            // inn
            // 
            this.inn.HeaderText = "ИНН";
            this.inn.Name = "inn";
            // 
            // name
            // 
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.Width = 200;
            // 
            // commonPurchasesContractsReport
            // 
            this.commonPurchasesContractsReport.HeaderText = "Договоры, заключенные по результатам закупок";
            this.commonPurchasesContractsReport.Name = "commonPurchasesContractsReport";
            this.commonPurchasesContractsReport.Width = 150;
            // 
            // singleSupplierContractsReport
            // 
            this.singleSupplierContractsReport.HeaderText = "Договоры с единственным поставщиком";
            this.singleSupplierContractsReport.Name = "singleSupplierContractsReport";
            this.singleSupplierContractsReport.Width = 150;
            // 
            // failedPurchasesContractsReport
            // 
            this.failedPurchasesContractsReport.HeaderText = "Договоры с единственным по результатам несостоявшихся процедур";
            this.failedPurchasesContractsReport.Name = "failedPurchasesContractsReport";
            this.failedPurchasesContractsReport.Width = 150;
            // 
            // ReportsDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 468);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportsDataBaseForm";
            this.Text = "Отчеты заказчиков";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn organisationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn inn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewButtonColumn commonPurchasesContractsReport;
        private System.Windows.Forms.DataGridViewButtonColumn singleSupplierContractsReport;
        private System.Windows.Forms.DataGridViewButtonColumn failedPurchasesContractsReport;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button prevMonthButton;
    }
}
﻿using Aura.Model;
using Aura_Client.Controller;
using Aura_Client.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Aura_Client.View
{
    public partial class OrganisationForm : AuraForm
    {
        private Organisation organisation;



        public OrganisationForm(Organisation organisation)
        {
            InitializeComponent();
            this.organisation = organisation;
            LoadCatalogs();
            creator = new CommandStringCreator("Organisations", organisation.id.ToString());
            Fill(organisation);
            FillTable(organisation);

        }

        private void LoadCatalogs()
        {
            foreach (var item in Catalog.contractConditions)
            {
                contractCondition.Items.Add(item);
            }

            foreach (var item in Catalog.contractOriginalConditions)
            {
                originalID.Items.Add(item);
            }

            foreach (var item in Catalog.laws)
            {
                law.Items.Add(item);
            }

            foreach (var item in Catalog.contractTypes)
            {
                contractType.Items.Add(item);
            }
        }

        private void Fill(Organisation org)
        {
            name.Text = org.name;
            inn.Text = org.inn;
            contactName.Text = org.contactName;
            phoneNumber.Text = org.phoneNumber;
            email.Text = org.email;
            //contractNumber.Text = org.contractNumber;
            //SetDate(contractStart, org.contractStart);
            //SetDate(contractEnd, org.contractEnd);
            contractCondition.SelectedIndex = org.contractCondition;
            originalID.SelectedIndex = org.originalID;
            law.SelectedIndex = org.law;
            contractType.SelectedIndex = org.contractType;

        }

        private void FillTable(Organisation org)
        {
            contractsDataGridView.Rows.Clear();
            string str = "SELECT * FROM Contracts WHERE organisationID = '" + org.id + "'";
            DataTable table = Program.dataManager.GetDataTable(str);

            foreach (DataRow tableRow in table.Rows)
            {
                Contract contract = new Contract(tableRow);
                int index = contractsDataGridView.Rows.Add();
                var row = contractsDataGridView.Rows[index];

                row.Cells["id"].Value = contract.id;
                row.Cells["contractNumber"].Value = contract.contractNumber;
                row.Cells["contractStart"].Value = ConvertDateToShortText(contract.contractStart);
                row.Cells["contractEnd"].Value = ConvertDateToShortText(contract.contractEnd);

            }

            
        }

        protected override void dateTime_ValueChanged(object sender, EventArgs e)
        {
            var picker = (DateTimePicker)sender;
            SetDate(picker, picker.Value.ToString("yyyy-MM-dd"));

            creator.Add(picker.Name, picker.Value.ToString("yyyy-MM-dd"));
        }

        protected override void textBox_ValueChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var textBox = (TextBox)sender;
                creator.Add(textBox.Name, textBox.Text);
            }
            if (sender is RichTextBox)
            {
                var textBox = (RichTextBox)sender;
                creator.Add(textBox.Name, textBox.Text);
            }


        }

        protected override void comboBox_ValueChanged(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            creator.Add(box.Name, box.SelectedIndex.ToString());
        }



        private void buttonOK_Click(object sender, EventArgs e)
        {
            SendToServer();
            timer1.Start();     //закрыть форму через время

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
        }

        private void SendToServer()
        {
            if (creator.IsNotEmpty())
            {
                if (organisation.id < 1)
                {
                    Program.bridge.SendMessage("NEWORGANISATION#" + creator.ToNew());
                }

                else
                {
                    Program.bridge.SendMessage("UPDATEORGANISATION#" + creator.ToUpdate());
                }
            }

            else
                Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}

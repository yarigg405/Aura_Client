﻿using Aura.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using Aura_Client.Model;
using System.Linq;

namespace Aura_Client.View
{
    public partial class DayInCalendarFullForm : AuraForm
    {
        private ComboBox currentComboBox = null;

        //Максимально подробная форма дня из календаря
        public DayInCalendarFullForm(DayInCalendar day) : base()
        {
            try
            {
                InitializeComponent();
                InitializeAuraForm();

                dateLabel.Text = day.date.ToShortDateString();
                // RefreshTable(day);

                CreateTable();
                InitContextMenuStrip();
                ReloadTable(day);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }


        private void CreateTable()
        {
            dayInCalendarDataGridView.Columns.Add("id", "id");
            dayInCalendarDataGridView.Columns["id"].Width = 50;

            dayInCalendarDataGridView.Columns.Add("purchaseName", "Наименование закупки");
            dayInCalendarDataGridView.Columns["purchaseName"].Width = 200;

            dayInCalendarDataGridView.Columns.Add("organizationID", "Заказчик");
            dayInCalendarDataGridView.Columns["organizationID"].Width = 150;

            dayInCalendarDataGridView.Columns.Add("purchaseMethodID", "Способ");
            dayInCalendarDataGridView.Columns["purchaseMethodID"].Width = 150;

            dayInCalendarDataGridView.Columns.Add("eventName", "Событие");
            dayInCalendarDataGridView.Columns["eventName"].Width = 150;

            dayInCalendarDataGridView.Columns.Add("statusID", "Статус");
            dayInCalendarDataGridView.Columns["statusID"].Width = 150;


            DataGridViewComboBoxColumn protocolStatusColumn = new DataGridViewComboBoxColumn();
            protocolStatusColumn.Name = "protocolStatusID";
            protocolStatusColumn.HeaderText = "Статус протокола";

            for (int i = 0; i < Catalog.protocolStatuses.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = Catalog.protocolStatuses[i];
                item.Value = i;
                protocolStatusColumn.Items.Add(item);

            }
            dayInCalendarDataGridView.Columns.Add(protocolStatusColumn);
            dayInCalendarDataGridView.Columns["protocolStatusID"].Width = 150;


        }

        private void InitContextMenuStrip()
        {
            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                item.Click -= MenuItemOnClick;
            }

            contextMenuStrip1.Items.Clear();

            foreach (DataGridViewColumn column in dayInCalendarDataGridView.Columns)
            {
                var item = new ToolStripMenuItem()
                {
                    Checked = column.Visible,
                    Text = column.HeaderText,
                    Name = column.Name,
                };

                item.Click += MenuItemOnClick;
                contextMenuStrip1.Items.Add(item);

            }


        }

        private void MenuItemOnClick(object sender, EventArgs eventArgs)
        {
            var target = (ToolStripMenuItem)sender;

            target.Checked = !target.Checked;

            dayInCalendarDataGridView.Columns[target.Name].Visible = target.Checked;
        }

        private void ReloadTable(DayInCalendar day)
        {
            CleatTable();
            FillTable(day);
        }

        private void CleatTable()
        {
            if (dayInCalendarDataGridView.Rows.Count > 0)
            {
                dayInCalendarDataGridView.Rows.Clear();
            }
        }

        private void FillTable(DayInCalendar day)
        {
            if (day.events.Count > 0)
            {
                var orgs = Program.dataManager.GetAllOrganisations();

                foreach (var ev in day.events)
                {
                    int rowIndex = dayInCalendarDataGridView.Rows.Add();
                    var newRow = dayInCalendarDataGridView.Rows[rowIndex];

                    newRow.Cells["id"].Value = ev.Key.id;

                    newRow.Cells["purchaseName"].Value = ev.Key.purchaseName;

                    Organisation org = orgs.SingleOrDefault(o => o.id == ev.Key.organizationID);
                    if (org == null || org.id < 1)
                        newRow.Cells["organizationID"].Value = "<не указано>";
                    else
                        newRow.Cells["organizationID"].Value = org.name;

                    newRow.Cells["purchaseMethodID"].Value =
                                Catalog.purchaseMethods[ev.Key.purchaseMethodID].name;

                    newRow.Cells["eventName"].Value = ev.Value;

                    newRow.Cells["statusID"].Value = Catalog.allStatuses[ev.Key.statusID];

                    //var cell = (DataGridViewComboBoxCell)newRow.Cells["protocolStatusID"];
                    //cell.Value = ev.Key.protocolStatusID;

                }


            }


        }


        private void RefreshTable(DayInCalendar day)
        {
            mainPanel.Controls.Clear();
            proceduresCountTextBox.Clear();

            //для подсчёта и отображения количества событий на дату
            Dictionary<string, int> countsOfProcedures  
                = new Dictionary<string, int>();

            foreach (var ev in day.events)
            {
                Button button = CreateButton(ev);
                if (countsOfProcedures.ContainsKey(ev.Value))
                    countsOfProcedures[ev.Value]++;
                else
                    countsOfProcedures.Add(ev.Value, 1);

                int x = 15;
                int y = (mainPanel.Controls.Count) * (button.Height + 5) + 5;
                button.Location = new Point(x, y);

                button.BackColor = GetProtocolStatusColor(ev.Key.protocolStatusID);

                mainPanel.Controls.Add(button);
            }

            RefreshCountText(countsOfProcedures);
        }

        private void RefreshCountText(Dictionary<string, int> countsOfProcedures)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pair in countsOfProcedures)
            {
                sb.Append(pair.Key);
                sb.Append(" - ");
                sb.Append(pair.Value);
                sb.Append("\n");
            }           

            proceduresCountTextBox.Text = sb.ToString();
        }

        private Button CreateButton(KeyValuePair<Purchase, string> eventOb)
        {
            int end = eventOb.Key.purchaseName.Length > 45 ? 45 
                : eventOb.Key.purchaseName.Length;
            string buttonText = eventOb.Key.purchaseName.Substring(0, end);


            Button button = new Button()
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(284, 40),
                Text = buttonText + "\n" + eventOb.Value,
                Name = eventOb.Key.id.ToString(),

            };

            button.Click += Button_Click;

            return button;
        }


        private void Button_Click(object sender, EventArgs e)
        {
            var id = ((Button)sender).Name;
            Purchase pur = Program.dataManager.GetPurchase(id);
            OpenPurchase(pur);

        }

        private void OpenPurchase(Purchase pur)
        {
            PurchaseForm form = new PurchaseForm(pur);
            form.ShowDialog();
        }

        private void DayInCalendarFullForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void contextMenuStrip1_Closing(object sender, 
            ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }

        private void dayInCalendarDataGridView_EditingControlShowing(object sender, 
            DataGridViewEditingControlShowingEventArgs e)
        {
            currentComboBox = e.Control as ComboBox;
        }

        private void dayInCalendarDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (currentComboBox != null)
                dayInCalendarDataGridView[e.ColumnIndex, e.RowIndex].Tag
                    = currentComboBox.SelectedIndex;

            
        }
    }
}

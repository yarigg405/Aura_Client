﻿using Aura.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Aura_Client.View
{
    public partial class PurchasesCalendarForm : AuraForm
    {
        //визуальное представление календаря закупок
        private int month;      //выбранный для отображание месяц
        private int year;       //выбранный для отображения год


        public PurchasesCalendarForm() : base()
        {
            InitializeComponent();
            InitializeAuraForm();

            month = DateTime.Today.Month - 1;
            year = DateTime.Today.Year - 2016;
            ShowDate();          

            RefreshTable();

            monthComboBox.MouseWheel += MonthComboBox_MouseWheel;
            yearComboBox.MouseWheel += MonthComboBox_MouseWheel;

        }

        private void MonthComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void ShowDate()
        {
            monthComboBox.SelectedIndex = month;
            yearComboBox.SelectedIndex = year;

        }


        //обработка смены даты
        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = monthComboBox.SelectedIndex;
            RefreshTable();
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = yearComboBox.SelectedIndex;
            RefreshTable();
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 0)
            {
                year--;
                month = 11;
            }
            ShowDate();
            RefreshTable();
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 11)
            {
                year++;
                month = 0;
            }
            ShowDate();
            RefreshTable();
        }


        //заполнение календаря
        private void RefreshTable()
        {
            Clear();
            Calendar calendar = new Calendar(Program.dataManager.GetAllPurchases());
            Fill(calendar.GetDays(month + 1, year + 2016));
        }

        private void Clear()
        {
            mainPanel.Controls.Clear();
        }        

        private void Fill(List<DayInCalendar> days)
        {
            //заполнить таблицу днями недели из List'а
            //в листе должны быть даты только из текущего месяца
            for (int i = 0; i < days.Count; i++)
            {
                DayInCalendar day = days[i];

                DayInCalendarForm form = new DayInCalendarForm(day);
                mainPanel.Controls.Add(form);

                form.Location = GetLocationForButton(day.date, form);


            }

        }

        private Point GetLocationForButton(DateTime day, DayInCalendarForm form)
        {
            //американская неделя начинается с воскресенья. Поэтому сдвигаем в конец.
            int x = day.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)day.DayOfWeek;
            x--;
            int weekDelta = 7 - x;      //когда месяц начинается не с понедельника

            int y = (day.Day + weekDelta) / 7;

            return new Point(x * (form.Width + 5), y * (form.Height + 5));
        }

        private void PurchasesCalendarForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }

}

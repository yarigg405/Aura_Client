﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aura_Client.View
{
    public partial class DayInCalendarForm : UserControl, IShowable
    {
        public DayInCalendarForm()
        {
            InitializeComponent();
        }

        public void OpenAuraForm()
        {
            Program.openedForms.Add(this);
        }

        public void CloseAuraForm()
        {
            Program.openedForms.Remove(this);
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura.Model;

namespace Aura_Client.Model
{


    public class Calendar : Dictionary<DateTime, DayInCalendar>
    {
        //класс, описывающий календарь
        public void Add(Purchase purchase)
        {
            if (purchase == null) return;

            Add(purchase.purchaseEisDate, purchase);
            Add(purchase.bidsStartDate, purchase);
            Add(purchase.bidsEndDate, purchase);
            Add(purchase.bidsOpenDate, purchase);
            Add(purchase.bidsFirstPartDate, purchase);
            Add(purchase.auctionDate, purchase);
            Add(purchase.bidsSecondPartDate, purchase);
            Add(purchase.bidsFinishDate, purchase);
            Add(purchase.contractDatePlan, purchase);
            Add(purchase.contractDateLast, purchase);
            Add(purchase.contractDateReal, purchase);
            Add(purchase.reestrDateLast, purchase);
            
        }




        private void Add(DateTime date, Purchase purchase)
        {
            if (!ContainsKey(date))
            {
                Add(date, new DayInCalendar(date));
            }
            
            this[date].Add(purchase);

        }


    }



    public static class ExtensionsMethods
    {
        //статический класс для расширящих методов
        public static DateTime ToDateTime(this string str)
        {
            return Convert.ToDateTime(str);

        }
    }


}



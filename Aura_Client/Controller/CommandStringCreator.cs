﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Client.Controller
{
    /// <summary>
    /// Класс для создания строковых команд для БД
    /// </summary>
    public class CommandStringCreator
    {
        private string tableName;                       //название таблицы в БД, с которой нужно работать
        private string objectID;                        //ID объекта в БД
        private Dictionary<string, string> changes;     //key - название поля, value - его новое значение

        public CommandStringCreator(string nameOfTable, string id)
        {
            tableName = nameOfTable;
            changes = new Dictionary<string, string>();
            objectID = id;
        }

        public void Add(string columnName, string value)
        {
            Console.WriteLine("ADDing string "+columnName+" "+value);
            if (changes.ContainsKey(columnName))
                changes[columnName] = value;

            else changes.Add(columnName, value);
        }

        public string ToNew()
        {
            //создать строку для добавления нового объекта в БД
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ");
            sb.Append(tableName);
            sb.Append(" (");
            foreach (var pair in changes)
            {
                sb.Append("'");
                sb.Append(pair.Key);
                sb.Append("', ");

            }
            sb.Length--;
            sb.Length--;

            sb.Append(") VALUES (");
            foreach (var pair in changes)
            {
                sb.Append("'");
                sb.Append(pair.Value);
                sb.Append("', ");
            }
            sb.Length--;
            sb.Length--;
            sb.Append(")");

            return sb.ToString();

        }

        public string ToUpdate()
        {
            //отредактировать имеющийся объект в БД
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ");
            sb.Append(tableName);
            sb.Append(" SET ");
            foreach (var pair in changes)
            {
                sb.Append(pair.Key);
                sb.Append(" = '");
                sb.Append(pair.Value);
                sb.Append("', ");
            }
            sb.Length--;
            sb.Length--;

            sb.Append(" WHERE ID = ");
            sb.Append(objectID);

            return sb.ToString();

        }

        public string ToFilterCommand()
        {
            //запрос на получение отфильтрованной информации
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(tableName);
            sb.Append(" WHERE ");

            foreach (var pair in changes)
            {
                sb.Append(pair.Key.Replace("VALUE", pair.Value));
                
                sb.Append(" AND ");
            }

            sb.Length -= 5;
            return sb.ToString();
            
        }

        public void Clear()
        {
            changes.Clear();
        }


        public bool IsNotEmpty()
        {
            //Добавлялись ли значения для изменения
            return changes.Count > 0;
        }

    }
}

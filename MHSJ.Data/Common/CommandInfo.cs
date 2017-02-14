using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft.DBUtility
{
    public class CommonConfig
    {
        public static string GetWeekCHA(string WeekENG)
        {
            string return_value = "";
            switch (WeekENG)
            {
                case "Monday":
                    return_value = "����һ";
                    return return_value;
                case "Tuesday":
                    return_value = "���ڶ�";
                    return return_value;
                case "Wednesday":
                    return_value = "������";
                    return return_value;
                case "Thursday":
                    return_value = "������";
                    return return_value;
                case "Friday":
                    return_value = "������";
                    return return_value;
                case "Saturday":
                    return_value = "������";
                    return return_value;
                case "Sunday":
                    return_value = "������";
                    return return_value;
            }
            return return_value;
        }//end
    }
    public enum EffentNextType
    {
        /// <summary>
        /// ������������κ�Ӱ�� 
        /// </summary>
        None,
        /// <summary>
        /// ��ǰ������Ϊ"select count(1) from .."��ʽ��������������ִ�У������ڻع�����
        /// </summary>
        WhenHaveContine,
        /// <summary>
        /// ��ǰ������Ϊ"select count(1) from .."��ʽ����������������ִ�У����ڻع�����
        /// </summary>
        WhenNoHaveContine,
        /// <summary>
        /// ��ǰ���Ӱ�쵽�������������0������ع�����
        /// </summary>
        ExcuteEffectRows,
        /// <summary>
        /// �����¼�-��ǰ������Ϊ"select count(1) from .."��ʽ����������������ִ�У����ڻع�����
        /// </summary>
        SolicitationEvent
    }   
    public class CommandInfo
    {
        public object ShareObject = null;
        public object OriginalData = null;
        event EventHandler _solicitationEvent;
        public event EventHandler SolicitationEvent
        {
            add
            {
                _solicitationEvent += value;
            }
            remove
            {
                _solicitationEvent -= value;
            }
        }
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
            {
                _solicitationEvent(this,new EventArgs());
            }
        }
        public string CommandText;
        public System.Data.Common.DbParameter[] Parameters;
        public EffentNextType EffentNextType = EffentNextType.None;
        public CommandInfo()
        {

        }
        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }
        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
       
    }
}

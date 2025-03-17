using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ConvertDate
    {
        internal static DateTime? ConvertDDMMYYYY_ToDateTime(string ddmmyyyy)
        {
            try
            {
                int year = Convert.ToInt32(ddmmyyyy.Substring(4, 4));
                int month = Convert.ToInt32(ddmmyyyy.Substring(2, 2));
                int day = Convert.ToInt32(ddmmyyyy.Substring(0, 2));

                return new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //return new Nullable<DateTime>();
            }
                

     
        }
        internal static string GetDBDate(DateTime? d)
        {
            if (d.HasValue)
            {
                 return string.Format("TO_DATE('{0}', 'YYMMDD HH24:MI:SS')", d.Value.Year.ToString() + d.Value.ToString("MMdd HH:mm:ss"));
            }

            return "null";
        }
        internal static string GetMMYYYY(string ddmmyyyy)
        {
            if (ddmmyyyy != null)
            {
                string year = ddmmyyyy.Substring(0, 4);
                string month = ddmmyyyy.Substring(5, 2);

                return month + "/" + year;
            }
            return "null";

        }
        //Convert find Number of Month 
        internal static string GetNumberOfMonth(string mmyyyy)
        {
            if (mmyyyy != null)
            {
                int year = Convert.ToInt32(mmyyyy.Substring(0, 4));
                int month = Convert.ToInt32(mmyyyy.Substring(5, 2));
               


                switch (month)
                {
                    case 2:
                        {
                            mmyyyy = Convert.ToString(System.DateTime.DaysInMonth(year, month));
                            break;
                        }
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        {
                            mmyyyy =  "31";
                            break;
                        }

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        {
                            mmyyyy = "30";
                            break;
                        }
                 


                }

                return mmyyyy;



            }
            return "0";

        }


    }
}
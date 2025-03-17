using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebApplication2.Models.Entity;
using Oracle.ManagedDataAccess.Client;


namespace WebApplication2.Models.Data
{
    public class PersonManager : BaseManager
    {
        public PersonInfo GetPersonInfos()
        {
            string strSql = "";
            PersonInfo item = null;
            List<PersonInfo> list = new List<PersonInfo>();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                strSql = "select * from person_info_tab where person_id in ('20197160')";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new PersonInfo();
                    if (!Convert.IsDBNull(reader["PERSON_ID"]))
                    {
                        item.PERSON_ID = Convert.ToString(reader["PERSON_ID"]);
                    }
                    if (!Convert.IsDBNull(reader["NAME"]))
                    {
                        item.NAME = Convert.ToString(reader["NAME"]);
                    }
                    if (!Convert.IsDBNull(reader["COUNTRY"]))
                    {
                        item.COUNTRY = Convert.ToString(reader["COUNTRY"]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close Connection db
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
            return item;
        }


        public string GetPersonName(string Emp_id)
        {
            string strSQL = "";
            PersonInfo item = new PersonInfo();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;
            try
            {
                strSQL = "select * from person_info_tab where person_id = '" + Emp_id + "'";

                cmd = new OracleCommand(strSQL,conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new PersonInfo();
                    if (!Convert.IsDBNull(reader["NAME"]))
                    {
                        item.NAME = Convert.ToString(reader["NAME"]);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //Close Connection db
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
            return item.NAME;
        }


    }
 }

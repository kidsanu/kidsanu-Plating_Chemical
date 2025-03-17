using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Entity;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication2.Models.Data
{
    public class PT_MC_ChemicalManager : BaseManager
    {
        public int AddMasterData(PT_MC_ChemicalInfo obj)
        {

            int result = 0;
            string strSQL = @"";
            strSQL += " insert into cmkt_pt_mc_chemical_structure (PART_NO,MACHINE_CODE,CHEMICAL_NAME,CHEMICAL_TANK,UNIT_MEAS,VOL,CTRL_HIGH,ACT_HIGH,CTRL_MEDIAN,ACT_CHE_SPY,ACT_LOW,CTRL_LOW,OPTIMUM,REP_POINT, ";
            strSQL += " WORK_FORMULA,REP_FORMULA,REMARK,REVISE_DATE,REVISE_BY,CREATE_DATE) ";
            strSQL += " values('" + obj.PART_NO + "','" + obj.MACHINE_CODE + "','" + obj.CHEMICAL_NAME + "','" + obj.CHEMICAL_TANK + "','" + obj.UNIT_MEAS + "','" + obj.VOL + "',";
            strSQL += " '" + obj.CTRL_HIGH + "','" + obj.ACT_HIGH + "','" + obj.CTRL_MEDIAN + "','" + obj.ACT_CHE_SPY + "','" + obj.ACT_LOW + "','" + obj.CTRL_LOW + "',";
            strSQL += " '" + obj.OPTIMUM + "' , '" + obj.REP_POINT + "','" + obj.WORK_FORMULA + "','" + obj.REP_FORMULA + "','" + obj.REMARK + "'," + ConvertDate.GetDBDate(obj.REVISE_DATE) + ",";
            strSQL += " '" + obj.REVISE_BY + "'," + ConvertDate.GetDBDate(obj.CREATE_DATE) + ")";
         
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(strSQL, conn);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
            return result;
        }



        public List<PT_MC_ChemicalInfo> GetPT_MC_ChemicalInfos(string MC_code)
        {
            string strSql = "";
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_ChemicalInfo> list = new List<PT_MC_ChemicalInfo>();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                strSql = "select * from cmkt_pt_mc_chemical_structure where machine_code = '" + MC_code + "' order by to_number(priority_item,99) asc";  

                cmd = new OracleCommand(strSql, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PT_MC_ChemicalInfo item = new PT_MC_ChemicalInfo();


                    item.MACHINE_CODE = reader["MACHINE_CODE"].ToString();
                    item.PART_NO = reader["PART_NO"].ToString();
                    item.CHEMICAL_NAME = reader["CHEMICAL_NAME"].ToString();
                    item.CHEMICAL_TANK = reader["CHEMICAL_TANK"].ToString();
                    item.UNIT_MEAS = reader["UNIT_MEAS"].ToString();
                    item.VOL = Convert.ToDecimal(reader["VOL"]);
                    item.CTRL_HIGH = Convert.ToDecimal(reader["CTRL_HIGH"]);
                    item.ACT_HIGH = Convert.ToDecimal(reader["ACT_HIGH"]);
                    item.CTRL_MEDIAN = Convert.ToDecimal(reader["CTRL_MEDIAN"]);
                    item.ACT_CHE_SPY = Convert.ToDecimal(reader["ACT_CHE_SPY"]);
                    item.ACT_LOW = Convert.ToDecimal(reader["ACT_LOW"]);
                    item.CTRL_LOW = Convert.ToDecimal(reader["CTRL_LOW"]);
                    item.OPTIMUM = Convert.ToDecimal(reader["OPTIMUM"]);
                    item.REP_POINT = Convert.ToDecimal(reader["REP_POINT"]);
                    item.WORK_FORMULA = reader["WORK_FORMULA"].ToString();
                    item.REP_FORMULA = reader["REP_FORMULA"].ToString();
                    item.REMARK = reader["REMARK"].ToString();
                    item.REVISE_DATE = Convert.ToDateTime(reader["REVISE_DATE"]);
                    item.REVISE_BY = reader["REVISE_BY"].ToString();
                    item.CREATE_DATE = Convert.ToDateTime(reader["CREATE_DATE"]);

                    list.Add(item);
                }
                reader.Close();

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
            return list;
        }

        public List<PT_MC_ChemicalInfo> GetPT_MC_ChemicalInfosProtek2()
        {
            string strSql = "";
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_ChemicalInfo> list = new List<PT_MC_ChemicalInfo>();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                strSql = "select * from cmkt_pt_mc_chemical_structure where machine_code = 'PLMCP03'";// where part_no in ('20100128','20100307') ";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PT_MC_ChemicalInfo item = new PT_MC_ChemicalInfo();


                    item.MACHINE_CODE = reader["MACHINE_CODE"].ToString();
                    item.PART_NO = reader["PART_NO"].ToString();
                    item.CHEMICAL_NAME = reader["CHEMICAL_NAME"].ToString();
                    item.CHEMICAL_TANK = reader["CHEMICAL_TANK"].ToString();
                    item.UNIT_MEAS = reader["UNIT_MEAS"].ToString();
                    item.VOL = Convert.ToDecimal(reader["VOL"]);
                    item.CTRL_HIGH = Convert.ToDecimal(reader["CTRL_HIGH"]);
                    item.ACT_HIGH = Convert.ToDecimal(reader["ACT_HIGH"]);
                    item.CTRL_MEDIAN = Convert.ToDecimal(reader["CTRL_MEDIAN"]);
                    item.ACT_CHE_SPY = Convert.ToDecimal(reader["ACT_CHE_SPY"]);
                    item.ACT_LOW = Convert.ToDecimal(reader["ACT_LOW"]);
                    item.CTRL_LOW = Convert.ToDecimal(reader["CTRL_LOW"]);
                    item.OPTIMUM = Convert.ToDecimal(reader["OPTIMUM"]);
                    item.REP_POINT = Convert.ToDecimal(reader["REP_POINT"]);
                    item.WORK_FORMULA = reader["WORK_FORMULA"].ToString();
                    item.REP_FORMULA = reader["REP_FORMULA"].ToString();
                    item.REMARK = reader["REMARK"].ToString();
                    item.REVISE_DATE = Convert.ToDateTime(reader["REVISE_DATE"]);
                    item.REVISE_BY = reader["REVISE_BY"].ToString();
                    item.CREATE_DATE = Convert.ToDateTime(reader["CREATE_DATE"]);

                    list.Add(item);
                }
                reader.Close();

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
            return list;
        }



    }


}
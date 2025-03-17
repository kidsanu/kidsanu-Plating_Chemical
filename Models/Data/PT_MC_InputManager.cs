using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Entity;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Globalization;
using System.Threading;

namespace WebApplication2.Models.Data
{
    public class PT_MC_InputManager : BaseManager
    {
        int MaxTranId;

        //,string[] strRep, double[] douActual
        public int AddDataAnalysis(PT_MC_InputResult objpt1,int intNo,string[] strMachineCode,string[] strPart, string[] strCheme_id,string[] strRemark, decimal[] deTritrate, string[] strWork)
        {
            string strpriority = Convert.ToString(intNo + 1);
            int result = 0;
            string strSQL = @"";
            //strSQL += " INSERT INTO CMKT_PT_ANALYSIS_RESULT_TAB(TRANSACTION_ID, MACHINE_CODE, PART_NO,CHEMICAL_TANK_ID, CHECK_POINT, DATED, DATED_APPLIED, EMPLOYEE_CODE, TRITRATE, RES, ACTUAL_SUPPLY,SHIFT,WORKING,REP_CALC,TIMED) ";
            //strSQL += " values('" + MaxTranId + "','" + strMachineCode[idx] + "','" + strPart[idx] + "','" + strCheme_id[idx] + "','" + objpt1.CHECK_POINT + "',sysdate,";
            //strSQL += " " + ConvertDate.GetDBDate(objpt1.DATED) + ",'" + objpt1.EMPLOYEE_CODE + "','" + douTritrate[idx] + "','" + objpt1.RES + "','" + douActual[idx] + "','" + objpt1.SHIFT + "','" + strWork[idx] + "',";
            //strSQL += " '" + strRep[idx] +"','" + objpt1.TIMED + "' )";

            strSQL += " INSERT INTO CMKT_PT_ANALYSIS_RESULT_TAB(TRANSACTION_ID, MACHINE_CODE, PART_NO,CHEMICAL_TANK_ID, CHECK_POINT, DATED, DATED_APPLIED, EMPLOYEE_CODE, TRITRATE, RES,SHIFT,WORKING,TIMED,PRIORITY_ITEM,REMARK) ";
            strSQL += " values('" + MaxTranId + "','" + strMachineCode[intNo] + "','" + strPart[intNo] + "','" + strCheme_id[intNo] + "','" + objpt1.CHECK_POINT + "',sysdate,";
            strSQL += " " + ConvertDate.GetDBDate(objpt1.DATED) + ",'" + objpt1.EMPLOYEE_CODE + "','" + deTritrate[intNo] + "','" + objpt1.RES + "','" + objpt1.SHIFT + "','" + strWork[intNo] + "',";
            strSQL += " '" + objpt1.TIMED + "','" + strpriority + "','" + strRemark[intNo] + "' )";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(strSQL, conn);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
                Thread.Sleep(500);

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

        public int GetMaxTransectionID()
        {
           
            string strSQL = "";

            //Create Command to connect db and excecute command
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //Create Command
                strSQL += "select MAX(transaction_id) + 1 as TRAN from cmkt_pt_analysis_result_tab ";

                cmd = new OracleCommand(strSQL, conn);
                //Connection db
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    MaxTranId = Convert.ToInt32(reader["TRAN"].ToString());
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
            return MaxTranId;
        }

        public List<PT_MC_InputResult> GetPT_MC_InputInfos()
        {
            string strSql = "";
            //public string GetMonthName(int month);
            string StrMonthNow = Convert.ToString(DateTime.Now.Month.ToString("d2"));
            //string StrMonthNow = Convert.ToString(DateTime.Now.Month);
            string StrYearNow = Convert.ToString(DateTime.Now.Year);
            string StrMonthYear = StrMonthNow + "/" + StrYearNow;

            //ConvertDate.GetMMYYYY
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_InputResult> list = new List<PT_MC_InputResult>();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = "select * from CMKT_PT_ANALYSIS_RESULT_TAB where PART_NO = '20100307'";// where part_no in ('20100128','20100307') ";

                //strSql = "select * from CMKT_PT_ANALYSIS_RESULT_TAB where machine_code = 'PLMCP02' and  TO_CHAR(trunc(dated),'mm/yyyy') = '" + StrMonthYear + "' ORDER BY transaction_id desc";


                strSql = @"select distinct(anr.transaction_id), anr.machine_code, anr.dated_applied, anr.shift, anr.timed, anr.employee_code, ps.name" +
                          " from CMKT_PT_ANALYSIS_RESULT_TAB anr " +
                           " left join person_info_tab ps on anr.employee_code = ps.person_id " +
                           " where anr.machine_code = 'PLMCP02' and  TO_CHAR(trunc(anr.dated), 'mm/yyyy') = '" + StrMonthYear + "' ORDER BY transaction_id desc ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PT_MC_InputResult item = new PT_MC_InputResult();

                    item.TRANSACTION_ID = Convert.ToInt32(reader["TRANSACTION_ID"]);
                    item.MACHINE_CODE = reader["MACHINE_CODE"].ToString();
                    //item.PART_NO = reader["PART_NO"].ToString();
                    //item.CHECK_POINT = reader["CHECK_POINT"].ToString();
                    item.DATED_APPLIED = Convert.ToDateTime(reader["DATED_APPLIED"]);
                    item.TIMED = reader["TIMED"].ToString();
                    item.EMPLOYEE_CODE = reader["EMPLOYEE_CODE"].ToString();
                    item.EMPLOYEE_NAME = reader["NAME"].ToString();

                    //if (!Convert.IsDBNull(reader["TRITRATE"]))
                    //{
                    //    item.TRITRATE = Convert.ToDouble(reader["TRITRATE"]);
                    //}
                    //else
                    //{
                    //    item.TRITRATE = 0;
                    //}

                    //if (!Convert.IsDBNull(reader["WORKING"]))
                    //{
                    //    item.WORKING = reader["WORKING"].ToString();
                    //}
                    //else
                    //{
                    //    item.WORKING = "0";
                    //}
                    //if (!Convert.IsDBNull(reader["REP_CALC"]))
                    //{
                    //    item.REP_CALC = reader["REP_CALC"].ToString();
                    //}
                    //else
                    //{
                    //    item.REP_CALC = "0";
                    //}


                    //if (!Convert.IsDBNull(reader["RES"]))
                    //{
                    //    item.RES = Convert.ToDouble(reader["RES"]);
                    //}
                    //else
                    //{
                    //    item.RES = 0;
                    //}
                    //if (!Convert.IsDBNull(reader["ACTUAL_SUPPLY"]))
                    //{
                    //    item.ACTUAL_SUPPLY = Convert.ToDouble(reader["ACTUAL_SUPPLY"]);
                    //}
                    //else
                    //{
                    //    item.ACTUAL_SUPPLY = 0;
                    //}

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

        public List<PT_MC_InputResult> GetPT_MC_InputInfosProtek2(string MC_Code)
        {
            string strSql = "";
            //public string GetMonthName(int month);
            string StrMonthNow = Convert.ToString(DateTime.Now.Month.ToString("d2"));
            //string StrMonthNow = Convert.ToString(DateTime.Now.Month);
            string StrYearNow = Convert.ToString(DateTime.Now.Year);
            string StrMonthYear = StrMonthNow + "/" + StrYearNow;

            //ConvertDate.GetMMYYYY
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_InputResult> list = new List<PT_MC_InputResult>();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = "select * from CMKT_PT_ANALYSIS_RESULT_TAB where PART_NO = '20100307'";// where part_no in ('20100128','20100307') ";

                //strSql = "select * from CMKT_PT_ANALYSIS_RESULT_TAB where machine_code = 'PLMCP03' and  TO_CHAR(trunc(dated),'mm/yyyy') = '" + StrMonthYear + "' ORDER BY transaction_id desc";

                strSql = @"select distinct(anr.transaction_id), anr.machine_code, anr.dated_applied, anr.shift, anr.timed, anr.employee_code, ps.name" +
                           " from CMKT_PT_ANALYSIS_RESULT_TAB anr " +
                            " left join person_info_tab ps on anr.employee_code = ps.person_id " +
                            " where anr.machine_code = '" + MC_Code + "' and  TO_CHAR(trunc(anr.dated), 'mm/yyyy') = '" + StrMonthYear + "' ORDER BY transaction_id desc ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PT_MC_InputResult item = new PT_MC_InputResult();

                    item.TRANSACTION_ID = Convert.ToInt32(reader["TRANSACTION_ID"]);
                    item.MACHINE_CODE = reader["MACHINE_CODE"].ToString();
                    //item.PART_NO = reader["PART_NO"].ToString();
                    //item.CHECK_POINT = reader["CHECK_POINT"].ToString();
                    item.DATED_APPLIED = Convert.ToDateTime(reader["DATED_APPLIED"]);
                    item.TIMED = reader["TIMED"].ToString();
                    item.EMPLOYEE_CODE = reader["EMPLOYEE_CODE"].ToString();
                    item.EMPLOYEE_NAME = reader["NAME"].ToString();

                    //if (!Convert.IsDBNull(reader["TRITRATE"]))
                    //{
                    //    item.TRITRATE = Convert.ToDouble(reader["TRITRATE"]);
                    //}
                    //else
                    //{
                    //    item.TRITRATE = 0;
                    //}

                    //if (!Convert.IsDBNull(reader["WORKING"]))
                    //{
                    //item.WORKING = reader["WORKING"].ToString();
                    //}
                    //else
                    //{
                    //    item.WORKING = "0";
                    //}
                    //if (!Convert.IsDBNull(reader["REP_CALC"]))
                    //{
                    //item.REP_CALC = reader["REP_CALC"].ToString();
                    //}
                    //else
                    //{
                    //    item.REP_CALC = "0";
                    //}


                    //if (!Convert.IsDBNull(reader["RES"]))
                    //{
                    //    item.RES = Convert.ToDouble(reader["RES"]);
                    //}
                    //else
                    //{
                    //    item.RES = 0;
                    //}
                    //if (!Convert.IsDBNull(reader["ACTUAL_SUPPLY"]))
                    //{
                    //    item.ACTUAL_SUPPLY = Convert.ToDouble(reader["ACTUAL_SUPPLY"]);
                    //}
                    //else
                    //{
                    //    item.ACTUAL_SUPPLY = 0;
                    //}

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


        public PT_MC_InputResult  GetPT_MC_ChemicalInfos_ByDatail(int? id)
        {

            //PT_MC_InputResult result = null;
            PT_MC_InputResult items = new PT_MC_InputResult();

            string strSql = "";
            //string strTranID = "123456";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {

                //strSql = "select * from CMKT_PT_ANALYSIS_RESULT_TAB where transaction_id = '" + id + "'";

                strSql = @"select arc.*,cht.chemical_tank_name,ani.chemical_name,psi.name from CMKT_PT_ANALYSIS_RESULT_TAB arc " +
                          " left join cmkt_pt_chemical_tank cht on cht.chemical_tank_id = arc.chemical_tank_id " +
                          " left join cmkt_pt_analysis_item ani on ani.part_no = arc.part_no " +
                          " left join person_info_tab psi on psi.PERSON_ID = arc.employee_code " +
                          " where arc.transaction_id = '" + id + "'";
                conn.Open();
                cmd = new OracleCommand(strSql, conn);

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items = new PT_MC_InputResult();

                    if (!Convert.IsDBNull(reader["TRANSACTION_ID"]))
                    {
                        items.TRANSACTION_ID = Convert.ToInt32(reader["TRANSACTION_ID"]);
                    }
                    if (!Convert.IsDBNull(reader["MACHINE_CODE"]))
                    {
                        items.MACHINE_CODE = Convert.ToString(reader["MACHINE_CODE"]);
                    }
                    //if (!Convert.IsDBNull(reader["MACHINE_NAME"]))
                    //{
                    //    items.MACHINE_NAME = Convert.ToString(reader["MACHINE_NAME"]);
                    //}
                    if (!Convert.IsDBNull(reader["PART_NO"]))
                    {
                        items.PART_NO = Convert.ToString(reader["PART_NO"]);
                    }
                    if (!Convert.IsDBNull(reader["CHEMICAL_NAME"]))
                    {
                        items.CHEMICAL_NAME = Convert.ToString(reader["CHEMICAL_NAME"]);
                    }
                    if (!Convert.IsDBNull(reader["CHEMICAL_TANK_ID"]))
                    {
                        items.CHEMICAL_TANK_ID = Convert.ToString(reader["CHEMICAL_TANK_ID"]);
                    }
                    if (!Convert.IsDBNull(reader["CHEMICAL_TANK_NAME"]))
                    {
                        items.CHEMICAL_TANK_NAME = Convert.ToString(reader["CHEMICAL_TANK_NAME"]);
                    }
                    if (!Convert.IsDBNull(reader["TRITRATE"]))
                    {
                        items.TRITRATE = Convert.ToDouble(reader["TRITRATE"]);
                    }
                    if (!Convert.IsDBNull(reader["WORKING"]))
                    {
                        items.WORKING = Convert.ToString(reader["WORKING"]);
                    }
                    if (!Convert.IsDBNull(reader["REP_CALC"]))
                    {
                        items.REP_CALC = Convert.ToString(reader["REP_CALC"]);
                    }
                    if (!Convert.IsDBNull(reader["ACTUAL_SUPPLY"]))
                    {
                        items.ACTUAL_SUPPLY = Convert.ToDouble(reader["ACTUAL_SUPPLY"]);
                    }
                    if (!Convert.IsDBNull(reader["DATED_APPLIED"]))
                    {
                        items.DATED_APPLIED = Convert.ToDateTime(reader["DATED_APPLIED"]);
                    }
                    if (!Convert.IsDBNull(reader["DATED"]))
                    {
                        items.DATED = Convert.ToDateTime(reader["DATED"]);
                    }
                    if (!Convert.IsDBNull(reader["TIMED"]))
                    {
                        items.TIMED = Convert.ToString(reader["TIMED"]);
                    }
                    if (!Convert.IsDBNull(reader["SHIFT"]))
                    {
                        items.SHIFT = Convert.ToString(reader["SHIFT"]);
                    }
                    if (!Convert.IsDBNull(reader["EMPLOYEE_CODE"]))
                    {
                        items.EMPLOYEE_CODE = Convert.ToString(reader["EMPLOYEE_CODE"]);
                    }
                    if (!Convert.IsDBNull(reader["NAME"]))
                    {
                        items.EMPLOYEE_NAME = Convert.ToString(reader["NAME"]);
                    }

                }

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
            return items;


        }

        //Test
        public PT_MC_InputResult GetPT_MC_ChemicalInfos_ByHistory(PT_MC_InputResult objcal, int? id)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {

                //strSql = "SELECT * FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP02' order by to_number(priority_item,99) asc ";


                strSql = @"select arc.*,cht.chemical_tank_name,ani.chemical_name,psi.name,cht.chemical_tank_id from CMKT_PT_ANALYSIS_RESULT_TAB arc " +
                         " left join cmkt_pt_chemical_tank cht on cht.chemical_tank_id = arc.chemical_tank_id " +
                         " left join cmkt_pt_analysis_item ani on ani.part_no = arc.part_no " +
                         " left join person_info_tab psi on psi.PERSON_ID = arc.employee_code " +
                         " where arc.transaction_id = '" + id + "' order by to_number(priority_item, 99)";

                //cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);

                DataTable dt = new DataTable();

                ad.Fill(dt);

                result = new PT_MC_InputResult();

                //result.DATED = DateTime.Now;



                //DataTable dtCloned = dt.Clone();

                //dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                //foreach (DataRow row in dt.Rows)

                //{
                //    dtCloned.ImportRow(row);
                //}

                if ( dt.Rows.Count != 0 )
                {
                    result.TRANSACTION_ID = Convert.ToInt32(dt.Rows[0]["TRANSACTION_ID"].ToString());
                    result.MACHINE_CODE = dt.Rows[0]["MACHINE_CODE"].ToString().Trim();
                    result.EMPLOYEE_CODE = dt.Rows[0]["EMPLOYEE_CODE"].ToString();
                    result.EMPLOYEE_NAME = dt.Rows[0]["NAME"].ToString();

                    string cellValue = dt.Rows[0]["DATED_APPLIED"].ToString();
                    result.DATED = DateTime.Parse(cellValue);

                    result.SHIFT = dt.Rows[0]["SHIFT"].ToString();
                    result.TIMED = dt.Rows[0]["TIMED"].ToString();

                }


                switch (result.MACHINE_CODE)
                {

                    case "PLMCP02":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTank[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNo[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCode[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItem[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_id[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritrate[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWork[i] = dtRow["WORKING"].ToString();
                            result.strRemark[i] = dtRow["REMARK"].ToString();
                            result.intNo[i] = i + 1;
                            i++;

                        }
                        break;

                    case "PLMCP03":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT2[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT2[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT2[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT2[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT2[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT2[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT2[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT2[i] = dtRow["REMARK"].ToString();
                            result.intNoPT2[i] = i + 1;
                            i++;

                        }
                        break;

                    case "PLMCP04":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT3[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT3[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT3[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT3[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT3[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT3[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT3[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT3[i] = dtRow["REMARK"].ToString();
                            result.intNoPT3[i] = i + 1;
                            i++;

                        }
                        break;

                    case "PLMCP05":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT4[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT4[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT4[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT4[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT4[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT4[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT4[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT4[i] = dtRow["REMARK"].ToString();
                            result.intNoPT4[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP06":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT5[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT5[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT5[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT5[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT5[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT5[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT5[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT5[i] = dtRow["REMARK"].ToString();
                            result.intNoPT5[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP07":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT6[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT6[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT6[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT6[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT6[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT6[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT6[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT6[i] = dtRow["REMARK"].ToString();
                            result.intNoPT6[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP08":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT7[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT7[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT7[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT7[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT7[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT7[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT7[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT7[i] = dtRow["REMARK"].ToString();
                            result.intNoPT7[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP09":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT8[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT8[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT8[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT8[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT8[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT8[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT8[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT8[i] = dtRow["REMARK"].ToString();
                            result.intNoPT8[i] = i + 1;
                            i++;

                        }
                        break;

                    case "PLMCP10A":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT9A[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT9A[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT9A[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT9A[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT9A[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT9A[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT9A[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT9A[i] = dtRow["REMARK"].ToString();
                            result.intNoPT9A[i] = i + 1;
                            i++;

                        }
                        break;

                    case "PLMCP10B":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankPT9B[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoPT9B[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT9B[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT9B[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT9B[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritratePT9B[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkPT9B[i] = dtRow["WORKING"].ToString();
                            result.strRemarkPT9B[i] = dtRow["REMARK"].ToString();
                            result.intNoPT9B[i] = i + 1;
                            i++;

                        }
                        break;
                }




                //result.EMPLOYEE_NAME = dtemp.
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


            return result;
        }

        //Test





        public int UpdateDataInputResult(int id, PT_MC_InputResult res)
        {
            int result = 0;
            string strSQL = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                strSQL += "UPDATE CMKT_PT_ANALYSIS_RESULT_TAB SET";
                strSQL += " TRITRATE='" + res.TRITRATE + "',";
                strSQL += " WORKING='" + res.WORKING + "',";
                strSQL += " REP_CALC='" + res.REP_CALC + "',";
                strSQL += " ACTUAL_SUPPLY='" + res.ACTUAL_SUPPLY + "'";
                strSQL += " WHERE TRANSACTION_ID='" + id + "'";

                cmd = new OracleCommand(strSQL, conn);
                //Connection db
                conn.Open();
                //Execute Command
                result = cmd.ExecuteNonQuery();
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
            return result;
        }

        public int DeleteDataInputResult(int id)
        {
            int result = 0;
            string strSQL = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                strSQL += "DELETE CMKT_PT_ANALYSIS_RESULT_TAB ";
                strSQL += " WHERE TRANSACTION_ID='" + id + "'";

                cmd = new OracleCommand(strSQL, conn);
                //Connection db
                conn.Open();
                //Execute Command
                result = cmd.ExecuteNonQuery();
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
            return result;
        }

        public int SaveEleProtek1(PT_MC_InputResult objpt1)
        {

            int result = 0;
            string strSQL = @"";
            //strSQL += " insert into cmkt_pt_mc_chemical_structure (PART_NO,MACHINE_CODE,CHEMICAL_NAME,CHEMICAL_TANK,UNIT_MEAS,VOL,CTRL_HIGH,ACT_HIGH,CTRL_MEDIAN,ACT_CHE_SPY,ACT_LOW,CTRL_LOW,OPTIMUM,REP_POINT, ";
            //strSQL += " WORK_FORMULA,REP_FORMULA,REMARK,REVISE_DATE,REVISE_BY,CREATE_DATE) ";
            //strSQL += " values('" + obj.PART_NO + "','" + obj.MACHINE_CODE + "','" + obj.CHEMICAL_NAME + "','" + obj.CHEMICAL_TANK + "','" + obj.UNIT_MEAS + "','" + obj.VOL + "',";
            //strSQL += " '" + obj.CTRL_HIGH + "','" + obj.ACT_HIGH + "','" + obj.CTRL_MEDIAN + "','" + obj.ACT_CHE_SPY + "','" + obj.ACT_LOW + "','" + obj.CTRL_LOW + "',";
            //strSQL += " '" + obj.OPTIMUM + "' , '" + obj.REP_POINT + "','" + obj.WORK_FORMULA + "','" + obj.REP_FORMULA + "','" + obj.REMARK + "'," + ConvertDate.GetDBDate(obj.REVISE_DATE) + ",";
            //strSQL += " '" + obj.REVISE_BY + "'," + ConvertDate.GetDBDate(obj.CREATE_DATE) + ")";

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

        public PT_MC_InputResult GetDataProtek1Main(PT_MC_InputResult objcal)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {

                strSql = "SELECT * FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP02' order by to_number(priority_item,99) asc ";
                //cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
             
                DataTable dt = new DataTable();
               
                ad.Fill(dt);
               
                result = new PT_MC_InputResult();

                //result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                foreach (DataRow row in dt.Rows)

                {
                    dtCloned.ImportRow(row);
                }


                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNo[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCode[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItem[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_id[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemark[i] = dtRow["REMARK"].ToString();
                    result.intNo[i] = i + 1;
                    i++;

                }

                //result.EMPLOYEE_NAME = dtemp.
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


            return result;
            }

        //Protek2
        public PT_MC_InputResult GetDataProtek2Main(PT_MC_InputResult objcal,string MC_Code)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {

                strSql = "SELECT * FROM cmkt_pt_mc_chemical_structure  where machine_code = '" + MC_Code + "' order by to_number(priority_item,99) asc ";
                //cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);

                DataTable dt = new DataTable();

                ad.Fill(dt);

                result = new PT_MC_InputResult();

                //result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                foreach (DataRow row in dt.Rows)

                {
                    dtCloned.ImportRow(row);
                }


                switch (MC_Code)
                {


                    case "PLMCP03":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT2[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT2[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT2[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT2[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT2[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT2[i] = dtRow["REMARK"].ToString();
                            result.intNoPT2[i] = i + 1;
                            i++;

                        }
                        break;

                    case "PLMCP04":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT3[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT3[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT3[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT3[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT3[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT3[i] = dtRow["REMARK"].ToString();
                            result.intNoPT3[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP05":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT4[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT4[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT4[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT4[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT4[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT4[i] = dtRow["REMARK"].ToString();
                            result.intNoPT4[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP06":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT5[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT5[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT5[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT5[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT5[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT5[i] = dtRow["REMARK"].ToString();
                            result.intNoPT5[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP07":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT6[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT6[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT6[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT6[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT6[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT6[i] = dtRow["REMARK"].ToString();
                            result.intNoPT6[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP08":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT7[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT7[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT7[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT7[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT7[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT7[i] = dtRow["REMARK"].ToString();
                            result.intNoPT7[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP09":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT8[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT8[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT8[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT8[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT8[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT8[i] = dtRow["REMARK"].ToString();
                            result.intNoPT8[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP10A":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT9A[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT9A[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT9A[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT9A[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT9A[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT9A[i] = dtRow["REMARK"].ToString();
                            result.intNoPT9A[i] = i + 1;
                            i++;

                        }
                        break;
                    case "PLMCP10B":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT9B[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT9B[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT9B[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT9B[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT9B[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT9B[i] = dtRow["REMARK"].ToString();
                            result.intNoPT9B[i] = i + 1;
                            i++;

                        }
                        break;



                    //Almex
                    case "PLEP01":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoPT9B[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodePT9B[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankPT9B[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemPT9B[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idPT9B[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkPT9B[i] = dtRow["REMARK"].ToString();
                            result.intNoPT9B[i] = i + 1;
                            i++;

                        }
                        break;
                }

                //result.EMPLOYEE_NAME = dtemp.
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


            return result;
        }


        public PT_MC_InputResult GetDataProtek1(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {

                //AddDataAnalysis();


                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP02' order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql,conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                ////result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                //dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                //foreach (DataRow row in dt.Rows)

                //{
                //    dtCloned.ImportRow(row);
                //}

                ////Variable for Rep Cal 


                foreach (DataRow dtRow in dt.Rows)
                {
                 result.strPartNo[i] = dtRow["PART_NO"].ToString();
                 result.strMachineCode[i] = dtRow["MACHINE_CODE"].ToString();
                 result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                 result.stranalysisItem[i] = dtRow["CHEMICAL_NAME"].ToString();
                 result.strchemicalTank_id[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                 result.strRemark[i] = dtRow["REMARK"].ToString();
                 result.intNo[i] = i + 1;
                 i++;


                 }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];
                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }


                //TempWorking[0] = ResultCal;
               
                //TempWorking[1] = ResultCal2;
              
                //TempWorking[2] = ResultCal3;
               
                //TempWorking[3] = ResultCal4;
               
                //TempWorking[4] = ResultCal5;
                
                //TempWorking[5] = ResultCal6;
               
                //TempWorking[6] = ResultCal7;
               
                //TempWorking[7] = ResultCal8;
               
                //TempWorking[8] = ResultCal9;
                
                //TempWorking[9] = ResultCal10;
               
                //TempWorking[10] = ResultCal11;




                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)
                int t = Convert.ToInt32(result.intNo.Length.ToString());

                for (i = 0; i < t; i++ )
                {
                    AddDataAnalysis(spt1,i, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.strRemark, TempTritrate, TempWorking);
                }
               // AddDataAnalysis();





                //Calculator 1 Alchelate
                //if (cal1 == "Cal 1" || Save1 == "Save 1")
                //{
                //    // result.ACTUAL_SUPPLY = Convert.ToDouble(spt1.TRITRATE * 0.1 / 2);
                //    //double WorkCal;
                //    //--double TempCal = Convert.ToDouble(spt1.TRITRATE * 0.1 / 2);
                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);
                //    double TempCal = Math.Round(Convert.ToDouble(spt1.TRITRATE * 0.1 / 2),2);
                //    //result.WORKING = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE * 0.1 / 2),2));
                //    result.douTritrate[0] = Convert.ToDouble(spt1.TRITRATE);
                //    result.strWork[0] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE * 0.1 / 2), 2));

                //    //double WorkCal = Convert.ToDouble(result.WORKING);
                //    double TempRepCal;

                //    if (TempCal <= 0.57) //เติม
                //    {
                //        TempRepCal = Math.Round(((0.6 - TempCal) * TempVol * 0.3765),2);
                //    }
                //    else // ไม่เติม
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[0] = Convert.ToString(TempRepCal);

                //    //if (TempCal >= 0.58)
                //    //{
                //    //    //result.REP_CALC = "0";
                //    //    result.strRep[0] = "0";
                //    //}
                //    //else if (TempCal > 0.5)
                //    //{
                //    //    //result.REP_CALC = "20";
                //    //    result.strRep[0] = "20";
                //    //}
                //    //else
                //    //{
                //    //    //result.REP_CALC = "40";
                //    //    result.strRep[0] = "40";
                //    //}


                //    result.douActual[0] = Convert.ToDouble(spt1.ACTUAL_SUPPLY);

                //    if ( spt1.TRITRATE != null && Save1 == "Save 1")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1,0,result.strMachineCode,result.strPartNo,result.strchemicalTank_id, result.douTritrate, result.strWork,result.strRep, result.douActual);
                //        result.strWork[0] = "";
                //        result.strRep[0] = "";

                //    } 

                //}

                ////Calculator 2 Acip dip
                //else if (cal2 == "Cal 2" || Save2 == "Save 2")
                //{

                //    var deRepCalAc = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK") == "Acip dip").Sum(p => p.Field<decimal>("REP_POINT"));

                //    double TempRepcal = Decimal.ToDouble(deRepCalAc);
                //    result.douTritrate[1] = Convert.ToDouble(spt1.TRITRATE2);
                //    double TempCal2 = Convert.ToDouble(spt1.TRITRATE2 * 0.556);

                //    result.strWork[1] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE2 * 0.556), 2));



                //    if (TempCal2 >= TempRepcal)
                //    {
                //        result.strRep[1] = "0";
                //    }

                //    else
                //    {
                //        result.strRep[1] = Convert.ToString(Math.Round(((TempRepcal - TempCal2) * 1850 / (100)),2));
                //    }

                //    result.douActual[1] = Convert.ToDouble(spt1.ACTUAL_SUPPLY2);

                //    if (spt1.TRITRATE2 != null && Save2 == "Save 2")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 1, result.strMachineCode,result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep,result.douActual);
                //        result.strWork[1] = "";
                //        result.strRep[1] = "";
                //    }

                //}

                ////Calculator 3 CuO
                //else if (cal3 == "Cal 3" || Save3 == "Save 3")
                //{
                //    //var deRepCalCu = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("REP_POINT"));
                //    //double TempRepcal = Decimal.ToDouble(deRepCalCu);
                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);

                //    result.douTritrate[2] = Convert.ToDouble(spt1.TRITRATE3);
                //    double TempCal3 = Math.Round(Convert.ToDouble(spt1.TRITRATE3 * 12.5),2);

                //    result.strWork[2] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE3 * 12.5), 2));


                //    double TempRepCal;

                //    if (TempCal3 <= 66.87) //เติม
                //    {
                //        TempRepCal = Math.Round(((70 - TempCal3) * TempVol * (0.32 / 1000)), 2);
                //    }
                //    else // ไม่เติม
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[2] = Convert.ToString(TempRepCal);

                //    //if (TempCal3 >= TempRepcal)
                //    //{
                //    //    result.strRep[2] = "0";
                //    //}

                //    //else
                //    //{
                //    //    result.strRep[2] = Convert.ToString(Math.Round(((TempRepcal - TempCal3) * 960000 * 0.33/1000), 2));
                //    //}

                //    result.douActual[2] = Convert.ToDouble(spt1.ACTUAL_SUPPLY3);

                //    if (spt1.TRITRATE3 != null && Save3 == "Save 3")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 2, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[2] = "";
                //        result.strRep[2] = "";
                //    }

                //}

                ////Calculator 4 H2SO4
                //else if (cal4 == "Cal 4" || Save4 == "Save 4")
                //{
                //    //var deRepCalH2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Sum(p => p.Field<decimal>("REP_POINT"));
                //    //double TempRepcal = Decimal.ToDouble(deRepCalH2);
                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);

                //    result.douTritrate[3] = Convert.ToDouble(spt1.TRITRATE4);
                //    double TempCal4 = Math.Round((Convert.ToDouble(spt1.TRITRATE4 * 24.5)),2);

                //    result.strWork[3] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE4 * 24.5), 2));


                //    double TempRepCal;

                //    if (TempCal4 <= 232.50 ) //เติม
                //    {
                //        TempRepCal = Math.Round(((235 - TempCal4) * (TempVol / 1000) / 30), 2);
                //    }
                //    else // ไม่เติม
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[3] = Convert.ToString(TempRepCal);

                //    //if (TempCal4 >= TempRepcal)
                //    //{
                //    //    result.strRep[3] = "0";
                //    //}

                //    //else
                //    //{
                //    //    result.strRep[3] = Convert.ToString(Math.Round(((TempRepcal - TempCal4) * 960000 / (30 * 1000)), 2));
                //    //}

                //    result.douActual[3] = Convert.ToDouble(spt1.ACTUAL_SUPPLY4);

                //    if (spt1.TRITRATE4 != null && Save4 == "Save 4")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 3, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[3] = "";
                //        result.strRep[3] = "";
                //    }

                //}

                ////Calculator 5 Cl
                //else if (cal5 == "Cal 5" || Save5 == "Save 5")
                //{
                //    //var deRepCalCl = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Sum(p => p.Field<decimal>("REP_POINT"));
                //    //double TempRepcal = Decimal.ToDouble(deRepCalCl);
                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);

                //    result.douTritrate[4] = Convert.ToDouble(spt1.TRITRATE5);

                //    double TempCal5 = Math.Round(Convert.ToDouble(spt1.TRITRATE5 * 140.86),2);

                //    result.strWork[4] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE5 * 140.86), 2));

                //    double TempRepCal;

                //    if (TempCal5 <= 43.66)
                //    {
                //        TempRepCal = ((45 - TempCal5) * TempVol * 0.0026 / 1000);
                //    }
                //    else
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[4] = Convert.ToString(TempRepCal);

                //    //if (TempCal5 >= TempRepcal)
                //    //{
                //    //    result.strRep[4] = "0";
                //    //}

                //    //else
                //    //{
                //    //    result.strRep[4] = Convert.ToString(Math.Round(((TempRepcal - TempCal5) * 96000 * (0.00226/1000)), 2));
                //    //}



                //    result.douActual[4] = Convert.ToDouble(spt1.ACTUAL_SUPPLY5);

                //    if (spt1.TRITRATE5 != null && Save5 == "Save 5")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 4, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[4] = "";
                //        result.strRep[4] = "";
                //    }

                //}

                ////Calculator 6 HS200 Part A
                //else if (cal6 == "Cal 6" || Save6 == "Save 6")
                //{
                //    //var deHS200AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("HS200AB"));
                //    //var deHS200TANK = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("HS200TANK"));


                //    //double TempHS200 = Decimal.ToDouble(deHS200AM);
                //    //double TempHS200TANK = Decimal.ToDouble(deHS200TANK);

                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);

                //    result.douTritrate[5] = Convert.ToDouble(spt1.TRITRATE6);
                //    //result.strWork[5] = Convert.ToString(result.douTritrate[5]);

                //    result.strWork[5] = Convert.ToString(spt1.TRITRATE6);

                //    double TempCal6 = Convert.ToDouble(spt1.TRITRATE6);

                //    double TempRepCal;

                //    if (TempCal6 <= 0.600)
                //    {
                //        TempRepCal = Math.Round(((0.700 - TempCal6) * TempVol / 2 / 1000),3);
                //    }
                //    else
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[5] = Convert.ToString(TempRepCal);

                //    //string TempCal5 = Convert.ToString(Math.Round((TempHS200 - Convert.ToDouble(spt1.TRITRATE6)) * (TempHS200TANK /2/1000),2));


                //    //result.strWork[5] = Convert.ToString(result.douTritrate[5]);

                //    //result.strRep[5] = TempCal5;


                //    result.douActual[5] = Convert.ToDouble(spt1.ACTUAL_SUPPLY6);

                //    if (spt1.TRITRATE6 != null && Save6 == "Save 6")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 5, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[5] = "";
                //        result.strRep[5] = "";
                //    }

                //}

                ////Calculator 7 HS 200B-1
                //else if (cal7 == "Cal 7" || Save7 == "Save 7")
                //{
                //    //var deHS200BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Sum(p => p.Field<decimal>("HS200AB"));
                //    //var deHS200TANK = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Sum(p => p.Field<decimal>("HS200TANK"));

                //    //double TempHS200 = Decimal.ToDouble(deHS200BM);
                //    //double TempHS200TANK = Decimal.ToDouble(deHS200TANK);

                //    result.douTritrate[6] = Convert.ToDouble(spt1.TRITRATE7);
                //    double TempCal7 = Convert.ToDouble(spt1.TRITRATE7);
                //    //string TempCal6 = Convert.ToString(Math.Round((TempHS200 - Convert.ToDouble(spt1.TRITRATE7)) * (TempHS200TANK / 2 / 1000), 2));



                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);


                //    result.strWork[6] = Convert.ToString(spt1.TRITRATE7);


                //    double TempRepCal;

                //    if (TempCal7 <= 6.00)
                //    {
                //        TempRepCal = Math.Round(((7.5 - TempCal7) * TempVol / 2 / 1000), 2);
                //    }
                //    else
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[6] = Convert.ToString(TempRepCal);



                //    //result.strWork[6] = Convert.ToString(result.douTritrate[6]);

                //    //result.strRep[6] = TempCal6;


                //    result.douActual[6] = Convert.ToDouble(spt1.ACTUAL_SUPPLY7);

                //    if (spt1.TRITRATE7 != null && Save7 == "Save 7")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 6, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[6] = "";
                //        result.strRep[6] = "";
                //    }

                //}

                ////Calculator 8 H2O2 Conc.   
                //else if (cal8 == "Cal 8" || Save8 == "Save 8")
                //{

                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100074" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00004").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);

                //    //double TempRepcal = Decimal.ToDouble(deRepCalCl);
                //    result.douTritrate[7] = Convert.ToDouble(spt1.TRITRATE8);
                //    //double TempCal8 = Convert.ToDouble(spt1.TRITRATE8 * 4.28);


                //    double TempCal8 = Math.Round((Convert.ToDouble(spt1.TRITRATE8 * 4.28)), 2);


                //    result.strWork[7] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE8 * 4.28), 2));

                //    //result.strRep[7] = Convert.ToString(Math.Round((120 - TempCal8) * 600 / 1000,2));

                //    double TempRepCal;

                //    if (TempCal8 <= 110)
                //    {
                //        TempRepCal = Math.Round(((120 - TempCal8) * TempVol / 1000), 2);
                //    }
                //    else
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[7] = Convert.ToString(TempRepCal);

                //    result.douActual[7] = Convert.ToDouble(spt1.ACTUAL_SUPPLY8);

                //    if (spt1.TRITRATE8 != null && Save8 == "Save 8")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 7, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[7] = "";
                //        result.strRep[7] = "";
                //    }

                //}

                ////Calculator 9 ST-479
                //else if (Save9 == "Save 9")
                //{
                //    result.douTritrate[8] = Convert.ToDouble(spt1.TRITRATE9);

                //    result.strWork[8] = spt1.WORKING9;

                //    result.strRep[8] = spt1.REP_CALC9;

                //    result.douActual[8] = Convert.ToDouble(spt1.ACTUAL_SUPPLY9);

                //    if (spt1.TRITRATE9 != null && Save9 == "Save 9")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 8, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[8] = "";
                //        result.strRep[8] = "";
                //    }

                //}

                ////Calculator 10 H2SO4 Conc.
                //else if (cal10 == "Cal 10" || Save10 == "Save 10")
                //{

                //    var CalVol = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00004").Sum(p => p.Field<decimal>("VOL"));
                //    double TempVol = Decimal.ToDouble(CalVol);

                //    //double TempRepcal = Decimal.ToDouble(deRepCalCl);
                //    result.douTritrate[9] = Convert.ToDouble(spt1.TRITRATE10);

                //    double TempCal10 = Math.Round(Convert.ToDouble(spt1.TRITRATE10 * 27.2),2);

                //    result.strWork[9] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE10 * 27.2), 2));

                //    double TempRepCal;

                //    if (TempCal10 <= 90)
                //    {
                //        TempRepCal = Math.Round(((100 - TempCal10) * TempVol / (1.84 * 1000)), 3);
                //    }
                //    else
                //    {
                //        TempRepCal = 0;
                //    }

                //    result.strRep[9] = Convert.ToString(TempRepCal);

                //    //result.strRep[9] = Convert.ToString(Math.Round((100 - TempCal10) * 600 / (1.84 * 1000), 2));

                //    result.douActual[9] = Convert.ToDouble(spt1.ACTUAL_SUPPLY10);

                //    if (spt1.TRITRATE10 != null && Save10 == "Save 10")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 9, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[9] = "";
                //        result.strRep[9] = "";
                //    }

                //}

                ////Calculator 11
                //else if (cal11 == "Cal 11" || Save11 == "Save 11")
                //{
                //    //double TempRepcal = Decimal.ToDouble(deRepCalCl);
                //    result.douTritrate[10] = Convert.ToDouble(spt1.TRITRATE11);
                //    //double TempCal11 = Convert.ToDouble(spt1.TRITRATE11 * 0.05);

                //    result.strWork[10] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE11 * 3.2 * 0.05), 2));

                //    result.strRep[10] = spt1.REP_CALC11;

                //    result.douActual[10] = Convert.ToDouble(spt1.ACTUAL_SUPPLY11);

                //    if (spt1.TRITRATE11 != null && Save11 == "Save 11")
                //    {

                //        GetMaxTransectionID();
                //        AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //        result.strWork[10] = "";
                //        result.strRep[10] = "";
                //    }

                //}


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

          

            return result;
        }

        //Save data Protek2
        // Old PT_MC_InputResult spt1, string cal1, string Save1, string cal2, string Save2, string cal3, string Save3, string cal4, string Save4, string cal5, string Save5, string cal6, string Save6, string cal7, string Save7, string cal8, string Save8, string cal9, string Save9, string cal10, string Save10, string cal11, string Save11, string cal12, string Save12
        //PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11
        public PT_MC_InputResult GetDataProtek2(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP03' order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                ////result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                //dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                //foreach (DataRow row in dt.Rows)

                //{
                //    dtCloned.ImportRow(row);
                //}

                ////Variable for Rep Cal 


                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT2[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT2[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT2[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT2[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT2[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT2[i] = dtRow["REMARK"].ToString();
                    result.intNoPT2[i] = i + 1;
                    i++;

                }

                decimal[] TempTritrate = new decimal[12];
                string[] TempWorking = new string[12];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }
                if (Tritrate12 != "")
                {
                    TempTritrate[11] = Convert.ToDecimal(Tritrate12);
                }
                else
                {
                    TempTritrate[11] = 0;
                }



                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }

                if (ResultCal12 != "")
                {
                    TempWorking[11] = ResultCal12;
                }
                else
                {
                    TempWorking[11] = "0";
                }

                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                //TempWorking[11] = ResultCal12;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT2.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.strRemarkPT2, TempTritrate, TempWorking);
                }
                // AddDataAnalysis();



                //strSql = "SELECT * FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP03' order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                //conn.Open();

                //OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                //DataTable dt = new DataTable();

                //ad.Fill(dt);
                //result = new PT_MC_InputResult();

                ////result.DATED = DateTime.Now;



                //DataTable dtCloned = dt.Clone();

                //dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                //foreach (DataRow row in dt.Rows)

                //{
                //    dtCloned.ImportRow(row);
                //}

                ////Variable for Rep Cal 


                //foreach (DataRow dtRow in dt.Rows)
                //{
                //    result.strPartNoPT2[i] = dtRow["PART_NO"].ToString();
                //    result.strMachineCodePT2[i] = dtRow["MACHINE_CODE"].ToString();
                //    result.strchemicalTankPT2[i] = dtRow["CHEMICAL_TANK"].ToString();
                //    result.stranalysisItemPT2[i] = dtRow["CHEMICAL_NAME"].ToString();
                //    result.strchemicalTank_idPT2[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                //    result.strRemarkPT2[i] = dtRow["REMARK"].ToString();
                //    result.intNoPT2[i] = i + 1;
                //    i++;


                //}

                //Calculator 1
                //if (cal1 == "Cal 1" || Save1 == "Save 1")
                //{
                //    // result.ACTUAL_SUPPLY = Convert.ToDouble(spt1.TRITRATE * 0.1 / 2);
                //    //double WorkCal;
                //    double TempCal = Convert.ToDouble(spt1.TRITRATE * 0.1 / 2);
                //    //result.WORKING = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE * 0.1 / 2),2));
                //    result.douTritratePT2[0] = Convert.ToDouble(spt1.TRITRATE);
                //    result.strWorkPT2[0] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE * 0.1 / 2), 2));

                //    double WorkCal = Convert.ToDouble(result.WORKING);

                //    if (TempCal >= 0.58)
                //    {
                //        //result.REP_CALC = "0";
                //        result.strRepPT2[0] = "0";
                //    }
                //    else if (TempCal > 0.5)
                //    {
                //        //result.REP_CALC = "20";
                //        result.strRepPT2[0] = "20";
                //    }
                //    else
                //    {
                //        //result.REP_CALC = "40";
                //        result.strRepPT2[0] = "40";
                //    }

                //    result.douActualPT2[0] = Convert.ToDouble(spt1.ACTUAL_SUPPLY);

                //    if (spt1.TRITRATE != null && Save1 == "Save 1")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 0, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[0] = "";
                //        result.strRepPT2[0] = "";


                //    }

                //}

                ////Calculator 2
                //else if (cal2 == "Cal 2" || Save2 == "Save 2")
                //{

                //    var deRepCalAc = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00002").Sum(p => p.Field<decimal>("REP_POINT"));

                //    double TempRepcal = Decimal.ToDouble(deRepCalAc);
                //    result.douTritratePT2[1] = Convert.ToDouble(spt1.TRITRATE2);
                //    double TempCal2 = Convert.ToDouble(spt1.TRITRATE2 * 0.556);

                //    result.strWorkPT2[1] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE2 * 0.556), 2));



                //    if (TempCal2 >= TempRepcal)
                //    {
                //        result.strRepPT2[1] = "0";
                //    }

                //    else
                //    {
                //        result.strRepPT2[1] = Convert.ToString(Math.Round(((TempRepcal - TempCal2) * 780 / (100)), 2));
                //    }

                //    result.douActualPT2[1] = Convert.ToDouble(spt1.ACTUAL_SUPPLY2);

                //    if (spt1.TRITRATE2 != null && Save2 == "Save 2")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 1, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[1] = "";
                //        result.strRepPT2[1] = "";
                //    }

                //}

                ////Calculator 3
                //else if (cal3 == "Cal 3" || Save3 == "Save 3")
                //{
                //    var deRepCalCu = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("REP_POINT"));
                //    double TempRepcal = Decimal.ToDouble(deRepCalCu);
                //    result.douTritratePT2[2] = Convert.ToDouble(spt1.TRITRATE3);
                //    double TempCal3 = Convert.ToDouble(spt1.TRITRATE3 * 12.5);

                //    result.strWorkPT2[2] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE3 * 12.5), 2));



                //    if (TempCal3 >= TempRepcal)
                //    {
                //        result.strRepPT2[2] = "0";
                //    }

                //    else
                //    {
                //        result.strRepPT2[2] = Convert.ToString(Math.Round(((TempRepcal - TempCal3) * 25000 * 0.33 / 1000), 2));
                //    }

                //    result.douActualPT2[2] = Convert.ToDouble(spt1.ACTUAL_SUPPLY3);

                //    if (spt1.TRITRATE3 != null && Save3 == "Save 3")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 2, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[2] = "";
                //        result.strRepPT2[2] = "";
                //    }

                //}

                ////Calculator 4
                //else if (cal4 == "Cal 4" || Save4 == "Save 4")
                //{
                //    var deRepCalH2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("REP_POINT"));
                //    double TempRepcal = Decimal.ToDouble(deRepCalH2);
                //    result.douTritratePT2[3] = Convert.ToDouble(spt1.TRITRATE4);
                //    double TempCal4 = Convert.ToDouble(spt1.TRITRATE4 * 24.5);

                //    result.strWorkPT2[3] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE4 * 24.5), 2));


                //    if (TempCal4 >= TempRepcal)
                //    {
                //        result.strRepPT2[3] = "0";
                //    }

                //    else
                //    {
                //        result.strRepPT2[3] = Convert.ToString(Math.Round(((TempRepcal - TempCal4) * 25000 / (30 * 1000)), 2));
                //    }

                //    result.douActualPT2[3] = Convert.ToDouble(spt1.ACTUAL_SUPPLY4);

                //    if (spt1.TRITRATE4 != null && Save4 == "Save 4")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 3, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[3] = "";
                //        result.strRepPT2[3] = "";
                //    }

                //}

                ////Calculator 5
                //else if (cal5 == "Cal 5" || Save5 == "Save 5")
                //{
                //    var deRepCalCl = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("REP_POINT"));
                //    double TempRepcal = Decimal.ToDouble(deRepCalCl);
                //    result.douTritratePT2[4] = Convert.ToDouble(spt1.TRITRATE5);
                //    double TempCal5 = Convert.ToDouble(spt1.TRITRATE5 * 140.86);

                //    result.strWorkPT2[4] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE5 * 140.86), 2));


                //    if (TempCal5 >= TempRepcal)
                //    {
                //        result.strRepPT2[4] = "0";
                //    }

                //    else
                //    {
                //        result.strRepPT2[4] = Convert.ToString(Math.Round(((TempRepcal - TempCal5) * 23000 * (0.00226 / 1000)), 2));
                //    }

                //    result.douActualPT2[4] = Convert.ToDouble(spt1.ACTUAL_SUPPLY5);

                //    if (spt1.TRITRATE5 != null && Save5 == "Save 5")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 4, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[4] = "";
                //        result.strRepPT2[4] = "";
                //    }

                //}

                ////Calculator 6
                //else if (cal6 == "Cal 6" || Save6 == "Save 6")
                //{
                //    var deRepPoint = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100277" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("REP_POINT"));
                //    //var deHS200TANK = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("HS200TANK"));
                //    var deVolumn = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100277" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("VOL"));

                //    double TempRepPoint = Decimal.ToDouble(deRepPoint);
                //    double TempVolumn = Decimal.ToDouble(deVolumn);
                //    //double TempHS200TANK = Decimal.ToDouble(deHS200TANK);

                //    result.douTritratePT2[5] = Convert.ToDouble(spt1.TRITRATE6);

                //    string TempCal5 = Convert.ToString(Math.Round((TempRepPoint - Convert.ToDouble(spt1.TRITRATE6)) * (TempVolumn / 1000), 2));

                //    result.strWorkPT2[5] = Convert.ToString(result.douTritratePT2[5]);

                //    result.strRepPT2[5] = TempCal5;


                //    result.douActualPT2[5] = Convert.ToDouble(spt1.ACTUAL_SUPPLY6);

                //    if (spt1.TRITRATE6 != null && Save6 == "Save 6")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 5, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[5] = "";
                //        result.strRepPT2[5] = "";
                //    }

                //}

                ////Calculator 7
                //else if (cal7 == "Cal 7" || Save7 == "Save 7")
                //{
                //    var deRepPoint = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100278" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("REP_POINT"));
                //    var deVolumn = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100278" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("VOL"));

                //    double TempRepPoint = Decimal.ToDouble(deRepPoint);
                //    double TempVolumn = Decimal.ToDouble(deVolumn);

                //    result.douTritratePT2[6] = Convert.ToDouble(spt1.TRITRATE7);

                //    string TempCal6 = Convert.ToString(Math.Round((TempRepPoint - Convert.ToDouble(spt1.TRITRATE7)) * (TempVolumn / 1000), 2));

                //    result.strWorkPT2[6] = Convert.ToString(result.douTritratePT2[6]);

                //    result.strRepPT2[6] = TempCal6;


                //    result.douActualPT2[6] = Convert.ToDouble(spt1.ACTUAL_SUPPLY7);

                //    if (spt1.TRITRATE7 != null && Save7 == "Save 7")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 6, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[6] = "";
                //        result.strRepPT2[6] = "";
                //    }

                //}

                ////Calculator 8
                //else if (cal8 == "Cal 8" || Save8 == "Save 8")
                //{
                //    var deRepPoint = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100279" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("REP_POINT"));
                //    var deVolumn = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100279" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005").Sum(p => p.Field<decimal>("VOL"));

                //    double TempRepPoint = Decimal.ToDouble(deRepPoint);
                //    double TempVolumn = Decimal.ToDouble(deVolumn);

                //    result.douTritratePT2[7] = Convert.ToDouble(spt1.TRITRATE8);

                //    string TempCal7 = Convert.ToString(Math.Round((TempRepPoint - Convert.ToDouble(spt1.TRITRATE8)) * (TempVolumn / 1000), 2));

                //    result.strWorkPT2[7] = Convert.ToString(result.douTritratePT2[7]);

                //    result.strRepPT2[7] = TempCal7;


                //    result.douActualPT2[7] = Convert.ToDouble(spt1.ACTUAL_SUPPLY8);

                //    if (spt1.TRITRATE8 != null && Save8 == "Save 8")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 7, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[7] = "";
                //        result.strRepPT2[7] = "";
                //    }

                //}

                ////Calculator 9
                //else if (cal9 == "Cal 9" || Save9 == "Save 9")
                //{

                //    result.douTritratePT2[8] = Convert.ToDouble(spt1.TRITRATE9);
                //    double TempCal9 = Convert.ToDouble(spt1.TRITRATE9 * 4.28);

                //    result.strWorkPT2[8] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE9 * 4.28), 2));

                //    result.strRepPT2[8] = Convert.ToString(Math.Round(((120 - TempCal9) * 900  / 1000), 2));

                //    result.douActualPT2[8] = Convert.ToDouble(spt1.ACTUAL_SUPPLY9);

                //    if (spt1.TRITRATE9 != null && Save9 == "Save 9")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 8, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[8] = "";
                //        result.strRepPT2[8] = "";
                //    }

                //}

                ////Calculator 10
                //else if (cal10 == "Cal 10" || Save10 == "Save 10")
                //{

                //    result.douTritratePT2[9] = Convert.ToDouble(spt1.TRITRATE10);

                //    result.strWorkPT2[9] = spt1.WORKING10;

                //    result.strRepPT2[9] = spt1.REP_CALC10;

                //    result.douActualPT2[9] = Convert.ToDouble(spt1.ACTUAL_SUPPLY10);

                //    if (spt1.TRITRATE10 != null && Save10 == "Save 10")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 9, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[9] = "";
                //        result.strRepPT2[9] = "";
                //    }


                //}

                ////Calculator 11
                //else if (cal11 == "Cal 11" || Save11 == "Save 11")
                //{

                //    result.douTritratePT2[10] = Convert.ToDouble(spt1.TRITRATE11);
                //    double TempCal10 = Convert.ToDouble(spt1.TRITRATE11 * 27.2);

                //    result.strWorkPT2[10] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE11 * 27.2), 2));

                //    result.strRepPT2[10] = Convert.ToString(Math.Round(((100 - TempCal10) * 900 / (1.84 * 1000)), 2));

                //    result.douActualPT2[10] = Convert.ToDouble(spt1.ACTUAL_SUPPLY11);

                //    if (spt1.TRITRATE11 != null && Save11 == "Save 11")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 10, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[10] = "";
                //        result.strRepPT2[10] = "";
                //    }

                //}

                ////Calculator 12
                //else if (cal12 == "Cal 12" || Save12 == "Save 12")
                //{

                //    result.douTritratePT2[11] = Convert.ToDouble(spt1.TRITRATE12);
                //    double TempCal11 = Convert.ToDouble(spt1.TRITRATE12 * 3.2 * 0.05);

                //    result.strWorkPT2[11] = Convert.ToString(Math.Round(Convert.ToDouble(spt1.TRITRATE12 * 3.2 * 0.05), 2));

                //    result.strRepPT2[11] = spt1.REP_CALC12;

                //    result.douActualPT2[11] = Convert.ToDouble(spt1.ACTUAL_SUPPLY12);

                //    if (spt1.TRITRATE12 != null && Save12 == "Save 12")
                //    {

                //        GetMaxTransectionID();
                //        //AddDataAnalysis(spt1, 11, result.strMachineCodePT2, result.strPartNoPT2, result.strchemicalTank_idPT2, result.douTritratePT2, result.strWorkPT2, result.strRepPT2, result.douActualPT2);
                //        result.strWorkPT2[11] = "";
                //        result.strRepPT2[11] = "";
                //    }

                //}

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



            return result;
        }


        public PT_MC_InputResult GetDataProtek3(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP04' order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();




                DataTable dtCloned = dt.Clone();



                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT3[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT3[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT3[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT3[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT3[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT3[i] = dtRow["REMARK"].ToString();
                    result.intNoPT3[i] = i + 1;
                    i++;

                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }
                //if (Tritrate12 != "")
                //{
                //    TempTritrate[11] = Convert.ToDecimal(Tritrate12);
                //}
                //else
                //{
                //    TempTritrate[11] = 0;
                //}

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }

    




                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                //TempWorking[11] = ResultCal12;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT3.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT3, result.strPartNoPT3, result.strchemicalTank_idPT3, result.strRemarkPT3, TempTritrate, TempWorking);
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



            return result;
        }


        public PT_MC_InputResult GetDataProtek4(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP05' order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                ////result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                //dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                //foreach (DataRow row in dt.Rows)

                //{
                //    dtCloned.ImportRow(row);
                //}

                ////Variable for Rep Cal 


                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT4[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT4[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT4[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT4[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT4[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT4[i] = dtRow["REMARK"].ToString();
                    result.intNoPT4[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }


                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }

                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT4.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT4, result.strPartNoPT4, result.strchemicalTank_idPT4, result.strRemarkPT4, TempTritrate, TempWorking);
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



            return result;
        }
        public PT_MC_InputResult GetDataProtek5(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP06' order by to_number(priority_item,99) asc ";
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                DataTable dtCloned = dt.Clone();
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT5[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT5[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT5[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT5[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT5[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT5[i] = dtRow["REMARK"].ToString();
                    result.intNoPT5[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }
                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT5.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT5, result.strPartNoPT5, result.strchemicalTank_idPT5, result.strRemarkPT5, TempTritrate, TempWorking);
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
            return result;
        }
        public PT_MC_InputResult GetDataProtek6(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP07' order by to_number(priority_item,99) asc ";
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                DataTable dtCloned = dt.Clone();
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT6[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT6[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT6[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT6[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT6[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT6[i] = dtRow["REMARK"].ToString();
                    result.intNoPT6[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }

                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT6.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT6, result.strPartNoPT6, result.strchemicalTank_idPT6, result.strRemarkPT6, TempTritrate, TempWorking);
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
            return result;
        }
        public PT_MC_InputResult GetDataProtek7(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP08' order by to_number(priority_item,99) asc ";
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                DataTable dtCloned = dt.Clone();
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT7[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT7[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT7[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT7[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT7[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT7[i] = dtRow["REMARK"].ToString();
                    result.intNoPT7[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }
                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT7.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT7, result.strPartNoPT7, result.strchemicalTank_idPT7, result.strRemarkPT7, TempTritrate, TempWorking);
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
            return result;
        }
        public PT_MC_InputResult GetDataProtek8(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP09' order by to_number(priority_item,99) asc ";
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                DataTable dtCloned = dt.Clone();
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT8[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT8[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT8[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT8[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT8[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT8[i] = dtRow["REMARK"].ToString();
                    result.intNoPT8[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }
                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT8.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT8, result.strPartNoPT8, result.strchemicalTank_idPT8, result.strRemarkPT8, TempTritrate, TempWorking);
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
            return result;
        }
        public PT_MC_InputResult GetDataProtek9A(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP10A' order by to_number(priority_item,99) asc ";
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                DataTable dtCloned = dt.Clone();
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT9A[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT9A[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT9A[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT9A[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT9A[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT9A[i] = dtRow["REMARK"].ToString();
                    result.intNoPT9A[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }
                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT9A.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT9A, result.strPartNoPT9A, result.strchemicalTank_idPT9A, result.strRemarkPT9A, TempTritrate, TempWorking);
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
            return result;
        }
        public PT_MC_InputResult GetDataProtek9B(PT_MC_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            try
            {
                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = 'PLMCP10B' order by to_number(priority_item,99) asc ";
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_InputResult();

                DataTable dtCloned = dt.Clone();
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoPT9B[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodePT9B[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankPT9B[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemPT9B[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idPT9B[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkPT9B[i] = dtRow["REMARK"].ToString();
                    result.intNoPT9B[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[11];
                string[] TempWorking = new string[11];

                if (Tritrate1 != "")
                {
                    TempTritrate[0] = Convert.ToDecimal(Tritrate1);
                }
                else
                {
                    TempTritrate[0] = 0;
                }
                if (Tritrate2 != "")
                {
                    TempTritrate[1] = Convert.ToDecimal(Tritrate2);
                }
                else
                {
                    TempTritrate[1] = 0;
                }
                if (Tritrate3 != "")
                {
                    TempTritrate[2] = Convert.ToDecimal(Tritrate3);
                }
                else
                {
                    TempTritrate[2] = 0;
                }
                if (Tritrate4 != "")
                {
                    TempTritrate[3] = Convert.ToDecimal(Tritrate4);
                }
                else
                {
                    TempTritrate[3] = 0;
                }

                if (Tritrate5 != "")
                {
                    TempTritrate[4] = Convert.ToDecimal(Tritrate5);
                }
                else
                {
                    TempTritrate[4] = 0;
                }

                if (Tritrate6 != "")
                {
                    TempTritrate[5] = Convert.ToDecimal(Tritrate6);
                }
                else
                {
                    TempTritrate[5] = 0;
                }

                if (Tritrate7 != "")
                {
                    TempTritrate[6] = Convert.ToDecimal(Tritrate7);
                }
                else
                {
                    TempTritrate[6] = 0;
                }
                if (Tritrate8 != "")
                {
                    TempTritrate[7] = Convert.ToDecimal(Tritrate8);
                }
                else
                {
                    TempTritrate[7] = 0;
                }

                if (Tritrate9 != "")
                {
                    TempTritrate[8] = Convert.ToDecimal(Tritrate9);
                }
                else
                {
                    TempTritrate[8] = 0;
                }

                if (Tritrate10 != "")
                {
                    TempTritrate[9] = Convert.ToDecimal(Tritrate10);
                }
                else
                {
                    TempTritrate[9] = 0;
                }

                if (Tritrate11 != "")
                {
                    TempTritrate[10] = Convert.ToDecimal(Tritrate11);
                }
                else
                {
                    TempTritrate[10] = 0;
                }

                //Varidate Working don't is null
                if (ResultCal != "")
                {
                    TempWorking[0] = ResultCal;
                }
                else
                {
                    TempWorking[0] = "0";
                }
                if (ResultCal2 != "")
                {
                    TempWorking[1] = ResultCal2;
                }
                else
                {
                    TempWorking[1] = "0";
                }
                if (ResultCal3 != "")
                {
                    TempWorking[2] = ResultCal3;
                }
                else
                {
                    TempWorking[2] = "0";
                }

                if (ResultCal4 != "")
                {
                    TempWorking[3] = ResultCal4;
                }
                else
                {
                    TempWorking[3] = "0";
                }

                if (ResultCal5 != "")
                {
                    TempWorking[4] = ResultCal5;
                }
                else
                {
                    TempWorking[4] = "0";
                }
                if (ResultCal6 != "")
                {
                    TempWorking[5] = ResultCal6;
                }
                else
                {
                    TempWorking[5] = "0";
                }
                if (ResultCal7 != "")
                {
                    TempWorking[6] = ResultCal7;
                }
                else
                {
                    TempWorking[6] = "0";
                }
                if (ResultCal8 != "")
                {
                    TempWorking[7] = ResultCal8;
                }
                else
                {
                    TempWorking[7] = "0";
                }
                if (ResultCal9 != "")
                {
                    TempWorking[8] = ResultCal9;
                }
                else
                {
                    TempWorking[8] = "0";
                }
                if (ResultCal10 != "")
                {
                    TempWorking[9] = ResultCal10;
                }
                else
                {
                    TempWorking[9] = "0";
                }
                if (ResultCal11 != "")
                {
                    TempWorking[10] = ResultCal11;
                }
                else
                {
                    TempWorking[10] = "0";
                }
                //TempWorking[0] = ResultCal;

                //TempWorking[1] = ResultCal2;

                //TempWorking[2] = ResultCal3;

                //TempWorking[3] = ResultCal4;

                //TempWorking[4] = ResultCal5;

                //TempWorking[5] = ResultCal6;

                //TempWorking[6] = ResultCal7;

                //TempWorking[7] = ResultCal8;

                //TempWorking[8] = ResultCal9;

                //TempWorking[9] = ResultCal10;

                //TempWorking[10] = ResultCal11;

                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)

                //จำนวนรอบของการ Insert มาจาก Structure ของแต่ละเครื่อง
                int t = Convert.ToInt32(result.intNoPT9B.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodePT9B, result.strPartNoPT9B, result.strchemicalTank_idPT9B, result.strRemarkPT9B, TempTritrate, TempWorking);
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
            return result;
        }

        //Insert Transection
        public int Insert_InputAnaly()
        {
            int result = 0;
            string strSQL = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;
            try
            {


                cmd = new OracleCommand(strSQL, conn);
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
            return result;
        }

        public PT_MC_InputResult GetGraphProtek1(PT_MC_InputResult objpt)
        {

            //int i = 0;
            PT_MC_InputResult result = null;
            
            string strSql = "";
            //string strSqlCopper = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {

                //strSqlAlche = "select  to_char(DATED, 'dd-mon-YY') as DATED ,working,timed from CMKT_PT_ANALYSIS_RESULT_TAB where part_no = '20100128'  and to_char(trunc(dated),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' order by dated,transaction_id asc";



                //strSql = @"select part_no,to_char(DATED, 'dd-mon-YY') as DATED ,working,timed from CMKT_PT_ANALYSIS_RESULT_TAB where  machine_code = 'PROTEK1' " +
                //           " and to_char(trunc(dated), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' order by dated,transaction_id asc ";


                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP02' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                // and pta.part_no = '20100128' " +

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                        " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                        " and cms.machine_code = 'PLMCP02' WHERE pta.machine_code = 'PLMCP02' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " + 
                        " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();


                //SizeArrayofMonth ss = new SizeArrayofMonth();
                int intCalday =  Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                ////For Alchelate
                //result.strDailyX = new string[intCalday * 2];
                //result.douH = new double[intCalday * 2];
                //result.douL = new double[intCalday * 2];
                //result.douM = new double[intCalday * 2];

                ////For Copper
                //result.strDailyX_Copper = new string[intCalday * 4];
                //result.douH_Copper = new double[intCalday * 4];
                //result.douL_Copper = new double[intCalday * 4];
                //result.douM_Copper = new double[intCalday * 4];

                ////For Sulfuric
                //result.strDailyX_Sulfuric = new string[intCalday * 4];
                //result.douH_Sulfuric = new double[intCalday * 4];
                //result.douL_Sulfuric = new double[intCalday * 4];
                //result.douM_Sulfuric = new double[intCalday * 4];

                ////For HS200 PART B 
                //result.strDailyX_HS200PARTB = new string[intCalday * 2];
                //result.douH_HS200PARTB = new double[intCalday * 2];
                //result.douL_HS200PARTB = new double[intCalday * 2];
                //result.douM_HS200PARTB = new double[intCalday * 2];





                //For HS200 PART A  


                //foreach (DataRow dtRowResult in dtResult.Rows)
                //{

                //var oo = from mm in dtResult.AsEnumerable()
                //             where mm.Field<string>("PART_NO") == "20100128"
                //             select mm.Field<string>("TIMED").ToCharArray();


                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);



                //dtCloned.Columns["DATED"].DataType = typeof(DateTime);
                foreach (DataRow row in dtResult.Rows)
                
                {
                   
                    dtCloned.ImportRow(row);

                }

                //Alchelate
                //result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


                //Copper
                //result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


                //Sulfuric
                //result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


                //Chloride
                //result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART A 01-15
                //result.strDailyX_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                result.strDailyX_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


                //HS200 PART B
                //result.strDailyX_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK") == "Copper Plating HS200").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                result.strDailyX_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //List<string> list = new List<string>();

                //for (int i = 0;i < dtResult.Rows.Count;i++)
                //{

                //}


                //result.strDailyX = Array.Copy(oo, p => p.ToString());

                ////result.strDailyX[i] = String.Format("{0:dd MMM YY}", dtRowResult["DATED"].ToString("dd MM YY")) + " " + dtRowResult["TIMED"].ToString();
                //result.strDailyX[i] = dtRowResult["DATED"].ToString() + " " + dtRowResult["TIMED"].ToString();
                //result.douH[i] = 0.8;
                //result.douM[i] = Convert.ToDouble(dtRowResult["WORKING"].ToString());
                //result.douL[i] = 0.4;

                //i++;

                //}




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
            return result;
        }



        public PT_MC_InputResult GetGraphProtek2(PT_MC_InputResult objpt)
        {

            //int i = 0;
            PT_MC_InputResult result = null;

            string strSql = "";
            //string strSqlCopper = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {

                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP03' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                     " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                     " and cms.machine_code = 'PLMCP03' WHERE pta.machine_code = 'PLMCP03' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                     " ORDER BY pta.dated_applied,pta.transaction_id ASC ";



                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();


                //SizeArrayofMonth ss = new SizeArrayofMonth();
                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);


                //dtCloned.Columns["DATED"].DataType = typeof(DateTime);
                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Alchelate
                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //EVF Brightener  (0.600-0.800-1.000  ml/L)
                result.strDailyX_EVFBRIGH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100277" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_EVFBRIGH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100277" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_EVFBRIGH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100277" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_EVFBRIGH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100277" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //EVF Leveller  (4.0-8.0-12.0  ml/L)
                result.strDailyX_LEVELLER = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100278" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_LEVELLER = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100278" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_LEVELLER = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100278" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_LEVELLER = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100278" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //EVF C-2  (15-20-25  ml/L)
                result.strDailyX_EVF_C2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100279" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_EVF_C2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100279" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_EVF_C2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100279" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_EVF_C2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100279" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00005" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();




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
            return result;
        }



        //Graph Protek 3 Date : 18-Dec-2019
        public PT_MC_InputResult GetGraphProtex3(PT_MC_InputResult objpt)
        {


            //int i = 0;
            PT_MC_InputResult result = null;

            string strSql = "";
            //string strSqlCopper = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {



                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP04' and to_char(trunc(pta.dated), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                  " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                  " and cms.machine_code = 'PLMCP04' WHERE pta.machine_code = 'PLMCP04' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                  " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();


                //SizeArrayofMonth ss = new SizeArrayofMonth();
                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));





                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);



                //dtCloned.Columns["DATED"].DataType = typeof(DateTime);
                foreach (DataRow row in dtResult.Rows)

                {
                    dtCloned.ImportRow(row);
                }


                //Alchelate
                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART A 01-15
                result.strDailyX_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART B
                result.strDailyX_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();



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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek4(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP05' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";


                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP05' WHERE pta.machine_code = 'PLMCP05' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {
                
                    dtCloned.ImportRow(row);
                
                }

                //Alchelate
                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901AM
                result.strDailyX_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901BM
                result.strDailyX_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek5(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP06' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP06' WHERE pta.machine_code = 'PLMCP06' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Alchelate
                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST901-A
                result.strDailyX_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST901-B
                result.strDailyX_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek6(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP07' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP07' WHERE pta.machine_code = 'PLMCP07' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Alchelate
                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART A 01-15
                result.strDailyX_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART B
                result.strDailyX_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek7(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP08' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP08' WHERE pta.machine_code = 'PLMCP08' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Alchelate
                result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00001" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART A 01-15
                result.strDailyX_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTA1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100266" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //HS200 PART B
                result.strDailyX_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_HS200PARTB = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100265" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00003" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek8(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP09' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP09' WHERE pta.machine_code = 'PLMCP09' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Melplate
                result.strDailyX_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901AM
                result.strDailyX_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901BM
                result.strDailyX_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek9A(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP10A' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP10A' WHERE pta.machine_code = 'PLMCP10A' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Melplate
                result.strDailyX_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Melplate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100396" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00007" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006"  && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901 AM
                result.strDailyX_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901 BM
                result.strDailyX_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }
        public PT_MC_InputResult GetGraphProtek9B(PT_MC_InputResult objpt)
        {
            PT_MC_InputResult result = null;
            string strSql = "";
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
                //strSql = @"select pta.part_no,ptmc.chemical_tank,to_char(pta.DATED_APPLIED, 'dd-mon-YY') || ' ' || pta.timed  as DATED ,pta.working,pta.timed ,ptmc.act_high,ptmc.act_low " +
                //        " from CMKT_PT_ANALYSIS_RESULT_TAB pta " +
                //        " left join cmkt_pt_mc_chemical_structure ptmc on ptmc.part_no = pta.part_no " +
                //        " where pta.machine_code = 'PLMCP10B' and to_char(trunc(pta.DATED_APPLIED), 'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                //        " order by pta.DATED_APPLIED,pta.transaction_id asc ";

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                " and cms.machine_code = 'PLMCP10B' WHERE pta.machine_code = 'PLMCP10B' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                " ORDER BY pta.dated_applied,pta.transaction_id ASC ";

                cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_InputResult();

                int intCalday = Convert.ToInt32(ConvertDate.GetNumberOfMonth(objpt.START_DATED));

                DataTable dtCloned = dtResult.Clone();
                dtCloned.Columns["WORKING"].DataType = typeof(Double);
                dtCloned.Columns["ACT_HIGH"].DataType = typeof(Double);
                dtCloned.Columns["ACT_LOW"].DataType = typeof(Double);

                foreach (DataRow row in dtResult.Rows)

                {

                    dtCloned.ImportRow(row);

                }

                //Alchelate
                //result.strDailyX = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<string>("DATED")).ToArray();
                //result.douH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                //result.douM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<double>("WORKING")).ToArray();
                //result.douL = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100128").Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Copper
                result.strDailyX_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "6010000002" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Sulfuric
                result.strDailyX_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Sulfuric = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //Chloride
                result.strDailyX_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Chloride = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100233" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901 AM
                result.strDailyX_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901AM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100152" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "18:00" || p.Field<string>("TIMED") == "22:00" || p.Field<string>("TIMED") == "02:00" || p.Field<string>("TIMED") == "06:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //ST-901 BM
                result.strDailyX_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_ST_901BM = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100154" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00006" && (p.Field<string>("TIMED") == "10:00" || p.Field<string>("TIMED") == "22:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

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
            return result;
        }


    }



    
}

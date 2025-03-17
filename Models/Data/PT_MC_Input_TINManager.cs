﻿using System;
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
    public class PT_MC_Input_TINManager : BaseManager
    {
        int MaxTranId;

        //,string[] strRep, double[] douActual
        public int AddDataAnalysis(PT_MC_TIN_InputResult objpt1, int intNo, string[] strMachineCode, string[] strPart, string[] strCheme_id, string[] strRemark, decimal[] deTritrate, string[] strWork,decimal[] deSTD)
        {
            string strpriority = Convert.ToString(intNo + 1);
            int result = 0;
            string strSQL = @"";

            strSQL += " INSERT INTO CMKT_PT_ANALYSIS_RESULT_TAB(TRANSACTION_ID, MACHINE_CODE, PART_NO,CHEMICAL_TANK_ID, CHECK_POINT, DATED, DATED_APPLIED, EMPLOYEE_CODE, TRITRATE, RES,SHIFT,WORKING,TIMED,PRIORITY_ITEM,REMARK) ";
            strSQL += " values('" + MaxTranId + "','" + strMachineCode[intNo] + "','" + strPart[intNo] + "','" + strCheme_id[intNo] + "','" + objpt1.CHECK_POINT + "',sysdate,";
            strSQL += " " + ConvertDate.GetDBDate(objpt1.DATED) + ",'" + objpt1.EMPLOYEE_CODE + "','" + deTritrate[intNo] + "','" + deSTD[intNo] + "','" + objpt1.SHIFT + "','" + strWork[intNo] + "',";
            strSQL += " '" + objpt1.TIMED + "','" + strpriority + "','" + strRemark[intNo] + "')";

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


        public PT_MC_TIN_InputResult GetDataTIN( PT_MC_TIN_InputResult spt1,string MC_Code, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal1, string STD2, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string ResultCal6, string STD7, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string STD12, string Tritrate12, string ResultCal12, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16)
        {
            int i = 0;
            PT_MC_TIN_InputResult result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {

                //AddDataAnalysis();


                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code = '" + MC_Code + "' order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_TIN_InputResult();

                DataTable dtCloned = dt.Clone();

                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoTIN[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodeTIN[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankTIN[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemTIN[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idTIN[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkTIN[i] = dtRow["REMARK"].ToString();
                    result.intNoTIN[i] = i + 1;
                    i++;


                }

                decimal[] TempSTD = new decimal[16];
                //decimal[] TempRa_value = new decimal[20];
                //decimal[] TempRb_value = new decimal[20];
                decimal[] TempTritrate = new decimal[16];
                string[] TempWorking = new string[16];


                TempSTD[0] = 0;
                if (STD2 != "" )
                {
                    TempSTD[1] = Convert.ToDecimal(STD2);
                }
                else
                {
                    TempSTD[1] = 0;
                }
                TempSTD[2] = 0;
                TempSTD[3] = 0;
                TempSTD[4] = 0;
                TempSTD[5] = 0;
                if (STD7 != "")
                {
                    TempSTD[6] = Convert.ToDecimal(STD7);
                }
                else
                {
                    TempSTD[6] = 0;
                }
                TempSTD[7] = 0;
                TempSTD[8] = 0;
                TempSTD[9] = 0;
                TempSTD[10] = 0;
                if (STD12 != "")
                {
                    TempSTD[11] = Convert.ToDecimal(STD12);
                }
                else
                {
                    TempSTD[11] = 0;
                }
                TempSTD[12] = 0;
                TempSTD[13] = 0;
                TempSTD[14] = 0;
                TempSTD[15] = 0;

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////

              

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

                TempTritrate[5] = 0;

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
                if (Tritrate13 != "")
                {
                    TempTritrate[12] = Convert.ToDecimal(Tritrate13);
                }
                else
                {
                    TempTritrate[12] = 0;
                }
                if (Tritrate14 != "")
                {
                    TempTritrate[13] = Convert.ToDecimal(Tritrate14);
                }
                else
                {
                    TempTritrate[13] = 0;
                }
                if (Tritrate15 != "")
                {
                    TempTritrate[14] = Convert.ToDecimal(Tritrate15);
                }
                else
                {
                    TempTritrate[14] = 0;
                }
                if (Tritrate16 != "")
                {
                    TempTritrate[15] = Convert.ToDecimal(Tritrate16);
                }
                else
                {
                    TempTritrate[15] = 0;
                }
             
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (ResultCal1 != "")
                {
                    TempWorking[0] = ResultCal1;
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
                if (ResultCal13 != "")
                {
                    TempWorking[12] = ResultCal13;
                }
                else
                {
                    TempWorking[12] = "0";
                }
                if (ResultCal14 != "")
                {
                    TempWorking[13] = ResultCal14;
                }
                else
                {
                    TempWorking[13] = "0";
                }
                if (ResultCal15 != "")
                {
                    TempWorking[14] = ResultCal15;
                }
                else
                {
                    TempWorking[14] = "0";
                }
                if (ResultCal16 != "")
                {
                    TempWorking[15] = ResultCal16;
                }
                else
                {
                    TempWorking[15] = "0";
                }
             


                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)
                int t = Convert.ToInt32(result.intNoTIN.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodeTIN, result.strPartNoTIN, result.strchemicalTank_idTIN, result.strRemarkTIN, TempTritrate, TempWorking,TempSTD);
                }
                // AddDataAnalysis();


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


        public PT_MC_TIN_InputResult GetMainDataTIN(PT_MC_TIN_InputResult objcal, string MC_Code)
        {
            int i = 0;
            PT_MC_TIN_InputResult result = null;
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

                result = new PT_MC_TIN_InputResult();

                //result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                foreach (DataRow row in dt.Rows)

                {
                    dtCloned.ImportRow(row);
                }


                switch (MC_Code)
                {


      
                    //AU
                    case "PLSCRUBT01":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoTIN[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodeTIN[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankTIN[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemTIN[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idTIN[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkTIN[i] = dtRow["REMARK"].ToString();
                            result.intNoTIN[i] = i + 1;
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
        public List<PT_MC_TIN_InputResult> GetPT_MC_InputInfoTIN(string MC_Code)
        {
            string strSql = "";
            //public string GetMonthName(int month);
            string StrMonthNow = Convert.ToString(DateTime.Now.Month.ToString("d2"));
            //string StrMonthNow = Convert.ToString(DateTime.Now.Month);
            string StrYearNow = Convert.ToString(DateTime.Now.Year);
            string StrMonthYear = StrMonthNow + "/" + StrYearNow;

            //ConvertDate.GetMMYYYY
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_TIN_InputResult> list = new List<PT_MC_TIN_InputResult>();
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
                    PT_MC_TIN_InputResult item = new PT_MC_TIN_InputResult();

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

        public PT_MC_TIN_InputResult GetPT_MC_ChemicalInfos_ByDatailTIN(int? id)
        {

            //PT_MC_InputResult result = null;
            PT_MC_TIN_InputResult items = new PT_MC_TIN_InputResult();

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
                    items = new PT_MC_TIN_InputResult();

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
        public PT_MC_TIN_InputResult GetPT_MC_ChemicalInfos_ByHistoryTIN(PT_MC_TIN_InputResult objcal, int? id)
        {
            int i = 0;
            PT_MC_TIN_InputResult result = null;
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

                result = new PT_MC_TIN_InputResult();



                if (dt.Rows.Count != 0)
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

                    case "PLSCRUBT01":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankTIN[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoTIN[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodeTIN[i] = dtRow["MACHINE_CODE"].ToString();
                            result.stranalysisItemTIN[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idTIN[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritrateTIN[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkTIN[i] = dtRow["WORKING"].ToString();
                            result.douSTDTIN[i] = Convert.ToDouble(dtRow["RES"].ToString());
                            result.strRemarkTIN[i] = dtRow["REMARK"].ToString();
                            result.intNoTIN[i] = i + 1;
                            i++;

                        }
                        break;

                 
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

        //Test


        public int UpdateDataInputResult(int id, PT_MC_TIN_InputResult res)
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


        //Graph ฤสทำป Date : 20-Aug-2020
        public PT_MC_TIN_InputResult GetGraphTIN(PT_MC_TIN_InputResult objpt)
        {


            //int i = 0;
            PT_MC_TIN_InputResult result = null;

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
                  " and cms.machine_code = 'PLSCRUBT01' WHERE pta.machine_code = 'PLSCRUBT01' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                  " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_TIN_InputResult();

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


                //1.Cleaner_Proselect_H
                result.strDailyX_Cleaner_Proselect_H = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100401" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00026" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Cleaner_Proselect_H = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100401" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00026" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Cleaner_Proselect_H = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100401" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00026" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Cleaner_Proselect_H = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100401" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00026" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


                //2.MicroEtch_Hconc
                result.strDailyX_MicroEtch_Hconc = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100402" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_MicroEtch_Hconc = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100402" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_MicroEtch_Hconc = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100402" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_MicroEtch_Hconc = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100402" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //3.MicroEtch_H_Copper
                result.strDailyX_MicroEtch_H_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:0")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_MicroEtch_H_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_MicroEtch_H_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_MicroEtch_H_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00027" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //4.Stannatech_Tin_II
                result.strDailyX_Stannatech_Tin_II = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100405" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Stannatech_Tin_II = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100405" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Stannatech_Tin_II = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100405" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Stannatech_Tin_II = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100405" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //5.Stannatech_Tin_IV
                result.strDailyX_Stannatech_Tin_IV = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Stannatech_Tin_IV = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Stannatech_Tin_IV = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Stannatech_Tin_IV = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //6.Stannatech_Thiourea
                result.strDailyX_Stannatech_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Stannatech_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Stannatech_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Stannatech_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //7.Stannatech_TotalAcid
                result.strDailyX_Stannatech_TotalAcid = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Stannatech_TotalAcid = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Stannatech_TotalAcid = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Stannatech_TotalAcid = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //8.Stannatech_Copper
                result.strDailyX_Stannatech_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Stannatech_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Stannatech_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Stannatech_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //9.Stannatech_AdditiveC
                result.strDailyX_Stannatech_AdditiveC = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100407" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Stannatech_AdditiveC = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100407" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Stannatech_AdditiveC = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100407" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Stannatech_AdditiveC = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100407" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00028" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //10.Post_Immersion_Tin_Total
                result.strDailyX_Post_Immersion_Tin_Total = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Post_Immersion_Tin_Total = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Post_Immersion_Tin_Total = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Post_Immersion_Tin_Total = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100403" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //11.Post_Immersion_Tin_Thiourea
                result.strDailyX_Post_Immersion_Tin_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Post_Immersion_Tin_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Post_Immersion_Tin_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Post_Immersion_Tin_Thiourea = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100406" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //12.Post_Immersion_Tin_Copper
                result.strDailyX_Post_Immersion_Tin_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Post_Immersion_Tin_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Post_Immersion_Tin_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Post_Immersion_Tin_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00029" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //13.lonix_SF
                result.strDailyX_lonix_SF = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100409" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00030" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_lonix_SF = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100409" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00030" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_lonix_SF = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100409" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00030" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_lonix_SF = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100409" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00030" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //14.PostDip270
                result.strDailyX_PostDip270 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100410" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_PostDip270 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100410" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_PostDip270 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100410" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_PostDip270 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100410" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //15.MicroEtch_Etch_Rate
                result.strDailyX_MicroEtch_Etch_Rate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_MicroEtch_Etch_Rate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_MicroEtch_Etch_Rate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_MicroEtch_Etch_Rate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_TIN4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00031" && (p.Field<string>("TIMED") == "14:00" || p.Field<string>("TIMED") == "02:00")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

               

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
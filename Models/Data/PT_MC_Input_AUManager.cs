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
    public class PT_MC_Input_AUManager : BaseManager
    {
        int MaxTranId;

        //,string[] strRep, double[] douActual
        public int AddDataAnalysis(PT_MC_AU_InputResult objpt1, int intNo, string[] strMachineCode, string[] strPart, string[] strCheme_id, string[] strRemark, decimal[] deTritrate, string[] strWork,decimal[] deSTD,decimal [] deRa_value,decimal [] deRb_value)
        {
            string strpriority = Convert.ToString(intNo + 1);
            int result = 0;
            string strSQL = @"";

            strSQL += " INSERT INTO CMKT_PT_ANALYSIS_RESULT_TAB(TRANSACTION_ID, MACHINE_CODE, PART_NO,CHEMICAL_TANK_ID, CHECK_POINT, DATED, DATED_APPLIED, EMPLOYEE_CODE, TRITRATE, RES,SHIFT,WORKING,TIMED,PRIORITY_ITEM,REMARK,RA_VALUE,RB_VALUE) ";
            strSQL += " values('" + MaxTranId + "','" + strMachineCode[intNo] + "','" + strPart[intNo] + "','" + strCheme_id[intNo] + "','" + objpt1.CHECK_POINT + "',sysdate,";
            strSQL += " " + ConvertDate.GetDBDate(objpt1.DATED) + ",'" + objpt1.EMPLOYEE_CODE + "','" + deTritrate[intNo] + "','" + deSTD[intNo] + "','" + objpt1.SHIFT + "','" + strWork[intNo] + "',";
            strSQL += " '" + objpt1.TIMED + "','" + strpriority + "','" + strRemark[intNo] + "','" + deRa_value[intNo] + "','" + deRb_value[intNo] + "' )";

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


        public PT_MC_AU_InputResult GetDataAU( PT_MC_AU_InputResult spt1,string MC_Code, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal1, string Tritrate2, string ResultCal2, string STD3, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string STD7, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12, string STD13, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16, string STD17, string Tritrate17, string ResultCal17, string STD18, string Rb_value18, string Ra_value18, string ResultCal18,string ResultCal19, string STD20, string Tritrate20, string ResultCal20)
        {
            int i = 0;
            PT_MC_AU_InputResult result = null;
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
                result = new PT_MC_AU_InputResult();

                DataTable dtCloned = dt.Clone();

                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoAU[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodeAU[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankAU[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemAU[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idAU[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkAU[i] = dtRow["REMARK"].ToString();
                    result.intNoAU[i] = i + 1;
                    i++;


                }

                decimal[] TempSTD = new decimal[20];
                decimal[] TempRa_value = new decimal[20];
                decimal[] TempRb_value = new decimal[20];
                decimal[] TempTritrate = new decimal[20];
                string[] TempWorking = new string[20];


                TempSTD[0] = 0;
                TempSTD[1] = 0;
                if (STD3 != "" )
                {
                    TempSTD[2] = Convert.ToDecimal(STD3);
                }
                else
                {
                    TempSTD[2] = 0;
                }
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
                TempSTD[11] = 0;
                if (STD13 != "")
                {
                    TempSTD[12] = Convert.ToDecimal(STD13);
                }
                else
                {
                    TempSTD[12] = 0;
                }
                TempSTD[13] = 0;
                TempSTD[14] = 0;
                TempSTD[15] = 0;
                if (STD17 != "")
                {
                    TempSTD[16] = Convert.ToDecimal(STD17);
                }
                else
                {
                    TempSTD[16] = 0;
                }
                if (STD18 != "")
                {
                    TempSTD[17] = Convert.ToDecimal(STD18);
                }
                else
                {
                    TempSTD[17] = 0;
                }

                TempSTD[18] = 0;

                if (STD20 != "")
                {
                    TempSTD[19] = Convert.ToDecimal(STD20);
                }
                else
                {
                    TempSTD[19] = 0;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                TempRa_value[0] = 0;
                TempRa_value[1] = 0;
                TempRa_value[2] = 0;
                TempRa_value[3] = 0;
                TempRa_value[4] = 0;
                TempRa_value[5] = 0;
                TempRa_value[6] = 0;
                TempRa_value[7] = 0;
                TempRa_value[8] = 0;
                TempRa_value[9] = 0;
                TempRa_value[10] = 0;
                TempRa_value[11] = 0;
                TempRa_value[12] = 0;
                TempRa_value[13] = 0;
                TempRa_value[14] = 0;
                TempRa_value[15] = 0;
                TempRa_value[16] = 0;

                if (Ra_value18 != "")
                {
                    TempRa_value[17] = Convert.ToDecimal(Ra_value18);
                }
                else
                {
                    TempRa_value[17] = 0;
                }

                TempRa_value[18] = 0;
                TempRa_value[19] = 0;

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                TempRb_value[0] = 0;
                TempRb_value[1] = 0;
                TempRb_value[2] = 0;
                TempRb_value[3] = 0;
                TempRb_value[4] = 0;
                TempRb_value[5] = 0;
                TempRb_value[6] = 0;
                TempRb_value[7] = 0;
                TempRb_value[8] = 0;
                TempRb_value[9] = 0;
                TempRb_value[10] = 0;
                TempRb_value[11] = 0;
                TempRb_value[12] = 0;
                TempRb_value[13] = 0;
                TempRb_value[14] = 0;
                TempRb_value[15] = 0;
                TempRb_value[16] = 0;

                if (Rb_value18 != "")
                {
                    TempRb_value[17] = Convert.ToDecimal(Rb_value18);
                }
                else
                {
                    TempRb_value[17] = 0;
                }

                TempRb_value[18] = 0;
                TempRb_value[19] = 0;

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
                if (Tritrate17 != "")
                {
                    TempTritrate[16] = Convert.ToDecimal(Tritrate17);
                }
                else
                {
                    TempTritrate[16] = 0;
                }


                TempTritrate[17] = 0;
                TempTritrate[18] = 0;

                if (Tritrate20 != "")
                {
                    TempTritrate[19] = Convert.ToDecimal(Tritrate20);
                }
                else
                {
                    TempTritrate[19] = 0;
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
                if (ResultCal17 != "")
                {
                    TempWorking[16] = ResultCal17;
                }
                else
                {
                    TempWorking[16] = "0";
                }
                if (ResultCal18 != "")
                {
                    TempWorking[17] = ResultCal18;
                }
                else
                {
                    TempWorking[17] = "0";
                }
                if (ResultCal19 != "")
                {
                    TempWorking[18] = ResultCal19;
                }
                else
                {
                    TempWorking[18] = "0";
                }
                if (ResultCal20 != "")
                {
                    TempWorking[19] = ResultCal20;
                }
                else
                {
                    TempWorking[19] = "0";
                }


                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)
                int t = Convert.ToInt32(result.intNoAU.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodeAU, result.strPartNoAU, result.strchemicalTank_idAU, result.strRemarkAU, TempTritrate, TempWorking,TempSTD,TempRa_value,TempRb_value);
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


        public PT_MC_AU_InputResult GetMainDataAU(PT_MC_AU_InputResult objcal, string MC_Code)
        {
            int i = 0;
            PT_MC_AU_InputResult result = null;
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

                result = new PT_MC_AU_InputResult();

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
                    case "PLAU01":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoAU[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodeAU[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankAU[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemAU[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idAU[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkAU[i] = dtRow["REMARK"].ToString();
                            result.intNoAU[i] = i + 1;
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
        public List<PT_MC_AU_InputResult> GetPT_MC_InputInfoAU(string MC_Code)
        {
            string strSql = "";
            //public string GetMonthName(int month);
            string StrMonthNow = Convert.ToString(DateTime.Now.Month.ToString("d2"));
            //string StrMonthNow = Convert.ToString(DateTime.Now.Month);
            string StrYearNow = Convert.ToString(DateTime.Now.Year);
            string StrMonthYear = StrMonthNow + "/" + StrYearNow;

            //ConvertDate.GetMMYYYY
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_AU_InputResult> list = new List<PT_MC_AU_InputResult>();
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
                    PT_MC_AU_InputResult item = new PT_MC_AU_InputResult();

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

        public PT_MC_AU_InputResult GetPT_MC_ChemicalInfos_ByDatailAU(int? id)
        {

            //PT_MC_InputResult result = null;
            PT_MC_AU_InputResult items = new PT_MC_AU_InputResult();

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
                    items = new PT_MC_AU_InputResult();

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
        public PT_MC_AU_InputResult GetPT_MC_ChemicalInfos_ByHistoryAU(PT_MC_AU_InputResult objcal, int? id)
        {
            int i = 0;
            PT_MC_AU_InputResult result = null;
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

                result = new PT_MC_AU_InputResult();

                //result.DATED = DateTime.Now;



                //DataTable dtCloned = dt.Clone();

                //dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                //foreach (DataRow row in dt.Rows)

                //{
                //    dtCloned.ImportRow(row);
                //}

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

                    case "PLAU01":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankAU[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoAU[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodeAU[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemAU[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idAU[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritrateAU[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkAU[i] = dtRow["WORKING"].ToString();
                            result.douRa_valueAU[i] = Convert.ToDouble(dtRow["RA_VALUE"].ToString());
                            result.douRb_valueAU[i] = Convert.ToDouble(dtRow["RB_VALUE"].ToString());
                            result.douSTDAU[i] = Convert.ToDouble(dtRow["RES"].ToString());
                            result.strRemarkAU[i] = dtRow["REMARK"].ToString();
                            result.intNoAU[i] = i + 1;
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


        public int UpdateDataInputResult(int id, PT_MC_AU_InputResult res)
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
        public PT_MC_AU_InputResult GetGraphAU(PT_MC_AU_InputResult objpt)
        {


            //int i = 0;
            PT_MC_AU_InputResult result = null;

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
                  " and cms.machine_code = 'PLAU01' WHERE pta.machine_code = 'PLAU01' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                  " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_AU_InputResult();

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


                //1.Cleaner ACL-009(Clener conc.)
                result.strDailyX_Cleaner_ACL_009 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100125" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00011" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Cleaner_ACL_009 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100125" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00011" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Cleaner_ACL_009 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100125" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00011" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Cleaner_ACL_009 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100125" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00011" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


                //2.Aciddip1
                result.strDailyX_Aciddip1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00012" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Aciddip1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00012" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Aciddip1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00012" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Aciddip1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00012" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //3.Aciddip2
                result.strDailyX_Aciddip2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00015" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Aciddip2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00015" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Aciddip2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00015" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Aciddip2 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00015" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //4.Predip
                result.strDailyX_Predip = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00017" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Predip = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00017" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Predip = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00017" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Predip = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00017" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //5.SoftEtch_APS
                result.strDailyX_SoftEtch_APS = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100314" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_SoftEtch_APS = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100314" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_SoftEtch_APS = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100314" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_SoftEtch_APS = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100314" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //6.SoftEtch_H2SO4
                result.strDailyX_SoftEtch_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_SoftEtch_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_SoftEtch_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_SoftEtch_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_AU" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //7.SoftEtch_Copper
                result.strDailyX_SoftEtch_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_SoftEtch_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_SoftEtch_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_SoftEtch_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00022" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //8.KAT_450_Pd
                result.strDailyX_KAT_450_Pd = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100077" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_KAT_450_Pd = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100077" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_KAT_450_Pd = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100077" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_KAT_450_Pd = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100077" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //9.KAT_450_H2SO4
                result.strDailyX_KAT_450_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_KAT_450_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_KAT_450_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_KAT_450_H2SO4 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //10.KAT_450_Copper
                result.strDailyX_KAT_450_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_KAT_450_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_KAT_450_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_KAT_450_Copper = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU1" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00023" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //11.Electroless_Ni_pH
                result.strDailyX_Electroless_Ni_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Electroless_Ni_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Electroless_Ni_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Electroless_Ni_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //12.Electroless_Ni_Ni_Ion
                result.strDailyX_Electroless_Ni_Ni_Ion = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Electroless_Ni_Ni_Ion = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Electroless_Ni_Ni_Ion = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Electroless_Ni_Ni_Ion = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU3" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //13.Electroless_Ni_Shy
                result.strDailyX_Electroless_Ni_Shy = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "12:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Electroless_Ni_Shy = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "12:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Electroless_Ni_Shy = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "12:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Electroless_Ni_Shy = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU4" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00024" && (p.Field<string>("TIMED") == "12:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //14.Au_pH
                result.strDailyX_Au_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Au_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Au_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Au_pH = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_AU2" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //15.Au
                result.strDailyX_Au = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100105" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Au = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100105" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Au = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100105" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Au = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100105" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //16.CN
                result.strDailyX_CN = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100191" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_CN = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100191" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_CN = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100191" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_CN = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100191" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //17.Au_TSB_71_B
                result.strDailyX_Au_TSB_71_B = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100070" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Au_TSB_71_B = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100070" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Au_TSB_71_B = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100070" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Au_TSB_71_B = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100070" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "00:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //18.Au_TSB_71_M20
                result.strDailyX_Au_TSB_71_M20 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100071" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Au_TSB_71_M20 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100071" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Au_TSB_71_M20 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100071" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Au_TSB_71_M20 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100071" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //19.Electroless_Ni_Cu
                //20.Au_Ni
                //21.Etching_Rate

                //22.Au_TSB_71_R1
                result.strDailyX_Au_TSB_71_R1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100346" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Au_TSB_71_R1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100346" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Au_TSB_71_R1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100346" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Au_TSB_71_R1 = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100346" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //23.Au_A_Value
                result.strDailyX_Au_A_Value = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100069" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Au_A_Value = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100069" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Au_A_Value = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100069" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Au_A_Value = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100069" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00025" && (p.Field<string>("TIMED") == "08:30" || p.Field<string>("TIMED") == "12:30" || p.Field<string>("TIMED") == "16:30" || p.Field<string>("TIMED") == "20:30" || p.Field<string>("TIMED") == "00:30" || p.Field<string>("TIMED") == "04:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();


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
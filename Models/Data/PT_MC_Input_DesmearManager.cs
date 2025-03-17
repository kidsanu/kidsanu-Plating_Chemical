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
    public class PT_MC_Input_DesmearManager : BaseManager
    {
        int MaxTranId;

        //,string[] strRep, double[] douActual
        public int AddDataAnalysis(PT_MC_DESMEAR_InputResult objpt1, int intNo, string[] strMachineCode, string[] strPart, string[] strCheme_id, string[] strRemark, decimal[] deTritrate, string[] strWork)
        {
            string strpriority = Convert.ToString(intNo + 1);
            int result = 0;
            string strSQL = @"";


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


        public PT_MC_DESMEAR_InputResult GetDataDesmear1(string MC_Code, PT_MC_DESMEAR_InputResult spt1, string[] strchemicalTank, string[] stranalysisItem, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {
            int i = 0;
            PT_MC_DESMEAR_InputResult  result = null;
            string strSql = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            //OracleCommand cmd = null;

            try
            {

                //AddDataAnalysis();


                strSql = "SELECT PART_NO,MACHINE_CODE,CHEMICAL_TANK,CHEMICAL_NAME,CHEMICAL_TANK_ID,REMARK FROM cmkt_pt_mc_chemical_structure  where machine_code ='" + MC_Code + "'  order by to_number(priority_item,99) asc ";

                ////cmd = new OracleCommand(strSql, conn);
                conn.Open();

                OracleDataAdapter ad = new OracleDataAdapter(strSql, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                result = new PT_MC_DESMEAR_InputResult();

                ////result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                foreach (DataRow dtRow in dt.Rows)
                {
                    result.strPartNoDesmear[i] = dtRow["PART_NO"].ToString();
                    result.strMachineCodeDesmear[i] = dtRow["MACHINE_CODE"].ToString();
                    result.strchemicalTankDesmear[i] = dtRow["CHEMICAL_TANK"].ToString();
                    result.stranalysisItemDesmear[i] = dtRow["CHEMICAL_NAME"].ToString();
                    result.strchemicalTank_idDesmear[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                    result.strRemarkDesmear[i] = dtRow["REMARK"].ToString();
                    result.intNoDesmear[i] = i + 1;
                    i++;


                }

                decimal[] TempTritrate = new decimal[7];
                string[] TempWorking = new string[7];
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


                GetMaxTransectionID();

                //AddDataAnalysis(spt1, 10, result.strMachineCode, result.strPartNo, result.strchemicalTank_id, result.douTritrate, result.strWork, result.strRep, result.douActual);
                //foreach (int t in result.intNo)
                int t = Convert.ToInt32(result.intNoDesmear.Length.ToString());

                for (i = 0; i < t; i++)
                {
                    AddDataAnalysis(spt1, i, result.strMachineCodeDesmear, result.strPartNoDesmear, result.strchemicalTank_idDesmear, result.strRemarkDesmear, TempTritrate, TempWorking);
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


        public PT_MC_DESMEAR_InputResult GetMainDataDeamear1(PT_MC_DESMEAR_InputResult objcal, string MC_Code)
        {
            int i = 0;
            PT_MC_DESMEAR_InputResult result = null;
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

                result = new PT_MC_DESMEAR_InputResult();

                //result.DATED = DateTime.Now;



                DataTable dtCloned = dt.Clone();

                dtCloned.Columns["REP_POINT"].DataType = typeof(Decimal);

                foreach (DataRow row in dt.Rows)

                {
                    dtCloned.ImportRow(row);
                }


                //switch (MC_Code)
                //{

                //    //Pal
                //    case "PLEP03A" :
                //    case "PLEP03B" :
                //    case "PLMCP01C":
                //    case "PLMCP01D":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strPartNoDesmear[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodeDesmear[i] = dtRow["MACHINE_CODE"].ToString();
                            result.strchemicalTankDesmear[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemDesmear[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idDesmear[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.strRemarkDesmear[i] = dtRow["REMARK"].ToString();
                            result.intNoDesmear[i] = i + 1;
                            i++;

                        }
                     //   break;



               // }

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
        public List<PT_MC_DESMEAR_InputResult> GetPT_MC_InputInfoDesmear(string MC_Code)
        {
            string strSql = "";
            //public string GetMonthName(int month);
            string StrMonthNow = Convert.ToString(DateTime.Now.Month.ToString("d2"));
            //string StrMonthNow = Convert.ToString(DateTime.Now.Month);
            string StrYearNow = Convert.ToString(DateTime.Now.Year);
            string StrMonthYear = StrMonthNow + "/" + StrYearNow;

            //ConvertDate.GetMMYYYY
            //PT_MC_ChemicalInfo item = null;
            List<PT_MC_DESMEAR_InputResult> list = new List<PT_MC_DESMEAR_InputResult>();
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {
            

                strSql = @"select distinct(anr.transaction_id), anr.machine_code, anr.dated_applied, anr.shift, anr.timed, anr.employee_code, ps.name" +
                           " from CMKT_PT_ANALYSIS_RESULT_TAB anr " +
                            " left join person_info_tab ps on anr.employee_code = ps.person_id " +
                            " where anr.machine_code = '" + MC_Code + "' and  TO_CHAR(trunc(anr.dated), 'mm/yyyy') = '" + StrMonthYear + "' ORDER BY transaction_id desc ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PT_MC_DESMEAR_InputResult item = new PT_MC_DESMEAR_InputResult();

                    item.TRANSACTION_ID = Convert.ToInt32(reader["TRANSACTION_ID"]);
                    item.MACHINE_CODE = reader["MACHINE_CODE"].ToString();
                    //item.PART_NO = reader["PART_NO"].ToString();
                    //item.CHECK_POINT = reader["CHECK_POINT"].ToString();
                    item.DATED_APPLIED = Convert.ToDateTime(reader["DATED_APPLIED"]);
                    item.TIMED = reader["TIMED"].ToString();
                    item.EMPLOYEE_CODE = reader["EMPLOYEE_CODE"].ToString();
                    item.EMPLOYEE_NAME = reader["NAME"].ToString();



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

        public PT_MC_DESMEAR_InputResult GetPT_MC_ChemicalInfos_ByDatailDesmear(int? id)
        {

            //PT_MC_InputResult result = null;
            PT_MC_DESMEAR_InputResult items = new PT_MC_DESMEAR_InputResult();

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
                    items = new PT_MC_DESMEAR_InputResult();

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
        public PT_MC_DESMEAR_InputResult GetPT_MC_ChemicalInfos_ByHistoryDesmear(PT_MC_DESMEAR_InputResult objcal, int? id)
        {
            int i = 0;
            PT_MC_DESMEAR_InputResult result = null;
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

                result = new PT_MC_DESMEAR_InputResult();

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


                //switch (result.MACHINE_CODE)
                //{

                //    case "PLEP03A":

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            result.strchemicalTankDesmear[i] = dtRow["chemical_tank_name"].ToString();
                            result.strPartNoDesmear[i] = dtRow["PART_NO"].ToString();
                            result.strMachineCodeDesmear[i] = dtRow["MACHINE_CODE"].ToString();
                            //result.strchemicalTank[i] = dtRow["CHEMICAL_TANK"].ToString();
                            result.stranalysisItemDesmear[i] = dtRow["CHEMICAL_NAME"].ToString();
                            result.strchemicalTank_idDesmear[i] = dtRow["CHEMICAL_TANK_ID"].ToString();
                            result.douTritrateDesmear[i] = Convert.ToDouble(dtRow["TRITRATE"].ToString());
                            result.strWorkDesmear[i] = dtRow["WORKING"].ToString();
                            result.strRemarkDesmear[i] = dtRow["REMARK"].ToString();
                            result.intNoDesmear[i] = i + 1;
                            i++;

                        }
                 //       break;

                 
             //   }

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


        public int UpdateDataInputResult(int id, PT_MC_DESMEAR_InputResult res)
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


        //Graph Desmear Date : 19-Sep-2020
        public PT_MC_DESMEAR_InputResult GetGraphDesmear(string MC_code,PT_MC_DESMEAR_InputResult objpt)
        {
            //int i = 0;
            PT_MC_DESMEAR_InputResult result = null;

            string strSql = "";
            //string strSqlCopper = "";

            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = null;

            try
            {

                strSql = @"SELECT pta.part_no,pta.chemical_tank_id,TO_CHAR(pta.dated_applied,'dd-mon-YY') || ' ' || pta.timed AS dated,pta.working,pta.timed,cms.act_high,cms.act_low " +
                  " FROM cmkt_pt_analysis_result_tab pta left join cmkt_pt_mc_chemical_structure cms on cms.part_no = pta.part_no and cms.chemical_tank_id = pta.chemical_tank_id " +
                  " and cms.machine_code = '" + MC_code + "' WHERE pta.machine_code = '" + MC_code  + "' AND TO_CHAR(trunc(pta.dated_applied),'mm/yyyy') = '" + ConvertDate.GetMMYYYY(objpt.START_DATED) + "' " +
                  " ORDER BY pta.dated_applied,pta.transaction_id ASC ";


                cmd = new OracleCommand(strSql, conn);
                conn.Open();


                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adResult = new OracleDataAdapter(strSql, conn);
                DataTable dtResult = new DataTable();

                adResult.Fill(dtResult);
                result = new PT_MC_DESMEAR_InputResult();

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


                //1. Hole Prep 4125 Bath Strength
                result.strDailyX_4125Bath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100139" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_4125Bath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100139" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_4125Bath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100139" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_4125Bath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100139" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //2. Hole Prep 4125 Alkaline Nurmality
                result.strDailyX_4125Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100264" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_4125Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100264" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_4125Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100264" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_4125Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100264" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00008" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "18:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30" || p.Field<string>("TIMED") == "06:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //3. Permanganate
                result.strDailyX_Permanganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100145" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Permanganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100145" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Permanganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100145" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Permanganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100145" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //4. Manganate
                result.strDailyX_Manganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Manganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Manganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Manganate = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "BY_PRODUCT_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //5. Alkaline Normality
                result.strDailyX_Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100236" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100236" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100236" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Alkaline = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100236" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00009" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //6. Neutralizer
                result.strDailyX_Neutralizer = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100349" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Neutralizer = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100349" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Neutralizer = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100349" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Neutralizer = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100349" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                //7. Neutralizer Bath conc
                result.strDailyX_NeutralizerBath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_NeutralizerBath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_NeutralizerBath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_NeutralizerBath = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100307_DSM" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();

                

                result.strDailyX_Neutralizer2165M = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100400" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<string>("DATED")).ToArray();
                result.douH_Neutralizer2165M = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100400" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_HIGH")).ToArray();
                result.douM_Neutralizer2165M = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100400" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("WORKING")).ToArray();
                result.douL_Neutralizer2165M = dtCloned.AsEnumerable().Where(p => p.Field<string>("PART_NO") == "20100400" && p.Field<string>("CHEMICAL_TANK_ID") == "CMT00010" && (p.Field<string>("TIMED") == "10:30" || p.Field<string>("TIMED") == "15:30" || p.Field<string>("TIMED") == "22:30" || p.Field<string>("TIMED") == "03:30")).Select(p => p.Field<double>("ACT_LOW")).ToArray();



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
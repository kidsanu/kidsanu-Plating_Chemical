using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using WebApplication2.Models.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;

namespace WebApplication2.Controllers
{
    public class PT_MC_Chemical_AU_Controller : Controller
    {
        //AU
        public ActionResult SaveAU(PT_MC_AU_InputResult spt1)
        {
            PT_MC_Input_AUManager objChe = new PT_MC_Input_AUManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_AU_InputResult model = objChe.GetMainDataAU(spt1, "PLAU01");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveAU(string Cancel, PT_MC_AU_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal1, string Tritrate2, string ResultCal2,string STD3, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string STD7, string Tritrate7,string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12,string STD13, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16, string STD17,string Tritrate17, string ResultCal17, string STD18,string Rb_value18,string Ra_value18, string ResultCal18, string ResultCal19, string STD20, string Tritrate20, string ResultCal20)
        {

            PT_MC_Input_AUManager objChe = new PT_MC_Input_AUManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_AU_InputResult model = objChe.GetMainDataAU(spt1, "PLAU01");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_AUManager p = new PT_MC_Input_AUManager();
                PT_MC_AU_InputResult model = p.GetDataAU(spt1,"PLAU01", strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal1, Tritrate2, ResultCal2, STD3,Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, STD7,Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, Tritrate12, ResultCal12,STD13, Tritrate13, ResultCal13, Tritrate14, ResultCal14, Tritrate15, ResultCal15, Tritrate16, ResultCal16,STD17, Tritrate17, ResultCal17, STD18, Rb_value18,Ra_value18, ResultCal18,ResultCal19,STD20,Tritrate20,ResultCal20);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        public ActionResult ChemicalSupplyAU()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLAU01");
            return View(model);

        }

        public ActionResult InputAnalysisAU()
        {
            PT_MC_Input_AUManager p = new PT_MC_Input_AUManager();
            List<PT_MC_AU_InputResult> model = p.GetPT_MC_InputInfoAU("PLAU01");
            return View(model);
        }


        public ActionResult DetailInputAU(int? id, string Edit, string Delete, PT_MC_AU_InputResult res)
        {
            PT_MC_Input_AUManager p = new PT_MC_Input_AUManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_AU_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryAU(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_AU_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailAU(id);

                return View(model);
            }
            else if (Delete == "Delete")
            {
                p.DeleteDataInputResult(idedit);
                ModelState.Clear();
                return View();
            }
            else
                return View();

        }


        //Graph AU Date : 08-Oct-2020
        public ActionResult GraphAU(PT_MC_AU_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_AUManager objChe = new PT_MC_Input_AUManager();

            //if (spt1.PART_NO != null)
            //{
            //    objChe.SaveEleProtek1(spt1);
            //    return View();
            //}
            //else
            //{

            PT_MC_Input_AUManager p = new PT_MC_Input_AUManager();
            PT_MC_AU_InputResult model = p.GetGraphAU(spt1);

            //1.Cleaner ACL-009(Clener conc.)
            string jsonTimeDailyCleaner_ACL_009 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Cleaner_ACL_009);
            ViewBag.jsonTimeDailyCleaner_ACL_009 = jsonTimeDailyCleaner_ACL_009;

            string jsonHCleaner_ACL_009 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cleaner_ACL_009);
            ViewBag.jsonHCleaner_ACL_009 = jsonHCleaner_ACL_009;

            string jsonMCleaner_ACL_009 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cleaner_ACL_009);
            ViewBag.jsonMCleaner_ACL_009 = jsonMCleaner_ACL_009;

            string jsonLCleaner_ACL_009 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cleaner_ACL_009);
            ViewBag.jsonLCleaner_ACL_009 = jsonLCleaner_ACL_009;



            //2.Aciddip1

            string jsonTimeDailyAciddip1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Aciddip1);
            ViewBag.jsonTimeDailyAciddip1 = jsonTimeDailyAciddip1;

            string jsonHAciddip1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Aciddip1);
            ViewBag.jsonHAciddip1 = jsonHAciddip1;

            string jsonMAciddip1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Aciddip1);
            ViewBag.jsonMAciddip1 = jsonMAciddip1;

            string jsonLAciddip1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Aciddip1);
            ViewBag.jsonLAciddip1 = jsonLAciddip1;

            //3.Aciddip2
            string jsonTimeDailyAciddip2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Aciddip2);
            ViewBag.jsonTimeDailyAciddip2 = jsonTimeDailyAciddip2;

            string jsonHAciddip2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Aciddip2);
            ViewBag.jsonHAciddip2 = jsonHAciddip2;

            string jsonMAciddip2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Aciddip2);
            ViewBag.jsonMAciddip2 = jsonMAciddip2;

            string jsonLAciddip2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Aciddip2);
            ViewBag.jsonLAciddip2 = jsonLAciddip2;

            //4.Predip

            string jsonTimeDailyPredip = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Predip);
            ViewBag.jsonTimeDailyPredip = jsonTimeDailyPredip;

            string jsonHPredip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Predip);
            ViewBag.jsonHPredip = jsonHPredip;

            string jsonMPredip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Predip);
            ViewBag.jsonMPredip = jsonMPredip;

            string jsonLPredip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Predip);
            ViewBag.jsonLPredip = jsonLPredip;

            //5.SoftEtch_APS

            string jsonTimeDailySoftEtch_APS = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_SoftEtch_APS);
            ViewBag.jsonTimeDailySoftEtch_APS = jsonTimeDailySoftEtch_APS;

            string jsonHSoftEtch_APS = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_SoftEtch_APS);
            ViewBag.jsonHSoftEtch_APS = jsonHSoftEtch_APS;

            string jsonMSoftEtch_APS = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_SoftEtch_APS);
            ViewBag.jsonMSoftEtch_APS = jsonMSoftEtch_APS;

            string jsonLSoftEtch_APS = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_SoftEtch_APS);
            ViewBag.jsonLSoftEtch_APS = jsonLSoftEtch_APS;

            //6.SoftEtch_H2SO4

            string jsonTimeDailySoftEtch_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_SoftEtch_H2SO4);
            ViewBag.jsonTimeDailySoftEtch_H2SO4 = jsonTimeDailySoftEtch_H2SO4;

            string jsonHSoftEtch_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_SoftEtch_H2SO4);
            ViewBag.jsonHSoftEtch_H2SO4 = jsonHSoftEtch_H2SO4;

            string jsonMSoftEtch_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_SoftEtch_H2SO4);
            ViewBag.jsonMSoftEtch_H2SO4 = jsonMSoftEtch_H2SO4;

            string jsonLSoftEtch_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_SoftEtch_H2SO4);
            ViewBag.jsonLSoftEtch_H2SO4 = jsonLSoftEtch_H2SO4;

            //7.SoftEtch_Copper

            string jsonTimeDailySoftEtch_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_SoftEtch_Copper);
            ViewBag.jsonTimeDailySoftEtch_Copper = jsonTimeDailySoftEtch_Copper;

            string jsonHSoftEtch_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_SoftEtch_Copper);
            ViewBag.jsonHSoftEtch_Copper = jsonHSoftEtch_Copper;

            string jsonMSoftEtch_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_SoftEtch_Copper);
            ViewBag.jsonMSoftEtch_Copper = jsonMSoftEtch_Copper;

            string jsonLSoftEtch_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_SoftEtch_Copper);
            ViewBag.jsonLSoftEtch_Copper = jsonLSoftEtch_Copper;

            //8.KAT_450_Pd

            string jsonTimeDailyKAT_450_Pd = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_KAT_450_Pd);
            ViewBag.jsonTimeDailyKAT_450_Pd = jsonTimeDailyKAT_450_Pd;

            string jsonHKAT_450_Pd = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_KAT_450_Pd);
            ViewBag.jsonHKAT_450_Pd = jsonHKAT_450_Pd;

            string jsonMKAT_450_Pd = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_KAT_450_Pd);
            ViewBag.jsonMKAT_450_Pd = jsonMKAT_450_Pd;

            string jsonLKAT_450_Pd = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_KAT_450_Pd);
            ViewBag.jsonLKAT_450_Pd = jsonLKAT_450_Pd;

            //9.KAT_450_H2SO4

            string jsonTimeDailyKAT_450_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_KAT_450_H2SO4);
            ViewBag.jsonTimeDailyKAT_450_H2SO4 = jsonTimeDailyKAT_450_H2SO4;

            string jsonHKAT_450_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_KAT_450_H2SO4);
            ViewBag.jsonHKAT_450_H2SO4 = jsonHKAT_450_H2SO4;

            string jsonMKAT_450_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_KAT_450_H2SO4);
            ViewBag.jsonMKAT_450_H2SO4 = jsonMKAT_450_H2SO4;

            string jsonLKAT_450_H2SO4 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_KAT_450_H2SO4);
            ViewBag.jsonLKAT_450_H2SO4 = jsonLKAT_450_H2SO4;

            //10.KAT_450_Copper

            string jsonTimeDailyKAT_450_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_KAT_450_Copper);
            ViewBag.jsonTimeDailyKAT_450_Copper = jsonTimeDailyKAT_450_Copper;

            string jsonHKAT_450_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_KAT_450_Copper);
            ViewBag.jsonHKAT_450_Copper = jsonHKAT_450_Copper;

            string jsonMKAT_450_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_KAT_450_Copper);
            ViewBag.jsonMKAT_450_Copper = jsonMKAT_450_Copper;

            string jsonLKAT_450_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_KAT_450_Copper);
            ViewBag.jsonLKAT_450_Copper = jsonLKAT_450_Copper;

            //11.Electroless_Ni_pH
            string jsonTimeDailyElectroless_Ni_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Electroless_Ni_pH);
            ViewBag.jsonTimeDailyElectroless_Ni_pH = jsonTimeDailyElectroless_Ni_pH;

            string jsonHElectroless_Ni_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Electroless_Ni_pH);
            ViewBag.jsonHElectroless_Ni_pH = jsonHElectroless_Ni_pH;

            string jsonMElectroless_Ni_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Electroless_Ni_pH);
            ViewBag.jsonMElectroless_Ni_pH = jsonMElectroless_Ni_pH;

            string jsonLElectroless_Ni_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Electroless_Ni_pH);
            ViewBag.jsonLElectroless_Ni_pH = jsonLElectroless_Ni_pH;

            //12.Electroless_Ni_Ni_Ion
            string jsonTimeDailyElectroless_Ni_Ni_Ion = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Electroless_Ni_Ni_Ion);
            ViewBag.jsonTimeDailyElectroless_Ni_Ni_Ion = jsonTimeDailyElectroless_Ni_Ni_Ion;

            string jsonHElectroless_Ni_Ni_Ion = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Electroless_Ni_Ni_Ion);
            ViewBag.jsonHElectroless_Ni_Ni_Ion = jsonHElectroless_Ni_Ni_Ion;

            string jsonMElectroless_Ni_Ni_Ion = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Electroless_Ni_Ni_Ion);
            ViewBag.jsonMElectroless_Ni_Ni_Ion = jsonMElectroless_Ni_Ni_Ion;

            string jsonLElectroless_Ni_Ni_Ion = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Electroless_Ni_Ni_Ion);
            ViewBag.jsonLElectroless_Ni_Ni_Ion = jsonLElectroless_Ni_Ni_Ion;

            //13.Electroless_Ni_Shy
            string jsonTimeDailyElectroless_Ni_Shy = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Electroless_Ni_Shy);
            ViewBag.jsonTimeDailyElectroless_Ni_Shy = jsonTimeDailyElectroless_Ni_Shy;

            string jsonHElectroless_Ni_Shy = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Electroless_Ni_Shy);
            ViewBag.jsonHElectroless_Ni_Shy = jsonHElectroless_Ni_Shy;

            string jsonMElectroless_Ni_Shy = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Electroless_Ni_Shy);
            ViewBag.jsonMElectroless_Ni_Shy = jsonMElectroless_Ni_Shy;

            string jsonLElectroless_Ni_Shy = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Electroless_Ni_Shy);
            ViewBag.jsonLElectroless_Ni_Shy = jsonLElectroless_Ni_Shy;

            //14.Au_pH
            string jsonTimeDailyAu_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Au_pH);
            ViewBag.jsonTimeDailyAu_pH = jsonTimeDailyAu_pH;

            string jsonHAu_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Au_pH);
            ViewBag.jsonHAu_pH = jsonHAu_pH;

            string jsonMAu_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Au_pH);
            ViewBag.jsonMAu_pH = jsonMAu_pH;

            string jsonLAu_pH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Au_pH);
            ViewBag.jsonLAu_pH = jsonLAu_pH;

            //15.Au
            string jsonTimeDailyAu = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Au);
            ViewBag.jsonTimeDailyAu = jsonTimeDailyAu;

            string jsonHAu = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Au);
            ViewBag.jsonHAu = jsonHAu;

            string jsonMAu = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Au);
            ViewBag.jsonMAu = jsonMAu;

            string jsonLAu = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Au);
            ViewBag.jsonLAu = jsonLAu;

            //16.CN
            string jsonTimeDailyCN = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CN);
            ViewBag.jsonTimeDailyCN = jsonTimeDailyCN;

            string jsonHCN = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CN);
            ViewBag.jsonHCN = jsonHCN;

            string jsonMCN = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CN);
            ViewBag.jsonMCN = jsonMCN;

            string jsonLCN = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CN);
            ViewBag.jsonLCN = jsonLCN;

            //17.Au_TSB_71_B
            string jsonTimeDailyAu_TSB_71_B = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Au_TSB_71_B);
            ViewBag.jsonTimeDailyAu_TSB_71_B = jsonTimeDailyAu_TSB_71_B;

            string jsonHAu_TSB_71_B = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Au_TSB_71_B);
            ViewBag.jsonHAu_TSB_71_B = jsonHAu_TSB_71_B;

            string jsonMAu_TSB_71_B = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Au_TSB_71_B);
            ViewBag.jsonMAu_TSB_71_B = jsonMAu_TSB_71_B;

            string jsonLAu_TSB_71_B = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Au_TSB_71_B);
            ViewBag.jsonLAu_TSB_71_B = jsonLAu_TSB_71_B;

            //18.Au_TSB_71_M20
            string jsonTimeDailyAu_TSB_71_M20 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Au_TSB_71_M20);
            ViewBag.jsonTimeDailyAu_TSB_71_M20 = jsonTimeDailyAu_TSB_71_M20;

            string jsonHAu_TSB_71_M20 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Au_TSB_71_M20);
            ViewBag.jsonHAu_TSB_71_M20 = jsonHAu_TSB_71_M20;

            string jsonMAu_TSB_71_M20 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Au_TSB_71_M20);
            ViewBag.jsonMAu_TSB_71_M20 = jsonMAu_TSB_71_M20;

            string jsonLAu_TSB_71_M20 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Au_TSB_71_M20);
            ViewBag.jsonLAu_TSB_71_M20 = jsonLAu_TSB_71_M20;

            //19.Electroless_Ni_Cu
            //20.Au_Ni
            //21.Etching_Rate



            //22.Au_TSB_71_R1
            string jsonTimeDailyAu_TSB_71_R1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Au_TSB_71_R1);
            ViewBag.jsonTimeDailyAu_TSB_71_R1 = jsonTimeDailyAu_TSB_71_R1;

            string jsonHAu_TSB_71_R1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Au_TSB_71_R1);
            ViewBag.jsonHAu_TSB_71_R1 = jsonHAu_TSB_71_R1;

            string jsonMAu_TSB_71_R1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Au_TSB_71_R1);
            ViewBag.jsonMAu_TSB_71_R1 = jsonMAu_TSB_71_R1;

            string jsonLAu_TSB_71_R1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Au_TSB_71_R1);
            ViewBag.jsonLAu_TSB_71_R1 = jsonLAu_TSB_71_R1;

            //23.Au_A_Value
            string jsonTimeDailyAu_A_Value = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Au_A_Value);
            ViewBag.jsonTimeDailyAu_A_Value = jsonTimeDailyAu_A_Value;

            string jsonHAu_A_Value = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Au_A_Value);
            ViewBag.jsonHAu_A_Value = jsonHAu_A_Value;

            string jsonMAu_A_Value = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Au_A_Value);
            ViewBag.jsonMAu_A_Value = jsonMAu_A_Value;

            string jsonLAu_A_Value = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Au_A_Value);
            ViewBag.jsonLAu_A_Value = jsonLAu_A_Value;


            return View(model);



        }




    }
}
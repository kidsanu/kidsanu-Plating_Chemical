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
    public class PT_MC_Chemical_TIN_Controller : Controller
    {
        //AU
        public ActionResult SaveTIN(PT_MC_TIN_InputResult spt1)
        {
            PT_MC_Input_TINManager objChe = new PT_MC_Input_TINManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_TIN_InputResult model = objChe.GetMainDataTIN(spt1, "PLSCRUBT01");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveTIN(string Cancel, PT_MC_TIN_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal1, string STD2, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string ResultCal6, string STD7, string Tritrate7,string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string STD12, string Tritrate12, string ResultCal12, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16)
        {

            PT_MC_Input_TINManager objChe = new PT_MC_Input_TINManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_TIN_InputResult model = objChe.GetMainDataTIN(spt1, "PLSCRUBT01");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_TINManager p = new PT_MC_Input_TINManager();
                PT_MC_TIN_InputResult model = p.GetDataTIN(spt1, "PLSCRUBT01", strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal1, STD2, Tritrate2, ResultCal2,Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, ResultCal6, STD7,Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, STD12,Tritrate12, ResultCal12, Tritrate13, ResultCal13, Tritrate14, ResultCal14, Tritrate15, ResultCal15, Tritrate16, ResultCal16);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        public ActionResult ChemicalSupplyTIN()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLSCRUBT01");
            return View(model);

        }

        public ActionResult InputAnalysisTIN()
        {
            PT_MC_Input_TINManager p = new PT_MC_Input_TINManager();
            List<PT_MC_TIN_InputResult> model = p.GetPT_MC_InputInfoTIN("PLSCRUBT01");
            return View(model);
        }


        public ActionResult DetailInputTIN(int? id, string Edit, string Delete, PT_MC_TIN_InputResult res)
        {
            PT_MC_Input_TINManager p = new PT_MC_Input_TINManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_TIN_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryTIN(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_TIN_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailTIN(id);

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


        //Graph TIN Date : 24-Oct-2020
        public ActionResult GraphTIN(PT_MC_TIN_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_TINManager objChe = new PT_MC_Input_TINManager();
            PT_MC_Input_TINManager p = new PT_MC_Input_TINManager();
            PT_MC_TIN_InputResult model = p.GetGraphTIN(spt1);

            //1.Cleaner_Proselect_H
            string jsonTimeDailyCleaner_Proselect_H = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Cleaner_Proselect_H);
            ViewBag.jsonTimeDailyCleaner_Proselect_H = jsonTimeDailyCleaner_Proselect_H;

            string jsonHCleaner_Proselect_H = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cleaner_Proselect_H);
            ViewBag.jsonHCleaner_Proselect_H = jsonHCleaner_Proselect_H;

            string jsonMCleaner_Proselect_H = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cleaner_Proselect_H);
            ViewBag.jsonMCleaner_Proselect_H = jsonMCleaner_Proselect_H;

            string jsonLCleaner_Proselect_H = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cleaner_Proselect_H);
            ViewBag.jsonLCleaner_Proselect_H = jsonLCleaner_Proselect_H;



            //2.MicroEtch_Hconc

            string jsonTimeDailyMicroEtch_Hconc = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_MicroEtch_Hconc);
            ViewBag.jsonTimeDailyMicroEtch_Hconc = jsonTimeDailyMicroEtch_Hconc;

            string jsonHMicroEtch_Hconc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_MicroEtch_Hconc);
            ViewBag.jsonHMicroEtch_Hconc = jsonHMicroEtch_Hconc;

            string jsonMMicroEtch_Hconc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_MicroEtch_Hconc);
            ViewBag.jsonMMicroEtch_Hconc = jsonMMicroEtch_Hconc;

            string jsonLMicroEtch_Hconc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_MicroEtch_Hconc);
            ViewBag.jsonLMicroEtch_Hconc = jsonLMicroEtch_Hconc;

            //3.MicroEtch_H_Copper
            string jsonTimeDailyMicroEtch_H_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_MicroEtch_H_Copper);
            ViewBag.jsonTimeDailyMicroEtch_H_Copper = jsonTimeDailyMicroEtch_H_Copper;

            string jsonHMicroEtch_H_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_MicroEtch_H_Copper);
            ViewBag.jsonHMicroEtch_H_Copper = jsonHMicroEtch_H_Copper;

            string jsonMMicroEtch_H_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_MicroEtch_H_Copper);
            ViewBag.jsonMMicroEtch_H_Copper = jsonMMicroEtch_H_Copper;

            string jsonLMicroEtch_H_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_MicroEtch_H_Copper);
            ViewBag.jsonLMicroEtch_H_Copper = jsonLMicroEtch_H_Copper;

            //4.Stannatech_Tin_II

            string jsonTimeDailyStannatech_Tin_II = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Stannatech_Tin_II);
            ViewBag.jsonTimeDailyStannatech_Tin_II = jsonTimeDailyStannatech_Tin_II;

            string jsonHStannatech_Tin_II = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Stannatech_Tin_II);
            ViewBag.jsonHStannatech_Tin_II = jsonHStannatech_Tin_II;

            string jsonMStannatech_Tin_II = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Stannatech_Tin_II);
            ViewBag.jsonMStannatech_Tin_II = jsonMStannatech_Tin_II;

            string jsonLStannatech_Tin_II = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Stannatech_Tin_II);
            ViewBag.jsonLStannatech_Tin_II = jsonLStannatech_Tin_II;

            //5.Stannatech_Tin_IV

            string jsonTimeDailyStannatech_Tin_IV = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Stannatech_Tin_IV);
            ViewBag.jsonTimeDailyStannatech_Tin_IV = jsonTimeDailyStannatech_Tin_IV;

            string jsonHStannatech_Tin_IV = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Stannatech_Tin_IV);
            ViewBag.jsonHStannatech_Tin_IV = jsonHStannatech_Tin_IV;

            string jsonMStannatech_Tin_IV = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Stannatech_Tin_IV);
            ViewBag.jsonMStannatech_Tin_IV = jsonMStannatech_Tin_IV;

            string jsonLStannatech_Tin_IV = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Stannatech_Tin_IV);
            ViewBag.jsonLStannatech_Tin_IV = jsonLStannatech_Tin_IV;

            //6.Stannatech_Thiourea

            string jsonTimeDailyStannatech_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Stannatech_Thiourea);
            ViewBag.jsonTimeDailyStannatech_Thiourea = jsonTimeDailyStannatech_Thiourea;

            string jsonHStannatech_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Stannatech_Thiourea);
            ViewBag.jsonHStannatech_Thiourea = jsonHStannatech_Thiourea;

            string jsonMStannatech_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Stannatech_Thiourea);
            ViewBag.jsonMStannatech_Thiourea = jsonMStannatech_Thiourea;

            string jsonLStannatech_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Stannatech_Thiourea);
            ViewBag.jsonLStannatech_Thiourea = jsonLStannatech_Thiourea;

            //7.Stannatech_TotalAcid

            string jsonTimeDailyStannatech_TotalAcid = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Stannatech_TotalAcid);
            ViewBag.jsonTimeDailyStannatech_TotalAcid = jsonTimeDailyStannatech_TotalAcid;

            string jsonHStannatech_TotalAcid = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Stannatech_TotalAcid);
            ViewBag.jsonHStannatech_TotalAcid = jsonHStannatech_TotalAcid;

            string jsonMStannatech_TotalAcid = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Stannatech_TotalAcid);
            ViewBag.jsonMStannatech_TotalAcid = jsonMStannatech_TotalAcid;

            string jsonLStannatech_TotalAcid = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Stannatech_TotalAcid);
            ViewBag.jsonLStannatech_TotalAcid = jsonLStannatech_TotalAcid;

            //8.Stannatech_Copper

            string jsonTimeDailyStannatech_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Stannatech_Copper);
            ViewBag.jsonTimeDailyStannatech_Copper = jsonTimeDailyStannatech_Copper;

            string jsonHStannatech_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Stannatech_Copper);
            ViewBag.jsonHStannatech_Copper = jsonHStannatech_Copper;

            string jsonMStannatech_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Stannatech_Copper);
            ViewBag.jsonMStannatech_Copper = jsonMStannatech_Copper;

            string jsonLStannatech_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Stannatech_Copper);
            ViewBag.jsonLStannatech_Copper = jsonLStannatech_Copper;

            //9.Stannatech_AdditiveC

            string jsonTimeDailyStannatech_AdditiveC = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Stannatech_AdditiveC);
            ViewBag.jsonTimeDailyStannatech_AdditiveC = jsonTimeDailyStannatech_AdditiveC;

            string jsonHStannatech_AdditiveC = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Stannatech_AdditiveC);
            ViewBag.jsonHStannatech_AdditiveC = jsonHStannatech_AdditiveC;

            string jsonMStannatech_AdditiveC = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Stannatech_AdditiveC);
            ViewBag.jsonMStannatech_AdditiveC = jsonMStannatech_AdditiveC;

            string jsonLStannatech_AdditiveC = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Stannatech_AdditiveC);
            ViewBag.jsonLStannatech_AdditiveC = jsonLStannatech_AdditiveC;

            //10.Post_Immersion_Tin_Total

            string jsonTimeDailyPost_Immersion_Tin_Total = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Post_Immersion_Tin_Total);
            ViewBag.jsonTimeDailyPost_Immersion_Tin_Total = jsonTimeDailyPost_Immersion_Tin_Total;

            string jsonHPost_Immersion_Tin_Total = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Post_Immersion_Tin_Total);
            ViewBag.jsonHPost_Immersion_Tin_Total = jsonHPost_Immersion_Tin_Total;

            string jsonMPost_Immersion_Tin_Total = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Post_Immersion_Tin_Total);
            ViewBag.jsonMPost_Immersion_Tin_Total = jsonMPost_Immersion_Tin_Total;

            string jsonLPost_Immersion_Tin_Total = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Post_Immersion_Tin_Total);
            ViewBag.jsonLPost_Immersion_Tin_Total = jsonLPost_Immersion_Tin_Total;

            //11.Post_Immersion_Tin_Thiourea
            string jsonTimeDailyPost_Immersion_Tin_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Post_Immersion_Tin_Thiourea);
            ViewBag.jsonTimeDailyPost_Immersion_Tin_Thiourea = jsonTimeDailyPost_Immersion_Tin_Thiourea;

            string jsonHPost_Immersion_Tin_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Post_Immersion_Tin_Thiourea);
            ViewBag.jsonHPost_Immersion_Tin_Thiourea = jsonHPost_Immersion_Tin_Thiourea;

            string jsonMPost_Immersion_Tin_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Post_Immersion_Tin_Thiourea);
            ViewBag.jsonMPost_Immersion_Tin_Thiourea = jsonMPost_Immersion_Tin_Thiourea;

            string jsonLPost_Immersion_Tin_Thiourea = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Post_Immersion_Tin_Thiourea);
            ViewBag.jsonLPost_Immersion_Tin_Thiourea = jsonLPost_Immersion_Tin_Thiourea;

            //12.Post_Immersion_Tin_Copper
            string jsonTimeDailyPost_Immersion_Tin_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Post_Immersion_Tin_Copper);
            ViewBag.jsonTimeDailyPost_Immersion_Tin_Copper = jsonTimeDailyPost_Immersion_Tin_Copper;

            string jsonHPost_Immersion_Tin_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Post_Immersion_Tin_Copper);
            ViewBag.jsonHPost_Immersion_Tin_Copper = jsonHPost_Immersion_Tin_Copper;

            string jsonMPost_Immersion_Tin_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Post_Immersion_Tin_Copper);
            ViewBag.jsonMPost_Immersion_Tin_Copper = jsonMPost_Immersion_Tin_Copper;

            string jsonLPost_Immersion_Tin_Copper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Post_Immersion_Tin_Copper);
            ViewBag.jsonLPost_Immersion_Tin_Copper = jsonLPost_Immersion_Tin_Copper;

            //13.lonix_SF
            string jsonTimeDailylonix_SF = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_lonix_SF);
            ViewBag.jsonTimeDailylonix_SF = jsonTimeDailylonix_SF;

            string jsonHlonix_SF = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_lonix_SF);
            ViewBag.jsonHlonix_SF = jsonHlonix_SF;

            string jsonMlonix_SF = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_lonix_SF);
            ViewBag.jsonMlonix_SF = jsonMlonix_SF;

            string jsonLlonix_SF = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_lonix_SF);
            ViewBag.jsonLlonix_SF = jsonLlonix_SF;

            //14.PostDip270
            string jsonTimeDailyPostDip270 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_PostDip270);
            ViewBag.jsonTimeDailyPostDip270 = jsonTimeDailyPostDip270;

            string jsonHPostDip270 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_PostDip270);
            ViewBag.jsonHPostDip270 = jsonHPostDip270;

            string jsonMPostDip270 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_PostDip270);
            ViewBag.jsonMPostDip270 = jsonMPostDip270;

            string jsonLPostDip270 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_PostDip270);
            ViewBag.jsonLPostDip270 = jsonLPostDip270;

            //15.MicroEtch_Etch_Rate
            string jsonTimeDailyMicroEtch_Etch_Rate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_MicroEtch_Etch_Rate);
            ViewBag.jsonTimeDailyMicroEtch_Etch_Rate = jsonTimeDailyMicroEtch_Etch_Rate;

            string jsonHMicroEtch_Etch_Rate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_MicroEtch_Etch_Rate);
            ViewBag.jsonHMicroEtch_Etch_Rate = jsonHMicroEtch_Etch_Rate;

            string jsonMMicroEtch_Etch_Rate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_MicroEtch_Etch_Rate);
            ViewBag.jsonMMicroEtch_Etch_Rate = jsonMMicroEtch_Etch_Rate;

            string jsonLMicroEtch_Etch_Rate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_MicroEtch_Etch_Rate);
            ViewBag.jsonLMicroEtch_Etch_Rate = jsonLMicroEtch_Etch_Rate;

           

            return View(model);



        }




    }
}
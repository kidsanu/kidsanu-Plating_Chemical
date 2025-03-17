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
    public class PT_MC_Chemical_PTH_Controller : Controller
    {
        //Desmear1
        public ActionResult SavePTH1(PT_MC_PTH_InputResult spt1)
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP01");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePTH1(string Cancel, PT_MC_PTH_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16, string Tritrate17, string ResultCal17, string Tritrate18, string ResultCal18, string Tritrate19, string ResultCal19, string Tritrate20, string ResultCal20,string STD5,string STD7)
        {

            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1,"PLCCP01");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
                PT_MC_PTH_InputResult model = p.GetDataPTH("PLCCP01", spt1,strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, Tritrate12, ResultCal12, Tritrate13, ResultCal13, Tritrate14, ResultCal14, Tritrate15, ResultCal15, Tritrate16, ResultCal16, Tritrate17, ResultCal17, Tritrate18, ResultCal18, Tritrate19, ResultCal19, Tritrate20, ResultCal20,STD5,STD7);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }
        }


        //PTH2
        public ActionResult SavePTH2(PT_MC_PTH_InputResult spt1)
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP02");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePTH2(string Cancel, PT_MC_PTH_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16, string Tritrate17, string ResultCal17, string Tritrate18, string ResultCal18, string Tritrate19, string ResultCal19, string Tritrate20, string ResultCal20, string STD5, string STD7)
        {

            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP02");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
                PT_MC_PTH_InputResult model = p.GetDataPTH("PLCCP02", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, Tritrate12, ResultCal12, Tritrate13, ResultCal13, Tritrate14, ResultCal14, Tritrate15, ResultCal15, Tritrate16, ResultCal16, Tritrate17, ResultCal17, Tritrate18, ResultCal18, Tritrate19, ResultCal19, Tritrate20, ResultCal20,STD5,STD7);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        //PTH3
        public ActionResult SavePTH3(PT_MC_PTH_InputResult spt1)
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP03");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePTH3(string Cancel, PT_MC_PTH_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16, string Tritrate17, string ResultCal17, string Tritrate18, string ResultCal18, string Tritrate19, string ResultCal19, string Tritrate20, string ResultCal20, string STD5, string STD7)
        {

            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP03");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
                PT_MC_PTH_InputResult model = p.GetDataPTH("PLCCP03", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, Tritrate12, ResultCal12, Tritrate13, ResultCal13, Tritrate14, ResultCal14, Tritrate15, ResultCal15, Tritrate16, ResultCal16, Tritrate17, ResultCal17, Tritrate18, ResultCal18, Tritrate19, ResultCal19, Tritrate20, ResultCal20,STD5 ,STD7 );
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        //PTH4
        public ActionResult SavePTH4(PT_MC_PTH_InputResult spt1)
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP04");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePTH4(string Cancel, PT_MC_PTH_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12, string Tritrate13, string ResultCal13, string Tritrate14, string ResultCal14, string Tritrate15, string ResultCal15, string Tritrate16, string ResultCal16, string Tritrate17, string ResultCal17, string Tritrate18, string ResultCal18, string Tritrate19, string ResultCal19, string Tritrate20, string ResultCal20, string STD5, string STD7)
        {

            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PTH_InputResult model = objChe.GetMainDataPTH(spt1, "PLCCP04");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
                PT_MC_PTH_InputResult model = p.GetDataPTH("PLCCP04", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, Tritrate12, ResultCal12, Tritrate13, ResultCal13, Tritrate14, ResultCal14, Tritrate15, ResultCal15, Tritrate16, ResultCal16, Tritrate17, ResultCal17, Tritrate18, ResultCal18, Tritrate19, ResultCal19, Tritrate20, ResultCal20,STD5 ,STD7 );
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        /// PTH 1
        public ActionResult ChemicalSupplyPTH1()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLCCP01");
            return View(model);

        }
        /// 
        /// PTH2
        public ActionResult ChemicalSupplyPTH2()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLCCP02");
            return View(model);

        }
        /// 
        /// PTH3
        public ActionResult ChemicalSupplyPTH3()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLCCP03");
            return View(model);

        }
        /// 
        /// PTH4
        public ActionResult ChemicalSupplyPTH4()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLCCP04");
            return View(model);

        }
        /// 


        public ActionResult InputAnalysisPTH1()
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            List<PT_MC_PTH_InputResult> model = p.GetPT_MC_InputInfoPTH("PLCCP01");
            return View(model);
        }
        public ActionResult InputAnalysisPTH2()
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            List<PT_MC_PTH_InputResult> model = p.GetPT_MC_InputInfoPTH("PLCCP02");
            return View(model);
        }
        public ActionResult InputAnalysisPTH3()
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            List<PT_MC_PTH_InputResult> model = p.GetPT_MC_InputInfoPTH("PLCCP03");
            return View(model);
        }
        public ActionResult InputAnalysisPTH4()
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            List<PT_MC_PTH_InputResult> model = p.GetPT_MC_InputInfoPTH("PLCCP04");
            return View(model);
        }


        public ActionResult DetailInputPTH1(int? id, string Edit, string Delete, PT_MC_PTH_InputResult res)
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPTH(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPTH(id);

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

        public ActionResult DetailInputPTH2(int? id, string Edit, string Delete, PT_MC_PTH_InputResult res)
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPTH(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPTH(id);

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

        public ActionResult DetailInputPTH3(int? id, string Edit, string Delete, PT_MC_PTH_InputResult res)
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPTH(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPTH(id);

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

        public ActionResult DetailInputPTH4(int? id, string Edit, string Delete, PT_MC_PTH_InputResult res)
        {
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPTH(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PTH_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPTH(id);

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


        //Graph PTH1 Date : 29-Sep-2020
        public ActionResult GraphPTH1(PT_MC_PTH_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            PT_MC_PTH_InputResult model = p.GetGraphPTH("PLCCP01", spt1);

            //1.Cu Electroless (2.0 - 2.8 g/L)

            string jsonTimeDailyCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CuElectroless);
            ViewBag.jsonTimeDailyCuElectroless = jsonTimeDailyCuElectroless;

            string jsonHCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CuElectroless);
            ViewBag.jsonHCuElectroless = jsonHCuElectroless;

            string jsonMCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CuElectroless);
            ViewBag.jsonMCuElectroless = jsonMCuElectroless;

            string jsonLCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CuElectroless);
            ViewBag.jsonLCuElectroless = jsonLCuElectroless;


            //2.EDTA Elextroless (14-30 g/L)

            string jsonTimeDailyEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_EDTAElextroless);
            ViewBag.jsonTimeDailyEDTAElextroless = jsonTimeDailyEDTAElextroless;

            string jsonHEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_EDTAElextroless);
            ViewBag.jsonHEDTAElextroless = jsonHEDTAElextroless;

            string jsonMEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_EDTAElextroless);
            ViewBag.jsonMEDTAElextroless = jsonMEDTAElextroless;

            string jsonLEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_EDTAElextroless);
            ViewBag.jsonLEDTAElextroless = jsonLEDTAElextroless;

            //3.Sodium hydroxide

            string jsonTimeDailySodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sodiumhydroxide);
            ViewBag.jsonTimeDailySodiumhydroxide = jsonTimeDailySodiumhydroxide;

            string jsonHSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sodiumhydroxide);
            ViewBag.jsonHSodiumhydroxide = jsonHSodiumhydroxide;

            string jsonMSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sodiumhydroxide);
            ViewBag.jsonMSodiumhydroxide = jsonMSodiumhydroxide;

            string jsonLSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sodiumhydroxide);
            ViewBag.jsonLSodiumhydroxide = jsonLSodiumhydroxide;

            //4.Formaldahyde

            string jsonTimeDailyFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Formaldahyde);
            ViewBag.jsonTimeDailyFormaldahyde = jsonTimeDailyFormaldahyde;

            string jsonHFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Formaldahyde);
            ViewBag.jsonHFormaldahyde = jsonHFormaldahyde;

            string jsonMFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Formaldahyde);
            ViewBag.jsonMFormaldahyde = jsonMFormaldahyde;

            string jsonLFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Formaldahyde);
            ViewBag.jsonLFormaldahyde = jsonLFormaldahyde;

            //5.CleanerBath

            string jsonTimeDailyCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CleanerBath);
            ViewBag.jsonTimeDailyCleanerBath = jsonTimeDailyCleanerBath;

            string jsonHCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CleanerBath);
            ViewBag.jsonHCleanerBath = jsonHCleanerBath;

            string jsonMCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CleanerBath);
            ViewBag.jsonMCleanerBath = jsonMCleanerBath;

            string jsonLCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CleanerBath);
            ViewBag.jsonLCleanerBath = jsonLCleanerBath;

            //6.CopperContent

            string jsonTimeDailyCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent);
            ViewBag.jsonTimeDailyCopperContent = jsonTimeDailyCopperContent;

            string jsonHCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonHCopperContent = jsonHCopperContent;

            string jsonMCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent);
            ViewBag.jsonMCopperContent = jsonMCopperContent;

            string jsonLCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonLCopperContent = jsonLCopperContent;

            //7.Acid1

            string jsonTimeDailyAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid1);
            ViewBag.jsonTimeDailyAcid1 = jsonTimeDailyAcid1;

            string jsonHAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonHAcid1 = jsonHAcid1;

            string jsonMAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid1);
            ViewBag.jsonMAcid1 = jsonMAcid1;

            string jsonLAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonLAcid1 = jsonLAcid1;


            //8.Acid2

            string jsonTimeDailyAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid2);
            ViewBag.jsonTimeDailyAcid2 = jsonTimeDailyAcid2;

            string jsonHAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Acid2);
            ViewBag.jsonHAcid2 = jsonHAcid2;

            string jsonMAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid2);
            ViewBag.jsonMAcid2 = jsonMAcid2;

            string jsonLAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid2);
            ViewBag.jsonLAcid2 = jsonLAcid2;

            //9.PredipSG

            string jsonTimeDailyPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_PredipSG);
            ViewBag.jsonTimeDailyPredipSG = jsonTimeDailyPredipSG;

            string jsonHPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_PredipSG);
            ViewBag.jsonHPredipSG = jsonHPredipSG;

            string jsonMPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_PredipSG);
            ViewBag.jsonMPredipSG = jsonMPredipSG;

            string jsonLPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_PredipSG);
            ViewBag.jsonLPredipSG = jsonLPredipSG;

            //10.CopperContent_PreDip

            string jsonTimeDailyCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_PreDip);
            ViewBag.jsonTimeDailyCopperContent_PreDip = jsonTimeDailyCopperContent_PreDip;

            string jsonHCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_PreDip);
            ViewBag.jsonHCopperContent_PreDip = jsonHCopperContent_PreDip;

            string jsonMCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_PreDip);
            ViewBag.jsonMCopperContent_PreDip = jsonMCopperContent_PreDip;

            string jsonLCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_PreDip);
            ViewBag.jsonLCopperContent_PreDip = jsonLCopperContent_PreDip;


            //11.CatalystSG

            string jsonTimeDailyCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatalystSG);
            ViewBag.jsonTimeDailyCatalystSG = jsonTimeDailyCatalystSG;

            string jsonHCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CatalystSG);
            ViewBag.jsonHCatalystSG = jsonHCatalystSG;

            string jsonMCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CatalystSG);
            ViewBag.jsonMCatalystSG = jsonMCatalystSG;

            string jsonLCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CatalystSG);
            ViewBag.jsonLCatalystSG = jsonLCatalystSG;


            //12.Palladium


            string jsonTimeDailyPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Palladium);
            ViewBag.jsonTimeDailyPalladium = jsonTimeDailyPalladium;

            string jsonHPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Palladium);
            ViewBag.jsonHPalladium = jsonHPalladium;

            string jsonMPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Palladium);
            ViewBag.jsonMPalladium = jsonMPalladium;

            string jsonLPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Palladium);
            ViewBag.jsonLPalladium = jsonLPalladium;


            //13.Cat44SnCl
            string jsonTimeDailyCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Cat44SnCl);
            ViewBag.jsonTimeDailyCat44SnCl = jsonTimeDailyCat44SnCl;

            string jsonHCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCat44SnCl = jsonHCat44SnCl;

            string jsonMCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCat44SnCl = jsonMCat44SnCl;

            string jsonLCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCat44SnCl = jsonLCat44SnCl;



            //14.CatNormality

            string jsonTimeDailyCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatNormality);
            ViewBag.jsonTimeDailyCatNormality = jsonTimeDailyCatNormality;

            string jsonHCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCatNormality = jsonHCatNormality;

            string jsonMCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCatNormality = jsonMCatNormality;

            string jsonLCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCatNormality = jsonLCatNormality;




            //15.AccNormality
            string jsonTimeDailyAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_AccNormality);
            ViewBag.jsonTimeDailyAccNormality = jsonTimeDailyAccNormality;

            string jsonHAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_AccNormality);
            ViewBag.jsonHAccNormality = jsonHAccNormality;

            string jsonMAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_AccNormality);
            ViewBag.jsonMAccNormality = jsonMAccNormality;

            string jsonLAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_AccNormality);
            ViewBag.jsonLAccNormality = jsonLAccNormality;


            //16.CopperContent_Acc
            string jsonTimeDailyCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_Acc);
            ViewBag.jsonTimeDailyCopperContent_Acc = jsonTimeDailyCopperContent_Acc;

            string jsonHCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_Acc);
            ViewBag.jsonHCopperContent_Acc = jsonHCopperContent_Acc;

            string jsonMCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_Acc);
            ViewBag.jsonMCopperContent_Acc = jsonMCopperContent_Acc;

            string jsonLCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_Acc);
            ViewBag.jsonLCopperContent_Acc = jsonLCopperContent_Acc;


            //17.APS30

            string jsonTimeDailyAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS30);
            ViewBag.jsonTimeDailyAPS30 = jsonTimeDailyAPS30;

            string jsonHAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS30);
            ViewBag.jsonHAPS30 = jsonHAPS30;

            string jsonMAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS30);
            ViewBag.jsonMAPS30 = jsonMAPS30;

            string jsonLAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS30);
            ViewBag.jsonLAPS30 = jsonLAPS30;

            //18.CopperContent_30

            string jsonTimeDailyCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_30);
            ViewBag.jsonTimeDailyCopperContent_30 = jsonTimeDailyCopperContent_30;

            string jsonHCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonHCopperContent_30 = jsonHCopperContent_30;

            string jsonMCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_30);
            ViewBag.jsonMCopperContent_30 = jsonMCopperContent_30;

            string jsonLCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonLCopperContent_30 = jsonLCopperContent_30;

            //19.APS31

            string jsonTimeDailyAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS31);
            ViewBag.jsonTimeDailyAPS31 = jsonTimeDailyAPS31;

            string jsonHAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS31);
            ViewBag.jsonHAPS31 = jsonHAPS31;

            string jsonMAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS31);
            ViewBag.jsonMAPS31 = jsonMAPS31;

            string jsonLAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS31);
            ViewBag.jsonLAPS31 = jsonLAPS31;

            //20.CopperContent_31

            string jsonTimeDailyCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_31);
            ViewBag.jsonTimeDailyCopperContent_31 = jsonTimeDailyCopperContent_31;

            string jsonHCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonHCopperContent_31 = jsonHCopperContent_31;

            string jsonMCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_31);
            ViewBag.jsonMCopperContent_31 = jsonMCopperContent_31;

            string jsonLCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonLCopperContent_31 = jsonLCopperContent_31;






            return View(model);



        }


        public ActionResult GraphPTH2(PT_MC_PTH_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            PT_MC_PTH_InputResult model = p.GetGraphPTH("PLCCP02", spt1);

            //1.Cu Electroless (2.0 - 2.8 g/L)

            string jsonTimeDailyCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CuElectroless);
            ViewBag.jsonTimeDailyCuElectroless = jsonTimeDailyCuElectroless;

            string jsonHCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CuElectroless);
            ViewBag.jsonHCuElectroless = jsonHCuElectroless;

            string jsonMCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CuElectroless);
            ViewBag.jsonMCuElectroless = jsonMCuElectroless;

            string jsonLCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CuElectroless);
            ViewBag.jsonLCuElectroless = jsonLCuElectroless;


            //2.EDTA Elextroless (14-30 g/L)

            string jsonTimeDailyEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_EDTAElextroless);
            ViewBag.jsonTimeDailyEDTAElextroless = jsonTimeDailyEDTAElextroless;

            string jsonHEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_EDTAElextroless);
            ViewBag.jsonHEDTAElextroless = jsonHEDTAElextroless;

            string jsonMEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_EDTAElextroless);
            ViewBag.jsonMEDTAElextroless = jsonMEDTAElextroless;

            string jsonLEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_EDTAElextroless);
            ViewBag.jsonLEDTAElextroless = jsonLEDTAElextroless;

            //3.Sodium hydroxide

            string jsonTimeDailySodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sodiumhydroxide);
            ViewBag.jsonTimeDailySodiumhydroxide = jsonTimeDailySodiumhydroxide;

            string jsonHSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sodiumhydroxide);
            ViewBag.jsonHSodiumhydroxide = jsonHSodiumhydroxide;

            string jsonMSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sodiumhydroxide);
            ViewBag.jsonMSodiumhydroxide = jsonMSodiumhydroxide;

            string jsonLSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sodiumhydroxide);
            ViewBag.jsonLSodiumhydroxide = jsonLSodiumhydroxide;

            //4.Formaldahyde

            string jsonTimeDailyFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Formaldahyde);
            ViewBag.jsonTimeDailyFormaldahyde = jsonTimeDailyFormaldahyde;

            string jsonHFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Formaldahyde);
            ViewBag.jsonHFormaldahyde = jsonHFormaldahyde;

            string jsonMFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Formaldahyde);
            ViewBag.jsonMFormaldahyde = jsonMFormaldahyde;

            string jsonLFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Formaldahyde);
            ViewBag.jsonLFormaldahyde = jsonLFormaldahyde;

            //5.CleanerBath

            string jsonTimeDailyCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CleanerBath);
            ViewBag.jsonTimeDailyCleanerBath = jsonTimeDailyCleanerBath;

            string jsonHCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CleanerBath);
            ViewBag.jsonHCleanerBath = jsonHCleanerBath;

            string jsonMCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CleanerBath);
            ViewBag.jsonMCleanerBath = jsonMCleanerBath;

            string jsonLCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CleanerBath);
            ViewBag.jsonLCleanerBath = jsonLCleanerBath;

            //6.CopperContent

            string jsonTimeDailyCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent);
            ViewBag.jsonTimeDailyCopperContent = jsonTimeDailyCopperContent;

            string jsonHCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonHCopperContent = jsonHCopperContent;

            string jsonMCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent);
            ViewBag.jsonMCopperContent = jsonMCopperContent;

            string jsonLCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonLCopperContent = jsonLCopperContent;

            //7.Acid1

            string jsonTimeDailyAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid1);
            ViewBag.jsonTimeDailyAcid1 = jsonTimeDailyAcid1;

            string jsonHAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonHAcid1 = jsonHAcid1;

            string jsonMAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid1);
            ViewBag.jsonMAcid1 = jsonMAcid1;

            string jsonLAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonLAcid1 = jsonLAcid1;


            //8.Acid2

            string jsonTimeDailyAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid2);
            ViewBag.jsonTimeDailyAcid2 = jsonTimeDailyAcid2;

            string jsonHAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Acid2);
            ViewBag.jsonHAcid2 = jsonHAcid2;

            string jsonMAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid2);
            ViewBag.jsonMAcid2 = jsonMAcid2;

            string jsonLAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid2);
            ViewBag.jsonLAcid2 = jsonLAcid2;

            //9.PredipSG

            string jsonTimeDailyPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_PredipSG);
            ViewBag.jsonTimeDailyPredipSG = jsonTimeDailyPredipSG;

            string jsonHPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_PredipSG);
            ViewBag.jsonHPredipSG = jsonHPredipSG;

            string jsonMPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_PredipSG);
            ViewBag.jsonMPredipSG = jsonMPredipSG;

            string jsonLPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_PredipSG);
            ViewBag.jsonLPredipSG = jsonLPredipSG;

            //10.CopperContent_PreDip

            string jsonTimeDailyCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_PreDip);
            ViewBag.jsonTimeDailyCopperContent_PreDip = jsonTimeDailyCopperContent_PreDip;

            string jsonHCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_PreDip);
            ViewBag.jsonHCopperContent_PreDip = jsonHCopperContent_PreDip;

            string jsonMCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_PreDip);
            ViewBag.jsonMCopperContent_PreDip = jsonMCopperContent_PreDip;

            string jsonLCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_PreDip);
            ViewBag.jsonLCopperContent_PreDip = jsonLCopperContent_PreDip;


            //11.CatalystSG

            string jsonTimeDailyCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatalystSG);
            ViewBag.jsonTimeDailyCatalystSG = jsonTimeDailyCatalystSG;

            string jsonHCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CatalystSG);
            ViewBag.jsonHCatalystSG = jsonHCatalystSG;

            string jsonMCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CatalystSG);
            ViewBag.jsonMCatalystSG = jsonMCatalystSG;

            string jsonLCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CatalystSG);
            ViewBag.jsonLCatalystSG = jsonLCatalystSG;


            //12.Palladium


            string jsonTimeDailyPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Palladium);
            ViewBag.jsonTimeDailyPalladium = jsonTimeDailyPalladium;

            string jsonHPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Palladium);
            ViewBag.jsonHPalladium = jsonHPalladium;

            string jsonMPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Palladium);
            ViewBag.jsonMPalladium = jsonMPalladium;

            string jsonLPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Palladium);
            ViewBag.jsonLPalladium = jsonLPalladium;


            //13.Cat44SnCl
            string jsonTimeDailyCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Cat44SnCl);
            ViewBag.jsonTimeDailyCat44SnCl = jsonTimeDailyCat44SnCl;

            string jsonHCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCat44SnCl = jsonHCat44SnCl;

            string jsonMCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCat44SnCl = jsonMCat44SnCl;

            string jsonLCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCat44SnCl = jsonLCat44SnCl;



            //14.CatNormality

            string jsonTimeDailyCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatNormality);
            ViewBag.jsonTimeDailyCatNormality = jsonTimeDailyCatNormality;

            string jsonHCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCatNormality = jsonHCatNormality;

            string jsonMCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCatNormality = jsonMCatNormality;

            string jsonLCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCatNormality = jsonLCatNormality;




            //15.AccNormality
            string jsonTimeDailyAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_AccNormality);
            ViewBag.jsonTimeDailyAccNormality = jsonTimeDailyAccNormality;

            string jsonHAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_AccNormality);
            ViewBag.jsonHAccNormality = jsonHAccNormality;

            string jsonMAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_AccNormality);
            ViewBag.jsonMAccNormality = jsonMAccNormality;

            string jsonLAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_AccNormality);
            ViewBag.jsonLAccNormality = jsonLAccNormality;


            //16.CopperContent_Acc
            string jsonTimeDailyCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_Acc);
            ViewBag.jsonTimeDailyCopperContent_Acc = jsonTimeDailyCopperContent_Acc;

            string jsonHCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_Acc);
            ViewBag.jsonHCopperContent_Acc = jsonHCopperContent_Acc;

            string jsonMCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_Acc);
            ViewBag.jsonMCopperContent_Acc = jsonMCopperContent_Acc;

            string jsonLCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_Acc);
            ViewBag.jsonLCopperContent_Acc = jsonLCopperContent_Acc;


            //17.APS30

            string jsonTimeDailyAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS30);
            ViewBag.jsonTimeDailyAPS30 = jsonTimeDailyAPS30;

            string jsonHAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS30);
            ViewBag.jsonHAPS30 = jsonHAPS30;

            string jsonMAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS30);
            ViewBag.jsonMAPS30 = jsonMAPS30;

            string jsonLAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS30);
            ViewBag.jsonLAPS30 = jsonLAPS30;

            //18.CopperContent_30

            string jsonTimeDailyCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_30);
            ViewBag.jsonTimeDailyCopperContent_30 = jsonTimeDailyCopperContent_30;

            string jsonHCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonHCopperContent_30 = jsonHCopperContent_30;

            string jsonMCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_30);
            ViewBag.jsonMCopperContent_30 = jsonMCopperContent_30;

            string jsonLCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonLCopperContent_30 = jsonLCopperContent_30;

            //19.APS31

            string jsonTimeDailyAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS31);
            ViewBag.jsonTimeDailyAPS31 = jsonTimeDailyAPS31;

            string jsonHAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS31);
            ViewBag.jsonHAPS31 = jsonHAPS31;

            string jsonMAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS31);
            ViewBag.jsonMAPS31 = jsonMAPS31;

            string jsonLAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS31);
            ViewBag.jsonLAPS31 = jsonLAPS31;

            //20.CopperContent_31

            string jsonTimeDailyCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_31);
            ViewBag.jsonTimeDailyCopperContent_31 = jsonTimeDailyCopperContent_31;

            string jsonHCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonHCopperContent_31 = jsonHCopperContent_31;

            string jsonMCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_31);
            ViewBag.jsonMCopperContent_31 = jsonMCopperContent_31;

            string jsonLCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonLCopperContent_31 = jsonLCopperContent_31;






            return View(model);



        }


        public ActionResult GraphPTH3(PT_MC_PTH_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            PT_MC_PTH_InputResult model = p.GetGraphPTH("PLCCP03", spt1);

            //1.Cu Electroless (2.0 - 2.8 g/L)

            string jsonTimeDailyCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CuElectroless);
            ViewBag.jsonTimeDailyCuElectroless = jsonTimeDailyCuElectroless;

            string jsonHCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CuElectroless);
            ViewBag.jsonHCuElectroless = jsonHCuElectroless;

            string jsonMCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CuElectroless);
            ViewBag.jsonMCuElectroless = jsonMCuElectroless;

            string jsonLCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CuElectroless);
            ViewBag.jsonLCuElectroless = jsonLCuElectroless;


            //2.EDTA Elextroless (14-30 g/L)

            string jsonTimeDailyEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_EDTAElextroless);
            ViewBag.jsonTimeDailyEDTAElextroless = jsonTimeDailyEDTAElextroless;

            string jsonHEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_EDTAElextroless);
            ViewBag.jsonHEDTAElextroless = jsonHEDTAElextroless;

            string jsonMEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_EDTAElextroless);
            ViewBag.jsonMEDTAElextroless = jsonMEDTAElextroless;

            string jsonLEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_EDTAElextroless);
            ViewBag.jsonLEDTAElextroless = jsonLEDTAElextroless;

            //3.Sodium hydroxide

            string jsonTimeDailySodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sodiumhydroxide);
            ViewBag.jsonTimeDailySodiumhydroxide = jsonTimeDailySodiumhydroxide;

            string jsonHSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sodiumhydroxide);
            ViewBag.jsonHSodiumhydroxide = jsonHSodiumhydroxide;

            string jsonMSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sodiumhydroxide);
            ViewBag.jsonMSodiumhydroxide = jsonMSodiumhydroxide;

            string jsonLSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sodiumhydroxide);
            ViewBag.jsonLSodiumhydroxide = jsonLSodiumhydroxide;

            //4.Formaldahyde

            string jsonTimeDailyFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Formaldahyde);
            ViewBag.jsonTimeDailyFormaldahyde = jsonTimeDailyFormaldahyde;

            string jsonHFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Formaldahyde);
            ViewBag.jsonHFormaldahyde = jsonHFormaldahyde;

            string jsonMFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Formaldahyde);
            ViewBag.jsonMFormaldahyde = jsonMFormaldahyde;

            string jsonLFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Formaldahyde);
            ViewBag.jsonLFormaldahyde = jsonLFormaldahyde;

            //5.CleanerBath

            string jsonTimeDailyCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CleanerBath);
            ViewBag.jsonTimeDailyCleanerBath = jsonTimeDailyCleanerBath;

            string jsonHCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CleanerBath);
            ViewBag.jsonHCleanerBath = jsonHCleanerBath;

            string jsonMCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CleanerBath);
            ViewBag.jsonMCleanerBath = jsonMCleanerBath;

            string jsonLCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CleanerBath);
            ViewBag.jsonLCleanerBath = jsonLCleanerBath;

            //6.CopperContent

            string jsonTimeDailyCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent);
            ViewBag.jsonTimeDailyCopperContent = jsonTimeDailyCopperContent;

            string jsonHCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonHCopperContent = jsonHCopperContent;

            string jsonMCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent);
            ViewBag.jsonMCopperContent = jsonMCopperContent;

            string jsonLCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonLCopperContent = jsonLCopperContent;

            //7.Acid1

            string jsonTimeDailyAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid1);
            ViewBag.jsonTimeDailyAcid1 = jsonTimeDailyAcid1;

            string jsonHAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonHAcid1 = jsonHAcid1;

            string jsonMAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid1);
            ViewBag.jsonMAcid1 = jsonMAcid1;

            string jsonLAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonLAcid1 = jsonLAcid1;


            //8.Acid2

            string jsonTimeDailyAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid2);
            ViewBag.jsonTimeDailyAcid2 = jsonTimeDailyAcid2;

            string jsonHAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Acid2);
            ViewBag.jsonHAcid2 = jsonHAcid2;

            string jsonMAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid2);
            ViewBag.jsonMAcid2 = jsonMAcid2;

            string jsonLAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid2);
            ViewBag.jsonLAcid2 = jsonLAcid2;

            //9.PredipSG

            string jsonTimeDailyPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_PredipSG);
            ViewBag.jsonTimeDailyPredipSG = jsonTimeDailyPredipSG;

            string jsonHPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_PredipSG);
            ViewBag.jsonHPredipSG = jsonHPredipSG;

            string jsonMPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_PredipSG);
            ViewBag.jsonMPredipSG = jsonMPredipSG;

            string jsonLPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_PredipSG);
            ViewBag.jsonLPredipSG = jsonLPredipSG;

            //10.CopperContent_PreDip

            string jsonTimeDailyCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_PreDip);
            ViewBag.jsonTimeDailyCopperContent_PreDip = jsonTimeDailyCopperContent_PreDip;

            string jsonHCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_PreDip);
            ViewBag.jsonHCopperContent_PreDip = jsonHCopperContent_PreDip;

            string jsonMCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_PreDip);
            ViewBag.jsonMCopperContent_PreDip = jsonMCopperContent_PreDip;

            string jsonLCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_PreDip);
            ViewBag.jsonLCopperContent_PreDip = jsonLCopperContent_PreDip;


            //11.CatalystSG

            string jsonTimeDailyCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatalystSG);
            ViewBag.jsonTimeDailyCatalystSG = jsonTimeDailyCatalystSG;

            string jsonHCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CatalystSG);
            ViewBag.jsonHCatalystSG = jsonHCatalystSG;

            string jsonMCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CatalystSG);
            ViewBag.jsonMCatalystSG = jsonMCatalystSG;

            string jsonLCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CatalystSG);
            ViewBag.jsonLCatalystSG = jsonLCatalystSG;


            //12.Palladium


            string jsonTimeDailyPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Palladium);
            ViewBag.jsonTimeDailyPalladium = jsonTimeDailyPalladium;

            string jsonHPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Palladium);
            ViewBag.jsonHPalladium = jsonHPalladium;

            string jsonMPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Palladium);
            ViewBag.jsonMPalladium = jsonMPalladium;

            string jsonLPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Palladium);
            ViewBag.jsonLPalladium = jsonLPalladium;


            //13.Cat44SnCl
            string jsonTimeDailyCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Cat44SnCl);
            ViewBag.jsonTimeDailyCat44SnCl = jsonTimeDailyCat44SnCl;

            string jsonHCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCat44SnCl = jsonHCat44SnCl;

            string jsonMCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCat44SnCl = jsonMCat44SnCl;

            string jsonLCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCat44SnCl = jsonLCat44SnCl;



            //14.CatNormality

            string jsonTimeDailyCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatNormality);
            ViewBag.jsonTimeDailyCatNormality = jsonTimeDailyCatNormality;

            string jsonHCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCatNormality = jsonHCatNormality;

            string jsonMCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCatNormality = jsonMCatNormality;

            string jsonLCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCatNormality = jsonLCatNormality;




            //15.AccNormality
            string jsonTimeDailyAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_AccNormality);
            ViewBag.jsonTimeDailyAccNormality = jsonTimeDailyAccNormality;

            string jsonHAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_AccNormality);
            ViewBag.jsonHAccNormality = jsonHAccNormality;

            string jsonMAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_AccNormality);
            ViewBag.jsonMAccNormality = jsonMAccNormality;

            string jsonLAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_AccNormality);
            ViewBag.jsonLAccNormality = jsonLAccNormality;


            //16.CopperContent_Acc
            string jsonTimeDailyCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_Acc);
            ViewBag.jsonTimeDailyCopperContent_Acc = jsonTimeDailyCopperContent_Acc;

            string jsonHCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_Acc);
            ViewBag.jsonHCopperContent_Acc = jsonHCopperContent_Acc;

            string jsonMCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_Acc);
            ViewBag.jsonMCopperContent_Acc = jsonMCopperContent_Acc;

            string jsonLCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_Acc);
            ViewBag.jsonLCopperContent_Acc = jsonLCopperContent_Acc;


            //17.APS30

            string jsonTimeDailyAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS30);
            ViewBag.jsonTimeDailyAPS30 = jsonTimeDailyAPS30;

            string jsonHAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS30);
            ViewBag.jsonHAPS30 = jsonHAPS30;

            string jsonMAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS30);
            ViewBag.jsonMAPS30 = jsonMAPS30;

            string jsonLAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS30);
            ViewBag.jsonLAPS30 = jsonLAPS30;

            //18.CopperContent_30

            string jsonTimeDailyCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_30);
            ViewBag.jsonTimeDailyCopperContent_30 = jsonTimeDailyCopperContent_30;

            string jsonHCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonHCopperContent_30 = jsonHCopperContent_30;

            string jsonMCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_30);
            ViewBag.jsonMCopperContent_30 = jsonMCopperContent_30;

            string jsonLCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonLCopperContent_30 = jsonLCopperContent_30;

            //19.APS31

            string jsonTimeDailyAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS31);
            ViewBag.jsonTimeDailyAPS31 = jsonTimeDailyAPS31;

            string jsonHAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS31);
            ViewBag.jsonHAPS31 = jsonHAPS31;

            string jsonMAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS31);
            ViewBag.jsonMAPS31 = jsonMAPS31;

            string jsonLAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS31);
            ViewBag.jsonLAPS31 = jsonLAPS31;

            //20.CopperContent_31

            string jsonTimeDailyCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_31);
            ViewBag.jsonTimeDailyCopperContent_31 = jsonTimeDailyCopperContent_31;

            string jsonHCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonHCopperContent_31 = jsonHCopperContent_31;

            string jsonMCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_31);
            ViewBag.jsonMCopperContent_31 = jsonMCopperContent_31;

            string jsonLCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonLCopperContent_31 = jsonLCopperContent_31;


            return View(model);

        }

        public ActionResult GraphPTH4(PT_MC_PTH_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_PTHManager objChe = new PT_MC_Input_PTHManager();
            PT_MC_Input_PTHManager p = new PT_MC_Input_PTHManager();
            PT_MC_PTH_InputResult model = p.GetGraphPTH("PLCCP04", spt1);

            //1.Cu Electroless (2.0 - 2.8 g/L)

            string jsonTimeDailyCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CuElectroless);
            ViewBag.jsonTimeDailyCuElectroless = jsonTimeDailyCuElectroless;

            string jsonHCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CuElectroless);
            ViewBag.jsonHCuElectroless = jsonHCuElectroless;

            string jsonMCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CuElectroless);
            ViewBag.jsonMCuElectroless = jsonMCuElectroless;

            string jsonLCuElectroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CuElectroless);
            ViewBag.jsonLCuElectroless = jsonLCuElectroless;


            //2.EDTA Elextroless (14-30 g/L)

            string jsonTimeDailyEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_EDTAElextroless);
            ViewBag.jsonTimeDailyEDTAElextroless = jsonTimeDailyEDTAElextroless;

            string jsonHEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_EDTAElextroless);
            ViewBag.jsonHEDTAElextroless = jsonHEDTAElextroless;

            string jsonMEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_EDTAElextroless);
            ViewBag.jsonMEDTAElextroless = jsonMEDTAElextroless;

            string jsonLEDTAElextroless = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_EDTAElextroless);
            ViewBag.jsonLEDTAElextroless = jsonLEDTAElextroless;

            //3.Sodium hydroxide

            string jsonTimeDailySodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sodiumhydroxide);
            ViewBag.jsonTimeDailySodiumhydroxide = jsonTimeDailySodiumhydroxide;

            string jsonHSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sodiumhydroxide);
            ViewBag.jsonHSodiumhydroxide = jsonHSodiumhydroxide;

            string jsonMSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sodiumhydroxide);
            ViewBag.jsonMSodiumhydroxide = jsonMSodiumhydroxide;

            string jsonLSodiumhydroxide = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sodiumhydroxide);
            ViewBag.jsonLSodiumhydroxide = jsonLSodiumhydroxide;

            //4.Formaldahyde

            string jsonTimeDailyFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Formaldahyde);
            ViewBag.jsonTimeDailyFormaldahyde = jsonTimeDailyFormaldahyde;

            string jsonHFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Formaldahyde);
            ViewBag.jsonHFormaldahyde = jsonHFormaldahyde;

            string jsonMFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Formaldahyde);
            ViewBag.jsonMFormaldahyde = jsonMFormaldahyde;

            string jsonLFormaldahyde = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Formaldahyde);
            ViewBag.jsonLFormaldahyde = jsonLFormaldahyde;

            //5.CleanerBath

            string jsonTimeDailyCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CleanerBath);
            ViewBag.jsonTimeDailyCleanerBath = jsonTimeDailyCleanerBath;

            string jsonHCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CleanerBath);
            ViewBag.jsonHCleanerBath = jsonHCleanerBath;

            string jsonMCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CleanerBath);
            ViewBag.jsonMCleanerBath = jsonMCleanerBath;

            string jsonLCleanerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CleanerBath);
            ViewBag.jsonLCleanerBath = jsonLCleanerBath;

            //6.CopperContent

            string jsonTimeDailyCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent);
            ViewBag.jsonTimeDailyCopperContent = jsonTimeDailyCopperContent;

            string jsonHCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonHCopperContent = jsonHCopperContent;

            string jsonMCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent);
            ViewBag.jsonMCopperContent = jsonMCopperContent;

            string jsonLCopperContent = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent);
            ViewBag.jsonLCopperContent = jsonLCopperContent;

            //7.Acid1

            string jsonTimeDailyAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid1);
            ViewBag.jsonTimeDailyAcid1 = jsonTimeDailyAcid1;

            string jsonHAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonHAcid1 = jsonHAcid1;

            string jsonMAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid1);
            ViewBag.jsonMAcid1 = jsonMAcid1;

            string jsonLAcid1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid1);
            ViewBag.jsonLAcid1 = jsonLAcid1;


            //8.Acid2

            string jsonTimeDailyAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Acid2);
            ViewBag.jsonTimeDailyAcid2 = jsonTimeDailyAcid2;

            string jsonHAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Acid2);
            ViewBag.jsonHAcid2 = jsonHAcid2;

            string jsonMAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Acid2);
            ViewBag.jsonMAcid2 = jsonMAcid2;

            string jsonLAcid2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Acid2);
            ViewBag.jsonLAcid2 = jsonLAcid2;

            //9.PredipSG

            string jsonTimeDailyPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_PredipSG);
            ViewBag.jsonTimeDailyPredipSG = jsonTimeDailyPredipSG;

            string jsonHPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_PredipSG);
            ViewBag.jsonHPredipSG = jsonHPredipSG;

            string jsonMPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_PredipSG);
            ViewBag.jsonMPredipSG = jsonMPredipSG;

            string jsonLPredipSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_PredipSG);
            ViewBag.jsonLPredipSG = jsonLPredipSG;

            //10.CopperContent_PreDip

            string jsonTimeDailyCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_PreDip);
            ViewBag.jsonTimeDailyCopperContent_PreDip = jsonTimeDailyCopperContent_PreDip;

            string jsonHCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_PreDip);
            ViewBag.jsonHCopperContent_PreDip = jsonHCopperContent_PreDip;

            string jsonMCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_PreDip);
            ViewBag.jsonMCopperContent_PreDip = jsonMCopperContent_PreDip;

            string jsonLCopperContent_PreDip = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_PreDip);
            ViewBag.jsonLCopperContent_PreDip = jsonLCopperContent_PreDip;


            //11.CatalystSG

            string jsonTimeDailyCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatalystSG);
            ViewBag.jsonTimeDailyCatalystSG = jsonTimeDailyCatalystSG;

            string jsonHCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CatalystSG);
            ViewBag.jsonHCatalystSG = jsonHCatalystSG;

            string jsonMCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CatalystSG);
            ViewBag.jsonMCatalystSG = jsonMCatalystSG;

            string jsonLCatalystSG = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CatalystSG);
            ViewBag.jsonLCatalystSG = jsonLCatalystSG;


            //12.Palladium


            string jsonTimeDailyPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Palladium);
            ViewBag.jsonTimeDailyPalladium = jsonTimeDailyPalladium;

            string jsonHPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Palladium);
            ViewBag.jsonHPalladium = jsonHPalladium;

            string jsonMPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Palladium);
            ViewBag.jsonMPalladium = jsonMPalladium;

            string jsonLPalladium = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Palladium);
            ViewBag.jsonLPalladium = jsonLPalladium;


            //13.Cat44SnCl
            string jsonTimeDailyCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Cat44SnCl);
            ViewBag.jsonTimeDailyCat44SnCl = jsonTimeDailyCat44SnCl;

            string jsonHCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCat44SnCl = jsonHCat44SnCl;

            string jsonMCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCat44SnCl = jsonMCat44SnCl;

            string jsonLCat44SnCl = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCat44SnCl = jsonLCat44SnCl;



            //14.CatNormality

            string jsonTimeDailyCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CatNormality);
            ViewBag.jsonTimeDailyCatNormality = jsonTimeDailyCatNormality;

            string jsonHCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Cat44SnCl);
            ViewBag.jsonHCatNormality = jsonHCatNormality;

            string jsonMCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Cat44SnCl);
            ViewBag.jsonMCatNormality = jsonMCatNormality;

            string jsonLCatNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Cat44SnCl);
            ViewBag.jsonLCatNormality = jsonLCatNormality;




            //15.AccNormality
            string jsonTimeDailyAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_AccNormality);
            ViewBag.jsonTimeDailyAccNormality = jsonTimeDailyAccNormality;

            string jsonHAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_AccNormality);
            ViewBag.jsonHAccNormality = jsonHAccNormality;

            string jsonMAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_AccNormality);
            ViewBag.jsonMAccNormality = jsonMAccNormality;

            string jsonLAccNormality = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_AccNormality);
            ViewBag.jsonLAccNormality = jsonLAccNormality;


            //16.CopperContent_Acc
            string jsonTimeDailyCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_Acc);
            ViewBag.jsonTimeDailyCopperContent_Acc = jsonTimeDailyCopperContent_Acc;

            string jsonHCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_CopperContent_Acc);
            ViewBag.jsonHCopperContent_Acc = jsonHCopperContent_Acc;

            string jsonMCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_Acc);
            ViewBag.jsonMCopperContent_Acc = jsonMCopperContent_Acc;

            string jsonLCopperContent_Acc = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_Acc);
            ViewBag.jsonLCopperContent_Acc = jsonLCopperContent_Acc;


            //17.APS30

            string jsonTimeDailyAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS30);
            ViewBag.jsonTimeDailyAPS30 = jsonTimeDailyAPS30;

            string jsonHAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS30);
            ViewBag.jsonHAPS30 = jsonHAPS30;

            string jsonMAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS30);
            ViewBag.jsonMAPS30 = jsonMAPS30;

            string jsonLAPS30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS30);
            ViewBag.jsonLAPS30 = jsonLAPS30;

            //18.CopperContent_30

            string jsonTimeDailyCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_30);
            ViewBag.jsonTimeDailyCopperContent_30 = jsonTimeDailyCopperContent_30;

            string jsonHCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonHCopperContent_30 = jsonHCopperContent_30;

            string jsonMCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_30);
            ViewBag.jsonMCopperContent_30 = jsonMCopperContent_30;

            string jsonLCopperContent_30 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_30);
            ViewBag.jsonLCopperContent_30 = jsonLCopperContent_30;

            //19.APS31

            string jsonTimeDailyAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_APS31);
            ViewBag.jsonTimeDailyAPS31 = jsonTimeDailyAPS31;

            string jsonHAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_APS31);
            ViewBag.jsonHAPS31 = jsonHAPS31;

            string jsonMAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_APS31);
            ViewBag.jsonMAPS31 = jsonMAPS31;

            string jsonLAPS31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_APS31);
            ViewBag.jsonLAPS31 = jsonLAPS31;

            //20.CopperContent_31

            string jsonTimeDailyCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_CopperContent_31);
            ViewBag.jsonTimeDailyCopperContent_31 = jsonTimeDailyCopperContent_31;

            string jsonHCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonHCopperContent_31 = jsonHCopperContent_31;

            string jsonMCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_CopperContent_31);
            ViewBag.jsonMCopperContent_31 = jsonMCopperContent_31;

            string jsonLCopperContent_31 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_CopperContent_31);
            ViewBag.jsonLCopperContent_31 = jsonLCopperContent_31;






            return View(model);



        }





    }
}
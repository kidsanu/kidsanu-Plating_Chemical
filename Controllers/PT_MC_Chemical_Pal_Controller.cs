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
    public class PT_MC_Chemical_Pal_Controller : Controller
    {
        //Pal 1
        public ActionResult SavePal1A(PT_MC_PAL_InputResult spt1)
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLEP03A");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePal1A(string Cancel, PT_MC_PAL_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLEP03A");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
                PT_MC_PAL_InputResult model = p.GetDataPal("PLEP03A", spt1,strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }


        //Pal 1B
        public ActionResult SavePal1B(PT_MC_PAL_InputResult spt1)
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLEP03B");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePal1B(string Cancel, PT_MC_PAL_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLEP03B");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
                PT_MC_PAL_InputResult model = p.GetDataPal("PLEP03B", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        //Pal 2C
        public ActionResult SavePal2C(PT_MC_PAL_InputResult spt1)
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLMCP01C");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePal2C(string Cancel, PT_MC_PAL_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLMCP01C");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
                PT_MC_PAL_InputResult model = p.GetDataPal("PLMCP01C", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        //Pal 2D
        public ActionResult SavePal2D(PT_MC_PAL_InputResult spt1)
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLMCP01D");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SavePal2D(string Cancel, PT_MC_PAL_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_PAL_InputResult model = objChe.GetDataPal(spt1, "PLMCP01D");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
                PT_MC_PAL_InputResult model = p.GetDataPal("PLMCP01D", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        /// Pal1A
        public ActionResult ChemicalSupplyPal1A()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLEP03A");
            return View(model);

        }
        /// 
        /// Pal1B
        public ActionResult ChemicalSupplyPal1B()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLEP03B");
            return View(model);

        }
        /// 
        /// Pal2C
        public ActionResult ChemicalSupplyPal2C()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP01C");
            return View(model);

        }
        /// 
        /// Pal2D
        public ActionResult ChemicalSupplyPal2D()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP01D");
            return View(model);

        }
        /// 


        public ActionResult InputAnalysisPal1A()
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            List<PT_MC_PAL_InputResult> model = p.GetPT_MC_InputInfoPal("PLEP03A");
            return View(model);
        }
        public ActionResult InputAnalysisPal1B()
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            List<PT_MC_PAL_InputResult> model = p.GetPT_MC_InputInfoPal("PLEP03B");
            return View(model);
        }
        public ActionResult InputAnalysisPal2C()
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            List<PT_MC_PAL_InputResult> model = p.GetPT_MC_InputInfoPal("PLMCP01C");
            return View(model);
        }
        public ActionResult InputAnalysisPal2D()
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            List<PT_MC_PAL_InputResult> model = p.GetPT_MC_InputInfoPal("PLMCP01D");
            return View(model);
        }


        public ActionResult DetailInputPal1A(int? id, string Edit, string Delete, PT_MC_PAL_InputResult res)
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPal(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPal(id);

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

        public ActionResult DetailInputPal1B(int? id, string Edit, string Delete, PT_MC_PAL_InputResult res)
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPal(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPal(id);

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

        public ActionResult DetailInputPal2C(int? id, string Edit, string Delete, PT_MC_PAL_InputResult res)
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPal(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPal(id);

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

        public ActionResult DetailInputPal2D(int? id, string Edit, string Delete, PT_MC_PAL_InputResult res)
        {
            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryPal(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_PAL_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailPal(id);

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


        //Graph Pal1A Date : 20-Aug-2020
        public ActionResult GraphPal1A(PT_MC_PAL_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();


            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            PT_MC_PAL_InputResult model = p.GetGraphPal("PLEP03A", spt1);


            string jsonTimeDaily = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX);
            ViewBag.jsonTimeDaily = jsonTimeDaily;

            string jsonH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH);
            ViewBag.jsonH = jsonH;

            string jsonM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM);
            ViewBag.jsonM = jsonM;

            string jsonL = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL);
            ViewBag.jsonL = jsonL;



            ////////////// Copper

            string jsonTimeDailyCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Copper);
            ViewBag.jsonTimeDailyCopper = jsonTimeDailyCopper;

            string jsonHCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Copper);
            ViewBag.jsonHCopper = jsonHCopper;

            string jsonMCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Copper);
            ViewBag.jsonMCopper = jsonMCopper;

            string jsonLCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Copper);
            ViewBag.jsonLCopper = jsonLCopper;

            ////////////// Sulfuric

            string jsonTimeDailySulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sulfuric);
            ViewBag.jsonTimeDailySulfuric = jsonTimeDailySulfuric;

            string jsonHSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sulfuric);
            ViewBag.jsonHSulfuric = jsonHSulfuric;

            string jsonMSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sulfuric);
            ViewBag.jsonMSulfuric = jsonMSulfuric;

            string jsonLSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sulfuric);
            ViewBag.jsonLSulfuric = jsonLSulfuric;

            ////////////// Chloride

            string jsonTimeDailyChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Chloride);
            ViewBag.jsonTimeDailyChloride = jsonTimeDailyChloride;

            string jsonHChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Chloride);
            ViewBag.jsonHChloride = jsonHChloride;

            string jsonMChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Chloride);
            ViewBag.jsonMChloride = jsonMChloride;

            string jsonLChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Chloride);
            ViewBag.jsonLChloride = jsonLChloride;

            ////////////// ST-901 AM

            string jsonTimeDailyST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901AM);
            ViewBag.jsonTimeDailyST_901AM = jsonTimeDailyST_901AM;

            string jsonHST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901AM);
            ViewBag.jsonHST_901AM = jsonHST_901AM;

            string jsonMST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901AM);
            ViewBag.jsonMST_901AM = jsonMST_901AM;

            string jsonLST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901AM);
            ViewBag.jsonLST_901AM = jsonLST_901AM;

            ////////////// ST-901 BM

            string jsonTimeDailyST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901BM);
            ViewBag.jsonTimeDailyST_901BM = jsonTimeDailyST_901BM;

            string jsonHST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901BM);
            ViewBag.jsonHST_901BM = jsonHST_901BM;

            string jsonMST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901BM);
            ViewBag.jsonMST_901BM = jsonMST_901BM;

            string jsonLST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901BM);
            ViewBag.jsonLST_901BM = jsonLST_901BM;


            return View(model);



        }



        //Graph Pal1B Date : 01-Sep-2020
        public ActionResult GraphPal1B(PT_MC_PAL_InputResult spt1) 
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();

            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            PT_MC_PAL_InputResult model = p.GetGraphPal("PLEP03B", spt1);


            string jsonTimeDaily = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX);
            ViewBag.jsonTimeDaily = jsonTimeDaily;

            string jsonH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH);
            ViewBag.jsonH = jsonH;

            string jsonM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM);
            ViewBag.jsonM = jsonM;

            string jsonL = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL);
            ViewBag.jsonL = jsonL;

            ////////////// Copper

            string jsonTimeDailyCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Copper);
            ViewBag.jsonTimeDailyCopper = jsonTimeDailyCopper;

            string jsonHCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Copper);
            ViewBag.jsonHCopper = jsonHCopper;

            string jsonMCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Copper);
            ViewBag.jsonMCopper = jsonMCopper;

            string jsonLCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Copper);
            ViewBag.jsonLCopper = jsonLCopper;

            ////////////// Sulfuric

            string jsonTimeDailySulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sulfuric);
            ViewBag.jsonTimeDailySulfuric = jsonTimeDailySulfuric;

            string jsonHSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sulfuric);
            ViewBag.jsonHSulfuric = jsonHSulfuric;

            string jsonMSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sulfuric);
            ViewBag.jsonMSulfuric = jsonMSulfuric;

            string jsonLSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sulfuric);
            ViewBag.jsonLSulfuric = jsonLSulfuric;

            ////////////// Chloride

            string jsonTimeDailyChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Chloride);
            ViewBag.jsonTimeDailyChloride = jsonTimeDailyChloride;

            string jsonHChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Chloride);
            ViewBag.jsonHChloride = jsonHChloride;

            string jsonMChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Chloride);
            ViewBag.jsonMChloride = jsonMChloride;

            string jsonLChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Chloride);
            ViewBag.jsonLChloride = jsonLChloride;

            ////////////// ST-901 AM

            string jsonTimeDailyST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901AM);
            ViewBag.jsonTimeDailyST_901AM = jsonTimeDailyST_901AM;

            string jsonHST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901AM);
            ViewBag.jsonHST_901AM = jsonHST_901AM;

            string jsonMST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901AM);
            ViewBag.jsonMST_901AM = jsonMST_901AM;

            string jsonLST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901AM);
            ViewBag.jsonLST_901AM = jsonLST_901AM;

            ////////////// ST-901 BM

            string jsonTimeDailyST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901BM);
            ViewBag.jsonTimeDailyST_901BM = jsonTimeDailyST_901BM;

            string jsonHST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901BM);
            ViewBag.jsonHST_901BM = jsonHST_901BM;

            string jsonMST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901BM);
            ViewBag.jsonMST_901BM = jsonMST_901BM;

            string jsonLST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901BM);
            ViewBag.jsonLST_901BM = jsonLST_901BM;


            return View(model);

        }




        //Graph Pal2C Date : 01-Sep-2020
        public ActionResult GraphPal2C(PT_MC_PAL_InputResult spt1)
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();

            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            PT_MC_PAL_InputResult model = p.GetGraphPal("PLMCP01C", spt1);


            string jsonTimeDaily = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX);
            ViewBag.jsonTimeDaily = jsonTimeDaily;

            string jsonH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH);
            ViewBag.jsonH = jsonH;

            string jsonM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM);
            ViewBag.jsonM = jsonM;

            string jsonL = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL);
            ViewBag.jsonL = jsonL;

            ////////////// Copper

            string jsonTimeDailyCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Copper);
            ViewBag.jsonTimeDailyCopper = jsonTimeDailyCopper;

            string jsonHCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Copper);
            ViewBag.jsonHCopper = jsonHCopper;

            string jsonMCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Copper);
            ViewBag.jsonMCopper = jsonMCopper;

            string jsonLCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Copper);
            ViewBag.jsonLCopper = jsonLCopper;

            ////////////// Sulfuric

            string jsonTimeDailySulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sulfuric);
            ViewBag.jsonTimeDailySulfuric = jsonTimeDailySulfuric;

            string jsonHSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sulfuric);
            ViewBag.jsonHSulfuric = jsonHSulfuric;

            string jsonMSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sulfuric);
            ViewBag.jsonMSulfuric = jsonMSulfuric;

            string jsonLSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sulfuric);
            ViewBag.jsonLSulfuric = jsonLSulfuric;

            ////////////// Chloride

            string jsonTimeDailyChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Chloride);
            ViewBag.jsonTimeDailyChloride = jsonTimeDailyChloride;

            string jsonHChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Chloride);
            ViewBag.jsonHChloride = jsonHChloride;

            string jsonMChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Chloride);
            ViewBag.jsonMChloride = jsonMChloride;

            string jsonLChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Chloride);
            ViewBag.jsonLChloride = jsonLChloride;

            ////////////// ST-901 AM

            string jsonTimeDailyST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901AM);
            ViewBag.jsonTimeDailyST_901AM = jsonTimeDailyST_901AM;

            string jsonHST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901AM);
            ViewBag.jsonHST_901AM = jsonHST_901AM;

            string jsonMST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901AM);
            ViewBag.jsonMST_901AM = jsonMST_901AM;

            string jsonLST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901AM);
            ViewBag.jsonLST_901AM = jsonLST_901AM;

            ////////////// ST-901 BM

            string jsonTimeDailyST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901BM);
            ViewBag.jsonTimeDailyST_901BM = jsonTimeDailyST_901BM;

            string jsonHST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901BM);
            ViewBag.jsonHST_901BM = jsonHST_901BM;

            string jsonMST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901BM);
            ViewBag.jsonMST_901BM = jsonMST_901BM;

            string jsonLST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901BM);
            ViewBag.jsonLST_901BM = jsonLST_901BM;


            return View(model);

        }



        //Graph Pal2D Date : 01-Sep-2020
        public ActionResult GraphPal2D(PT_MC_PAL_InputResult spt1)
        {
            PT_MC_Input_PalManager objChe = new PT_MC_Input_PalManager();

            PT_MC_Input_PalManager p = new PT_MC_Input_PalManager();
            PT_MC_PAL_InputResult model = p.GetGraphPal("PLMCP01D", spt1);


            string jsonTimeDaily = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX);
            ViewBag.jsonTimeDaily = jsonTimeDaily;

            string jsonH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH);
            ViewBag.jsonH = jsonH;

            string jsonM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM);
            ViewBag.jsonM = jsonM;

            string jsonL = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL);
            ViewBag.jsonL = jsonL;

            ////////////// Copper

            string jsonTimeDailyCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Copper);
            ViewBag.jsonTimeDailyCopper = jsonTimeDailyCopper;

            string jsonHCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Copper);
            ViewBag.jsonHCopper = jsonHCopper;

            string jsonMCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Copper);
            ViewBag.jsonMCopper = jsonMCopper;

            string jsonLCopper = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Copper);
            ViewBag.jsonLCopper = jsonLCopper;

            ////////////// Sulfuric

            string jsonTimeDailySulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Sulfuric);
            ViewBag.jsonTimeDailySulfuric = jsonTimeDailySulfuric;

            string jsonHSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Sulfuric);
            ViewBag.jsonHSulfuric = jsonHSulfuric;

            string jsonMSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Sulfuric);
            ViewBag.jsonMSulfuric = jsonMSulfuric;

            string jsonLSulfuric = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Sulfuric);
            ViewBag.jsonLSulfuric = jsonLSulfuric;

            ////////////// Chloride

            string jsonTimeDailyChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Chloride);
            ViewBag.jsonTimeDailyChloride = jsonTimeDailyChloride;

            string jsonHChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Chloride);
            ViewBag.jsonHChloride = jsonHChloride;

            string jsonMChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Chloride);
            ViewBag.jsonMChloride = jsonMChloride;

            string jsonLChloride = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Chloride);
            ViewBag.jsonLChloride = jsonLChloride;

            ////////////// ST-901 AM

            string jsonTimeDailyST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901AM);
            ViewBag.jsonTimeDailyST_901AM = jsonTimeDailyST_901AM;

            string jsonHST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901AM);
            ViewBag.jsonHST_901AM = jsonHST_901AM;

            string jsonMST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901AM);
            ViewBag.jsonMST_901AM = jsonMST_901AM;

            string jsonLST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901AM);
            ViewBag.jsonLST_901AM = jsonLST_901AM;

            ////////////// ST-901 BM

            string jsonTimeDailyST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901BM);
            ViewBag.jsonTimeDailyST_901BM = jsonTimeDailyST_901BM;

            string jsonHST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901BM);
            ViewBag.jsonHST_901BM = jsonHST_901BM;

            string jsonMST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901BM);
            ViewBag.jsonMST_901BM = jsonMST_901BM;

            string jsonLST_901BM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901BM);
            ViewBag.jsonLST_901BM = jsonLST_901BM;


            return View(model);

        }

    }
}
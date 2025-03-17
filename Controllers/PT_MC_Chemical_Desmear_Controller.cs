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
    public class PT_MC_Chemical_Desmear_Controller : Controller
    {
        //Desmear1
        public ActionResult SaveDesmear1(PT_MC_DESMEAR_InputResult spt1)
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM01");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveDesmear1(string Cancel, PT_MC_DESMEAR_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM01");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
                PT_MC_DESMEAR_InputResult model = p.GetDataDesmear1("PLDSM01", spt1,strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }
        }


        //Desmear2
        public ActionResult SaveDesmear2(PT_MC_DESMEAR_InputResult spt1)
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM02");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveDesmear2(string Cancel, PT_MC_DESMEAR_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM02");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
                PT_MC_DESMEAR_InputResult model = p.GetDataDesmear1("PLDSM02", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        //Desmear3
        public ActionResult SaveDesmear3(PT_MC_DESMEAR_InputResult spt1)
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM03");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveDesmear3(string Cancel, PT_MC_DESMEAR_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM03");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
                PT_MC_DESMEAR_InputResult model = p.GetDataDesmear1("PLDSM03", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        //Desmear4
        public ActionResult SaveDesmear4(PT_MC_DESMEAR_InputResult spt1)
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM04");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveDesmear4(string Cancel, PT_MC_DESMEAR_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_DESMEAR_InputResult model = objChe.GetMainDataDeamear1(spt1, "PLDSM04");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
                PT_MC_DESMEAR_InputResult model = p.GetDataDesmear1("PLDSM04", spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }

        /// Desmear1
        public ActionResult ChemicalSupplyDesmear1()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLDSM01");
            return View(model);

        }
        /// 
        /// Desmear2
        public ActionResult ChemicalSupplyDesmear2()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLDSM02");
            return View(model);

        }
        /// 
        /// Desmear3
        public ActionResult ChemicalSupplyDesmear3()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLDSM03");
            return View(model);

        }
        /// 
        /// Desmear4
        public ActionResult ChemicalSupplyDesmear4()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLDSM04");
            return View(model);

        }
        /// 


        public ActionResult InputAnalysisDesmear1()
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            List<PT_MC_DESMEAR_InputResult> model = p.GetPT_MC_InputInfoDesmear("PLDSM01");
            return View(model);
        }
        public ActionResult InputAnalysisDesmear2()
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            List<PT_MC_DESMEAR_InputResult> model = p.GetPT_MC_InputInfoDesmear("PLDSM02");
            return View(model);
        }
        public ActionResult InputAnalysisDesmear3()
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            List<PT_MC_DESMEAR_InputResult> model = p.GetPT_MC_InputInfoDesmear("PLDSM03");
            return View(model);
        }
        public ActionResult InputAnalysisDesmear4()
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            List<PT_MC_DESMEAR_InputResult> model = p.GetPT_MC_InputInfoDesmear("PLDSM04");
            return View(model);
        }


        public ActionResult DetailInputDesmear1(int? id, string Edit, string Delete, PT_MC_DESMEAR_InputResult res)
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryDesmear(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailDesmear(id);

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

        public ActionResult DetailInputDesmear2(int? id, string Edit, string Delete, PT_MC_DESMEAR_InputResult res)
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryDesmear(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailDesmear(id);

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

        public ActionResult DetailInputDesmear3(int? id, string Edit, string Delete, PT_MC_DESMEAR_InputResult res)
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryDesmear(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailDesmear(id);

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

        public ActionResult DetailInputDesmear4(int? id, string Edit, string Delete, PT_MC_DESMEAR_InputResult res)
        {
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryDesmear(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_DESMEAR_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailDesmear(id);

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


        //Graph Desmear1 Date : 19-Sep-2020
        public ActionResult GraphDesmear1(PT_MC_DESMEAR_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            PT_MC_DESMEAR_InputResult model = p.GetGraphDesmear("PLDSM01", spt1);

            ////////////// 1. 4125Bath

            string jsonTimeDaily4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Bath);
            ViewBag.jsonTimeDaily4125Bath = jsonTimeDaily4125Bath;

            string jsonH4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Bath);
            ViewBag.jsonH4125Bath = jsonH4125Bath;

            string jsonM4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Bath);
            ViewBag.jsonM4125Bath = jsonM4125Bath;

            string jsonL4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Bath);
            ViewBag.jsonL4125Bath = jsonL4125Bath;


            ////////////// 2. 4125Alkaline

            string jsonTimeDaily4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Alkaline);
            ViewBag.jsonTimeDaily4125Alkaline = jsonTimeDaily4125Alkaline;

            string jsonH4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Alkaline);
            ViewBag.jsonH4125Alkaline = jsonH4125Alkaline;

            string jsonM4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Alkaline);
            ViewBag.jsonM4125Alkaline = jsonM4125Alkaline;

            string jsonL4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Alkaline);
            ViewBag.jsonL4125Alkaline = jsonL4125Alkaline;

            ////////////// 3. Permanganate

            string jsonTimeDailyPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Permanganate);
            ViewBag.jsonTimeDailyPermanganate = jsonTimeDailyPermanganate;

            string jsonHPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Permanganate);
            ViewBag.jsonHPermanganate = jsonHPermanganate;

            string jsonMPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Permanganate);
            ViewBag.jsonMPermanganate = jsonMPermanganate;

            string jsonLPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Permanganate);
            ViewBag.jsonLPermanganate = jsonLPermanganate;

            ////////////// 4. Manganate

            string jsonTimeDailyManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Manganate);
            ViewBag.jsonTimeDailyManganate = jsonTimeDailyManganate;

            string jsonHManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Manganate);
            ViewBag.jsonHManganate = jsonHManganate;

            string jsonMManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Manganate);
            ViewBag.jsonMManganate = jsonMManganate;

            string jsonLManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Manganate);
            ViewBag.jsonLManganate = jsonLManganate;

            ////////////// 5. Alkaline

            string jsonTimeDailyAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Alkaline);
            ViewBag.jsonTimeDailyAlkaline = jsonTimeDailyAlkaline;

            string jsonHAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Alkaline);
            ViewBag.jsonHAlkaline = jsonHAlkaline;

            string jsonMAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Alkaline);
            ViewBag.jsonMAlkaline = jsonMAlkaline;

            string jsonLAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Alkaline);
            ViewBag.jsonLAlkaline = jsonLAlkaline;

            ////////////// 6. Neutralizer

            string jsonTimeDailyNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Neutralizer);
            ViewBag.jsonTimeDailyNeutralizer = jsonTimeDailyNeutralizer;

            string jsonHNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Neutralizer);
            ViewBag.jsonHNeutralizer = jsonHNeutralizer;

            string jsonMNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Neutralizer);
            ViewBag.jsonMNeutralizer = jsonMNeutralizer;

            string jsonLNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Neutralizer);
            ViewBag.jsonLNeutralizer = jsonLNeutralizer;

            ////////////// 7. NeutralizerBath

            string jsonTimeDailyNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_NeutralizerBath);
            ViewBag.jsonTimeDailyNeutralizerBath = jsonTimeDailyNeutralizerBath;

            string jsonHNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_NeutralizerBath);
            ViewBag.jsonHNeutralizerBath = jsonHNeutralizerBath;

            string jsonMNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_NeutralizerBath);
            ViewBag.jsonMNeutralizerBath = jsonMNeutralizerBath;

            string jsonLNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_NeutralizerBath);
            ViewBag.jsonLNeutralizerBath = jsonLNeutralizerBath;

            return View(model);



        }


        public ActionResult GraphDesmear2(PT_MC_DESMEAR_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();


            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            PT_MC_DESMEAR_InputResult model = p.GetGraphDesmear("PLDSM02", spt1);


            ////////////// 1. 4125Bath

            string jsonTimeDaily4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Bath);
            ViewBag.jsonTimeDaily4125Bath = jsonTimeDaily4125Bath;

            string jsonH4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Bath);
            ViewBag.jsonH4125Bath = jsonH4125Bath;

            string jsonM4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Bath);
            ViewBag.jsonM4125Bath = jsonM4125Bath;

            string jsonL4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Bath);
            ViewBag.jsonL4125Bath = jsonL4125Bath;



            ////////////// 2. 4125Alkaline

            string jsonTimeDaily4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Alkaline);
            ViewBag.jsonTimeDaily4125Alkaline = jsonTimeDaily4125Alkaline;

            string jsonH4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Alkaline);
            ViewBag.jsonH4125Alkaline = jsonH4125Alkaline;

            string jsonM4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Alkaline);
            ViewBag.jsonM4125Alkaline = jsonM4125Alkaline;

            string jsonL4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Alkaline);
            ViewBag.jsonL4125Alkaline = jsonL4125Alkaline;

            ////////////// 3. Permanganate

            string jsonTimeDailyPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Permanganate);
            ViewBag.jsonTimeDailyPermanganate = jsonTimeDailyPermanganate;

            string jsonHPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Permanganate);
            ViewBag.jsonHPermanganate = jsonHPermanganate;

            string jsonMPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Permanganate);
            ViewBag.jsonMPermanganate = jsonMPermanganate;

            string jsonLPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Permanganate);
            ViewBag.jsonLPermanganate = jsonLPermanganate;

            ////////////// 4. Manganate

            string jsonTimeDailyManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Manganate);
            ViewBag.jsonTimeDailyManganate = jsonTimeDailyManganate;

            string jsonHManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Manganate);
            ViewBag.jsonHManganate = jsonHManganate;

            string jsonMManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Manganate);
            ViewBag.jsonMManganate = jsonMManganate;

            string jsonLManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Manganate);
            ViewBag.jsonLManganate = jsonLManganate;

            ////////////// 5. Alkaline

            string jsonTimeDailyAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Alkaline);
            ViewBag.jsonTimeDailyAlkaline = jsonTimeDailyAlkaline;

            string jsonHAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Alkaline);
            ViewBag.jsonHAlkaline = jsonHAlkaline;

            string jsonMAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Alkaline);
            ViewBag.jsonMAlkaline = jsonMAlkaline;

            string jsonLAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Alkaline);
            ViewBag.jsonLAlkaline = jsonLAlkaline;

            ////////////// 6. Neutralizer

            string jsonTimeDailyNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Neutralizer);
            ViewBag.jsonTimeDailyNeutralizer = jsonTimeDailyNeutralizer;

            string jsonHNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Neutralizer);
            ViewBag.jsonHNeutralizer = jsonHNeutralizer;

            string jsonMNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Neutralizer);
            ViewBag.jsonMNeutralizer = jsonMNeutralizer;

            string jsonLNeutralizer = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Neutralizer);
            ViewBag.jsonLNeutralizer = jsonLNeutralizer;

            ////////////// 7. NeutralizerBath

            string jsonTimeDailyNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_NeutralizerBath);
            ViewBag.jsonTimeDailyNeutralizerBath = jsonTimeDailyNeutralizerBath;

            string jsonHNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_NeutralizerBath);
            ViewBag.jsonHNeutralizerBath = jsonHNeutralizerBath;

            string jsonMNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_NeutralizerBath);
            ViewBag.jsonMNeutralizerBath = jsonMNeutralizerBath;

            string jsonLNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_NeutralizerBath);
            ViewBag.jsonLNeutralizerBath = jsonLNeutralizerBath;

            return View(model);
        }


        public ActionResult GraphDesmear3(PT_MC_DESMEAR_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            PT_MC_DESMEAR_InputResult model = p.GetGraphDesmear("PLDSM03", spt1);

            ////////////// 1. 4125Bath

            string jsonTimeDaily4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Bath);
            ViewBag.jsonTimeDaily4125Bath = jsonTimeDaily4125Bath;

            string jsonH4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Bath);
            ViewBag.jsonH4125Bath = jsonH4125Bath;

            string jsonM4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Bath);
            ViewBag.jsonM4125Bath = jsonM4125Bath;

            string jsonL4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Bath);
            ViewBag.jsonL4125Bath = jsonL4125Bath;



            ////////////// 2. 4125Alkaline

            string jsonTimeDaily4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Alkaline);
            ViewBag.jsonTimeDaily4125Alkaline = jsonTimeDaily4125Alkaline;

            string jsonH4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Alkaline);
            ViewBag.jsonH4125Alkaline = jsonH4125Alkaline;

            string jsonM4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Alkaline);
            ViewBag.jsonM4125Alkaline = jsonM4125Alkaline;

            string jsonL4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Alkaline);
            ViewBag.jsonL4125Alkaline = jsonL4125Alkaline;

            ////////////// 3. Permanganate

            string jsonTimeDailyPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Permanganate);
            ViewBag.jsonTimeDailyPermanganate = jsonTimeDailyPermanganate;

            string jsonHPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Permanganate);
            ViewBag.jsonHPermanganate = jsonHPermanganate;

            string jsonMPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Permanganate);
            ViewBag.jsonMPermanganate = jsonMPermanganate;

            string jsonLPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Permanganate);
            ViewBag.jsonLPermanganate = jsonLPermanganate;

            ////////////// 4. Manganate

            string jsonTimeDailyManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Manganate);
            ViewBag.jsonTimeDailyManganate = jsonTimeDailyManganate;

            string jsonHManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Manganate);
            ViewBag.jsonHManganate = jsonHManganate;

            string jsonMManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Manganate);
            ViewBag.jsonMManganate = jsonMManganate;

            string jsonLManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Manganate);
            ViewBag.jsonLManganate = jsonLManganate;

            ////////////// 5. Alkaline

            string jsonTimeDailyAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Alkaline);
            ViewBag.jsonTimeDailyAlkaline = jsonTimeDailyAlkaline;

            string jsonHAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Alkaline);
            ViewBag.jsonHAlkaline = jsonHAlkaline;

            string jsonMAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Alkaline);
            ViewBag.jsonMAlkaline = jsonMAlkaline;

            string jsonLAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Alkaline);
            ViewBag.jsonLAlkaline = jsonLAlkaline;

            ////////////// 6. Neutralizer 2165M

            string jsonTimeDailyNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Neutralizer2165M);
            ViewBag.jsonTimeDailyNeutralizer2165M = jsonTimeDailyNeutralizer2165M;

            string jsonHNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Neutralizer2165M);
            ViewBag.jsonHNeutralizer2165M = jsonHNeutralizer2165M;

            string jsonMNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Neutralizer2165M);
            ViewBag.jsonMNeutralizer2165M = jsonMNeutralizer2165M;

            string jsonLNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Neutralizer2165M);
            ViewBag.jsonLNeutralizer2165M = jsonLNeutralizer2165M;

            ////////////// 7. NeutralizerBath

            string jsonTimeDailyNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_NeutralizerBath);
            ViewBag.jsonTimeDailyNeutralizerBath = jsonTimeDailyNeutralizerBath;

            string jsonHNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_NeutralizerBath);
            ViewBag.jsonHNeutralizerBath = jsonHNeutralizerBath;

            string jsonMNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_NeutralizerBath);
            ViewBag.jsonMNeutralizerBath = jsonMNeutralizerBath;

            string jsonLNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_NeutralizerBath);
            ViewBag.jsonLNeutralizerBath = jsonLNeutralizerBath;

            return View(model);
        }

        public ActionResult GraphDesmear4(PT_MC_DESMEAR_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_DesmearManager objChe = new PT_MC_Input_DesmearManager();
            PT_MC_Input_DesmearManager p = new PT_MC_Input_DesmearManager();
            PT_MC_DESMEAR_InputResult model = p.GetGraphDesmear("PLDSM04", spt1);

            ////////////// 1. 4125Bath

            string jsonTimeDaily4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Bath);
            ViewBag.jsonTimeDaily4125Bath = jsonTimeDaily4125Bath;

            string jsonH4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Bath);
            ViewBag.jsonH4125Bath = jsonH4125Bath;

            string jsonM4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Bath);
            ViewBag.jsonM4125Bath = jsonM4125Bath;

            string jsonL4125Bath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Bath);
            ViewBag.jsonL4125Bath = jsonL4125Bath;



            ////////////// 2. 4125Alkaline

            string jsonTimeDaily4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_4125Alkaline);
            ViewBag.jsonTimeDaily4125Alkaline = jsonTimeDaily4125Alkaline;

            string jsonH4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_4125Alkaline);
            ViewBag.jsonH4125Alkaline = jsonH4125Alkaline;

            string jsonM4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_4125Alkaline);
            ViewBag.jsonM4125Alkaline = jsonM4125Alkaline;

            string jsonL4125Alkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_4125Alkaline);
            ViewBag.jsonL4125Alkaline = jsonL4125Alkaline;

            ////////////// 3. Permanganate

            string jsonTimeDailyPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Permanganate);
            ViewBag.jsonTimeDailyPermanganate = jsonTimeDailyPermanganate;

            string jsonHPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Permanganate);
            ViewBag.jsonHPermanganate = jsonHPermanganate;

            string jsonMPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Permanganate);
            ViewBag.jsonMPermanganate = jsonMPermanganate;

            string jsonLPermanganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Permanganate);
            ViewBag.jsonLPermanganate = jsonLPermanganate;

            ////////////// 4. Manganate

            string jsonTimeDailyManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Manganate);
            ViewBag.jsonTimeDailyManganate = jsonTimeDailyManganate;

            string jsonHManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Manganate);
            ViewBag.jsonHManganate = jsonHManganate;

            string jsonMManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Manganate);
            ViewBag.jsonMManganate = jsonMManganate;

            string jsonLManganate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Manganate);
            ViewBag.jsonLManganate = jsonLManganate;

            ////////////// 5. Alkaline

            string jsonTimeDailyAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Alkaline);
            ViewBag.jsonTimeDailyAlkaline = jsonTimeDailyAlkaline;

            string jsonHAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Alkaline);
            ViewBag.jsonHAlkaline = jsonHAlkaline;

            string jsonMAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Alkaline);
            ViewBag.jsonMAlkaline = jsonMAlkaline;

            string jsonLAlkaline = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Alkaline);
            ViewBag.jsonLAlkaline = jsonLAlkaline;

            ////////////// 6. Neutralizer 2165M

            string jsonTimeDailyNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Neutralizer2165M);
            ViewBag.jsonTimeDailyNeutralizer2165M = jsonTimeDailyNeutralizer2165M;

            string jsonHNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Neutralizer2165M);
            ViewBag.jsonHNeutralizer2165M = jsonHNeutralizer2165M;

            string jsonMNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Neutralizer2165M);
            ViewBag.jsonMNeutralizer2165M = jsonMNeutralizer2165M;

            string jsonLNeutralizer2165M = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Neutralizer2165M);
            ViewBag.jsonLNeutralizer2165M = jsonLNeutralizer2165M;

            ////////////// 7. NeutralizerBath

            string jsonTimeDailyNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_NeutralizerBath);
            ViewBag.jsonTimeDailyNeutralizerBath = jsonTimeDailyNeutralizerBath;

            string jsonHNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_NeutralizerBath);
            ViewBag.jsonHNeutralizerBath = jsonHNeutralizerBath;

            string jsonMNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_NeutralizerBath);
            ViewBag.jsonMNeutralizerBath = jsonMNeutralizerBath;

            string jsonLNeutralizerBath = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_NeutralizerBath);
            ViewBag.jsonLNeutralizerBath = jsonLNeutralizerBath;

            return View(model);
        }


    }
}
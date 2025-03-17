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
    public class PT_MC_Chemical_Almex_Controller : Controller
    {
        //Almex
        public ActionResult SaveAlmex(PT_MC_ALMEX_InputResult spt1)
        {
            PT_MC_Input_AlmexManager objChe = new PT_MC_Input_AlmexManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_ALMEX_InputResult model = objChe.GetDataAlmex(spt1, "PLEP01");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveAlmex(string Cancel, PT_MC_ALMEX_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_Input_AlmexManager objChe = new PT_MC_Input_AlmexManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_ALMEX_InputResult model = objChe.GetDataAlmex(spt1, "PLEP01");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_Input_AlmexManager p = new PT_MC_Input_AlmexManager();
                PT_MC_ALMEX_InputResult model = p.GetDataAlmex(spt1,strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }


        public ActionResult InputAnalysisAlmex()
        {
            PT_MC_Input_AlmexManager p = new PT_MC_Input_AlmexManager();
            List<PT_MC_ALMEX_InputResult> model = p.GetPT_MC_InputInfoAlmex("PLEP01");
            return View(model);
        }


        public ActionResult DetailInputAlmex(int? id, string Edit, string Delete, PT_MC_ALMEX_InputResult res)
        {
            PT_MC_Input_AlmexManager p = new PT_MC_Input_AlmexManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_ALMEX_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistoryAlmex(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_ALMEX_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatailAlmex(id);

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


        //Graph Almex Date : 20-Aug-2020
        public ActionResult GraphAlmex(PT_MC_ALMEX_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_Input_AlmexManager objChe = new PT_MC_Input_AlmexManager();

            //if (spt1.PART_NO != null)
            //{
            //    objChe.SaveEleProtek1(spt1);
            //    return View();
            //}
            //else
            //{

            PT_MC_Input_AlmexManager p = new PT_MC_Input_AlmexManager();
            PT_MC_ALMEX_InputResult model = p.GetGraphAlmex(spt1);


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

            ////////////// HS200 PART A

            string jsonTimeDailyHS200PARTA1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_HS200PARTA1);
            ViewBag.jsonTimeDailyHS200PARTA1 = jsonTimeDailyHS200PARTA1;

            string jsonHHS200PARTA1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_HS200PARTA1);
            ViewBag.jsonHHS200PARTA1 = jsonHHS200PARTA1;

            string jsonMHS200PARTA1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_HS200PARTA1);
            ViewBag.jsonMHS200PARTA1 = jsonMHS200PARTA1;

            string jsonLHS200PARTA1 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_HS200PARTA1);
            ViewBag.jsonLHS200PARTA1 = jsonLHS200PARTA1;

            ////////////// HS200 PART B

            string jsonTimeDailyHS200PARTB = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_HS200PARTB);
            ViewBag.jsonTimeDailyHS200PARTB = jsonTimeDailyHS200PARTB;

            string jsonHHS200PARTB = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_HS200PARTB);
            ViewBag.jsonHHS200PARTB = jsonHHS200PARTB;

            string jsonMHS200PARTB = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_HS200PARTB);
            ViewBag.jsonMHS200PARTB = jsonMHS200PARTB;

            string jsonLHS200PARTB = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_HS200PARTB);
            ViewBag.jsonLHS200PARTB = jsonLHS200PARTB;


            return View(model);



        }




    }
}
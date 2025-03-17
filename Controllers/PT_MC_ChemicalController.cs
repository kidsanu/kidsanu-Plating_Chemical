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
    public class PT_MC_ChemicalController : Controller
    {
        // GET: PT_MC_Chemical
        public ActionResult Index()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP02");
            return View(model);


        }
        //[HttpPost]
        public ActionResult Save(PT_MC_ChemicalInfo ss)
        {
            PT_MC_ChemicalManager objChe = new PT_MC_ChemicalManager();

            if (ss.PART_NO != null)
            {
                objChe.AddMasterData(ss);
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult HomeNew()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP02");
            return View(model);
        }


        public ActionResult ChemicalSupplyProtek1()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP02");
            return View(model);
        }
        public ActionResult ChemicalSupplyProtek2()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            //List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfosProtek2();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP03");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek3()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP04");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek4()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP05");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek5()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP06");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek6()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP07");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek7()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP08");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek8()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP09");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek9A()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP10A");
            return View(model);

        }
        public ActionResult ChemicalSupplyProtek9B()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLMCP10B");
            return View(model);

        }

        /// Almex
        public ActionResult ChemicalSupplyAlmex()
        {
            PT_MC_ChemicalManager p = new PT_MC_ChemicalManager();
            //PT_MC_ChemicalInfo model = new PT_MC_ChemicalInfo();
            List<PT_MC_ChemicalInfo> model = p.GetPT_MC_ChemicalInfos("PLEP01");
            return View(model);

        }
        /// 

        public ActionResult CreateProtek1()
        {

            return View();
        }


        public ActionResult DetailInputProtek1(int? id,string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if ( Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res,id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek2(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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

        public ActionResult DetailInputProtek3(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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


        public ActionResult DetailInputProtek4(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek5(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek6(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek7(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek8(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek9A(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        public ActionResult DetailInputProtek9B(int? id, string Edit, string Delete, PT_MC_InputResult res)
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            int idedit = Convert.ToInt32(id);

            if (Edit == null && Delete == null)
            {
                //PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByHistory(res, id);
                ViewBag.Name = model.EMPLOYEE_NAME;
                ViewBag.Dated = model.DATED;
                ViewBag.Shift = model.SHIFT;
                ViewBag.Timed = model.TIMED;

                return View(model);
            }
            else if (Edit == "Edit")
            {
                p.UpdateDataInputResult(idedit, res);
                PT_MC_InputResult model = p.GetPT_MC_ChemicalInfos_ByDatail(id);

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
        //public ActionResult EditAnalysisResult(PT_MC_InputResult ss)
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult CalFormula(PT_MC_InputResult cal1)
        //{

        //    PT_MC_InputManager objCal = new PT_MC_InputManager();
        //    PT_MC_InputResult model = objCal.GetDataCalculator(cal1);
        //    //PT_MC_InputResult model = objCal.(cal1);

        //    // PT_MC_InputManager objCal = new PT_MC_InputManager();
        //    return View("SaveProtek1");
        //    //return View(model);


        //}

        // Old PT_MC_InputResult spt1, string cal1,string Save1, string cal2, string Save2, string cal3, string Save3, string cal4, string Save4, string cal5, string Save5, string cal6, string Save6, string cal7, string Save7, string cal8, string Save8, string Save9, string cal10, string Save10, string cal11, string Save11

        public ActionResult SaveProtek1(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek1Main(spt1);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek1(string Cancel, PT_MC_InputResult spt1,string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1,string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek1Main(spt1);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                //if (spt1.EMPLOYEE_CODE != null && spt1.SHIFT != null && spt1.TIMED != null)
                //{

                //    PT_MC_InputResult model = objChe.GetDataProtek1Main(spt1);
                //    ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                //    return View(model);
                //}

                //cal1, Save1, cal2, Save2, cal3, Save3, cal4, Save4, cal5, Save5, cal6, Save6, cal7, Save7, cal8, Save8 , Save9, cal10, Save10, cal11, Save11
                //else
                //{
                    PT_MC_InputManager p = new PT_MC_InputManager();
                    PT_MC_InputResult model = p.GetDataProtek1(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                    ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);

                //return View(model);



                //}
            }
                
                //else
                //{


                //    PT_MC_InputResult model = objChe.GetDataProtek1Main(spt1);
                //    ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

                //    return View(model);
                //}
            }
        public ActionResult SaveProtek2(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP03");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
            
            return View(model);

        }

        [HttpPost]

        //Protek2 Date : 14-Jan-2020

        //PT_MC_InputResult spt1, string cal1, string Save1, string cal2, string Save2, string cal3, string Save3, string cal4, string Save4, string cal5, string Save5, string cal6, string Save6, string cal7, string Save7, string cal8, string Save8,string cal9, string Save9, string cal10, string Save10, string cal11, string Save11, string cal12, string Save12
        // Modify Date : 17-Feb-2020
        public ActionResult SaveProtek2(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11, string Tritrate12, string ResultCal12)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP03");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
              


                    //else
                   // {
                        PT_MC_InputManager p = new PT_MC_InputManager();
                        PT_MC_InputResult model = p.GetDataProtek2(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11, Tritrate12, ResultCal12);
                        ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                        TempData["testmsg"] = "<script>alert('Successfully');</script>";
                        return View(model);
                    //}
                //}
               // else
               // {


                 //   PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1);
                  //  ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

                  //  return View(model);
                }

            }

        public ActionResult SaveProtek3(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP04");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }

        [HttpPost]

        //Protek2 Date : 14-Jan-2020

        //PT_MC_InputResult spt1, string cal1, string Save1, string cal2, string Save2, string cal3, string Save3, string cal4, string Save4, string cal5, string Save5, string cal6, string Save6, string cal7, string Save7, string cal8, string Save8,string cal9, string Save9, string cal10, string Save10, string cal11, string Save11, string cal12, string Save12
        // Modify Date : 17-Feb-2020
        public ActionResult SaveProtek3(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP04");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {



                //else
                // {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek3(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
                //}
                //}
                // else
                // {


                //   PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1);
                //  ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

                //  return View(model);
            }

        }
        //}
        public ActionResult SaveProtek4(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP05");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek4(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP05");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek4(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }
        public ActionResult SaveProtek5(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP06");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek5(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP06");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek5(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }
        public ActionResult SaveProtek6(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP07");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek6(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP07");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek6(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }
        public ActionResult SaveProtek7(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP08");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek7(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP08");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek7(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }
        public ActionResult SaveProtek8(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP09");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek8(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP09");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek8(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }
        public ActionResult SaveProtek9A(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP10A");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek9A(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP10A");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek9A(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }
        public ActionResult SaveProtek9B(PT_MC_InputResult spt1)
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            //PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP10B");
            ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);

            return View(model);

        }
        [HttpPost]
        public ActionResult SaveProtek9B(string Cancel, PT_MC_InputResult spt1, string[] strtest, string[] strchemicalTank, string[] strchemicalTank_id, string Tritrate1, string ResultCal, string Tritrate2, string ResultCal2, string Tritrate3, string ResultCal3, string Tritrate4, string ResultCal4, string Tritrate5, string ResultCal5, string Tritrate6, string ResultCal6, string Tritrate7, string ResultCal7, string Tritrate8, string ResultCal8, string Tritrate9, string ResultCal9, string Tritrate10, string ResultCal10, string Tritrate11, string ResultCal11)
        {

            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PersonManager ps = new PersonManager();

            if (spt1.EMPLOYEE_CODE == null || Cancel == "Cancel")
            {
                //PT_MC_InputManager objChe = new PT_MC_InputManager();
                PT_MC_InputResult model = objChe.GetDataProtek2Main(spt1, "PLMCP10B");
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                return View(model);
            }
            else
            {
                PT_MC_InputManager p = new PT_MC_InputManager();
                PT_MC_InputResult model = p.GetDataProtek9B(spt1, strchemicalTank, strchemicalTank_id, Tritrate1, ResultCal, Tritrate2, ResultCal2, Tritrate3, ResultCal3, Tritrate4, ResultCal4, Tritrate5, ResultCal5, Tritrate6, ResultCal6, Tritrate7, ResultCal7, Tritrate8, ResultCal8, Tritrate9, ResultCal9, Tritrate10, ResultCal10, Tritrate11, ResultCal11);
                ViewBag.Name = ps.GetPersonName(spt1.EMPLOYEE_CODE);
                TempData["testmsg"] = "<script>alert('Successfully');</script>";
                return View(model);
            }

        }



        public ActionResult GraphProtek1(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();

            //if (spt1.PART_NO != null)
            //{
            //    objChe.SaveEleProtek1(spt1);
            //    return View();
            //}
            //else
            //{

             PT_MC_InputManager p = new PT_MC_InputManager();
             PT_MC_InputResult model = p.GetGraphProtek1(spt1);


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



        public ActionResult GraphProtek2(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();

            //if (spt1.PART_NO != null)
            //{
            //    objChe.SaveEleProtek1(spt1);
            //    return View();
            //}
            //else
            //{

            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek2(spt1);


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

            ////////////// EVF Brightener  

            string jsonTimeDailyEVFBRIGH = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_EVFBRIGH);
            ViewBag.jsonTimeDailyEVFBRIGH = jsonTimeDailyEVFBRIGH;

            string jsonHEVFBRIGH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_EVFBRIGH);
            ViewBag.jsonHEVFBRIGH = jsonHEVFBRIGH;

            string jsonMEVFBRIGH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_EVFBRIGH);
            ViewBag.jsonMEVFBRIGH = jsonMEVFBRIGH;

            string jsonLEVFBRIGH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_EVFBRIGH);
            ViewBag.jsonLEVFBRIGH = jsonLEVFBRIGH;

            ////////////// EVF Leveller

            string jsonTimeDailyLEVELLER = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_LEVELLER);
            ViewBag.jsonTimeDailyLEVELLER = jsonTimeDailyLEVELLER;

            string jsonHLEVELLER = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_LEVELLER);
            ViewBag.jsonHLEVELLER = jsonHLEVELLER;

            string jsonMLEVELLER = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_LEVELLER);
            ViewBag.jsonMLEVELLER = jsonMLEVELLER;

            string jsonLLEVELLER = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_LEVELLER);
            ViewBag.jsonLLEVELLER = jsonLLEVELLER;

            ////////////// EVF C-2

            string jsonTimeDailyEVF_C2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_EVF_C2);
            ViewBag.jsonTimeDailyEVF_C2 = jsonTimeDailyEVF_C2;

            string jsonHEVF_C2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_EVF_C2);
            ViewBag.jsonHEVF_C2 = jsonHEVF_C2;

            string jsonMEVF_C2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_EVF_C2);
            ViewBag.jsonMEVF_C2 = jsonMEVF_C2;

            string jsonLEVF_C2 = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_EVF_C2);
            ViewBag.jsonLEVF_C2 = jsonLEVF_C2;

            return View(model);


        }
        //Graph Protek 3 Date : 18-Dec-2019
        public ActionResult GraphProtek3(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();

            //if (spt1.PART_NO != null)
            //{
            //    objChe.SaveEleProtek1(spt1);
            //    return View();
            //}
            //else
            //{

            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtex3(spt1);


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
        public ActionResult GraphProtek4(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek4(spt1);

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

            ////////////// ST-901AM

            string jsonTimeDailyST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901AM);
            ViewBag.jsonTimeDailyST_901AM = jsonTimeDailyST_901AM;

            string jsonHST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901AM);
            ViewBag.jsonHST_901AM = jsonHST_901AM;

            string jsonMST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901AM);
            ViewBag.jsonMST_901AM = jsonMST_901AM;

            string jsonLST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901AM);
            ViewBag.jsonLST_901AM = jsonLST_901AM;

            ////////////// ST-901BM

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
        public ActionResult GraphProtek5(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek5(spt1);

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

            ////////////// ST-901AM

            string jsonTimeDailyST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_ST_901AM);
            ViewBag.jsonTimeDailyST_901AM = jsonTimeDailyST_901AM;

            string jsonHST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_ST_901AM);
            ViewBag.jsonHST_901AM = jsonHST_901AM;

            string jsonMST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_ST_901AM);
            ViewBag.jsonMST_901AM = jsonMST_901AM;

            string jsonLST_901AM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_ST_901AM);
            ViewBag.jsonLST_901AM = jsonLST_901AM;

            ////////////// ST-901BM

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
        public ActionResult GraphProtek6(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek6(spt1);

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
        public ActionResult GraphProtek7(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek7(spt1);

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
        public ActionResult GraphProtek8(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek8(spt1);

            ////////////// Melplate

            string jsonTimeDailyMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Melplate);
            ViewBag.jsonTimeDailyMelplate = jsonTimeDailyMelplate;

            string jsonHMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Melplate);
            ViewBag.jsonHMelplate = jsonHMelplate;

            string jsonMMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Melplate);
            ViewBag.jsonMMelplate = jsonMMelplate;

            string jsonLMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Melplate);
            ViewBag.jsonLMelplate = jsonLMelplate;

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
        public ActionResult GraphProtek9A(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek9A(spt1);

            ////////////// Melplate
            string jsonTimeDailyMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX_Melplate);
            ViewBag.jsonTimeDailyMelplate = jsonTimeDailyMelplate;

            string jsonHMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH_Melplate);
            ViewBag.jsonHMelplate = jsonHMelplate;

            string jsonMMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM_Melplate);
            ViewBag.jsonMMelplate = jsonMMelplate;

            string jsonLMelplate = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL_Melplate);
            ViewBag.jsonLMelplate = jsonLMelplate;

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
        public ActionResult GraphProtek9B(PT_MC_InputResult spt1)  //PT_MC_InputResult spt1
        {
            PT_MC_InputManager objChe = new PT_MC_InputManager();
            PT_MC_InputManager p = new PT_MC_InputManager();
            PT_MC_InputResult model = p.GetGraphProtek9B(spt1);

            //string jsonTimeDaily = Newtonsoft.Json.JsonConvert.SerializeObject(model.strDailyX);
            //ViewBag.jsonTimeDaily = jsonTimeDaily;

            //string jsonH = Newtonsoft.Json.JsonConvert.SerializeObject(model.douH);
            //ViewBag.jsonH = jsonH;

            //string jsonM = Newtonsoft.Json.JsonConvert.SerializeObject(model.douM);
            //ViewBag.jsonM = jsonM;

            //string jsonL = Newtonsoft.Json.JsonConvert.SerializeObject(model.douL);
            //ViewBag.jsonL = jsonL;

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

            ////////////// HS200 PART B

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
        public ActionResult InputAnalysis()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfos();
            return View(model);
        }
        public ActionResult InputAnalysisProtek2()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP03");
            return View(model);
        }

        public ActionResult InputAnalysisProtek3()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP04");
            return View(model);
        }
        public ActionResult InputAnalysisProtek4()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP05");
            return View(model);
        }
        public ActionResult InputAnalysisProtek5()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP06");
            return View(model);
        }
        public ActionResult InputAnalysisProtek6()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP07");
            return View(model);
        }
        public ActionResult InputAnalysisProtek7()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP08");
            return View(model);
        }
        public ActionResult InputAnalysisProtek8()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP09");
            return View(model);
        }
        public ActionResult InputAnalysisProtek9A()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP10A");
            return View(model);
        }
        public ActionResult InputAnalysisProtek9B()
        {
            PT_MC_InputManager p = new PT_MC_InputManager();
            List<PT_MC_InputResult> model = p.GetPT_MC_InputInfosProtek2("PLMCP10B");
            return View(model);
        }

      


        public ActionResult CreateAnalysis(PT_MC_InputResult pt1 ,int aa)
        {
            PT_MC_InputManager objpt1 = new PT_MC_InputManager();

            if (pt1.MACHINE_CODE != null)
            {
                //objpt1.AddDataAnalysis(pt1,0);
                return View();
            }
            else
            {
                return View();
            }
        }


        public ActionResult WebGridTableExample()
        {
            List<Work> model = new List<Work>() {
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" },
                   new Work() { Id=1, Name="aaaaaaaa" }
            };
            return View(model);

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class PT_MC_PTH_InputResult
    {
        public PT_MC_PTH_InputResult()
        {
            this.PT_MC_PTH_InputResultList = new List<PT_MC_PTH_InputResult>();
        }
        public List<PT_MC_PTH_InputResult> PT_MC_PTH_InputResultList { get; set; }
        [Display(Name = "Transaction ID :")]
        public int TRANSACTION_ID { get; set; }
        [Display(Name = "Machine Code :")]
        public string MACHINE_CODE { get; set; }
        [Display(Name = "Machine Name :")]
        public string MACHINE_NAME { get; set; }
        [Display(Name = "Part No. :")]
        public string PART_NO { get; set; }
        public string CHECK_POINT { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date :")]
        public DateTime DATED { get; set; }

        [Display(Name = "Time :")]
        public string TIMED { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date :")]
        public DateTime DATED_APPLIED { get; set; }
        [Display(Name = "Employee Code :")]
        public string EMPLOYEE_CODE { get; set; }
        [Display(Name = "Employee Name :")]
        public string EMPLOYEE_NAME { get; set; }

        [Display(Name = "Tritrate :")]
        public double? TRITRATE { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE2 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE3 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE4 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE5 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE6 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE7 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE8 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE9 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE10 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE11 { get; set; }

        public double? TRITRATE12 { get; set; }
        public double? TRITRATE13 { get; set; }
        public double? TRITRATE14 { get; set; }
        public double? TRITRATE15 { get; set; }
        public double? TRITRATE16 { get; set; }
        public double? TRITRATE17 { get; set; }
        public double? TRITRATE18 { get; set; }
        public double? TRITRATE19 { get; set; }
        public double? TRITRATE20 { get; set; }


        public double? STD5 { get; set; }
        public double? STD7 { get; set; }



        public double RES { get; set; }

        [Display(Name = "Actual Supply :")]
        public double? ACTUAL_SUPPLY { get; set; }

        public double? ACTUAL_SUPPLY2 { get; set; }
        public double? ACTUAL_SUPPLY3 { get; set; }
        public double? ACTUAL_SUPPLY4 { get; set; }
        public double? ACTUAL_SUPPLY5 { get; set; }
        public double? ACTUAL_SUPPLY6 { get; set; }
        public double? ACTUAL_SUPPLY7 { get; set; }
        public double? ACTUAL_SUPPLY8 { get; set; }
        public double? ACTUAL_SUPPLY9 { get; set; }
        public double? ACTUAL_SUPPLY10 { get; set; }
        public double? ACTUAL_SUPPLY11 { get; set; }
        public double? ACTUAL_SUPPLY12 { get; set; }
        public double? ACTUAL_SUPPLY13 { get; set; }
        public double? ACTUAL_SUPPLY14 { get; set; }
        public double? ACTUAL_SUPPLY15 { get; set; }
        public double? ACTUAL_SUPPLY16 { get; set; }
        public double? ACTUAL_SUPPLY17 { get; set; }
        public double? ACTUAL_SUPPLY18 { get; set; }
        public double? ACTUAL_SUPPLY19 { get; set; }
        public double? ACTUAL_SUPPLY20 { get; set; }


        //For PTH
        public int[] intNoPTH = new int[20];
        public string[] strPartNoPTH = new string[20];
        public string[] strMachineCodePTH = new string[20];
        public string[] strchemicalTankPTH = new string[20];
        public string[] strchemicalTank_idPTH = new string[20];
        public string[] stranalysisItemPTH = new string[20];
        public double[] douSTDPTH = new double[20];
        public double[] douTritratePTH = new double[20];
        public string[] strWorkPTH = new string[20];
        public string[] strRepPTH = new string[20];
        public double[] douActualPTH = new double[20];
        public string[] strRemarkPTH = new string[20];



        [Display(Name = "Shift :")]
        public string SHIFT { get; set; }
        [Display(Name = "Work :")]
        public string WORKING { get; set; }
        public string WORKING9 { get; set; }
        public string WORKING10 { get; set; }

        [Display(Name = "Rep.Cal :")]
        public string REP_CALC { get; set; }
        public string REP_CALC9 { get; set; }
        public string REP_CALC10 { get; set; }
        public string REP_CALC11 { get; set; }
        public string REP_CALC12 { get; set; }

        public string REMARK { get; set; }
        [Display(Name = "Chemical Tank ID :")]
        public string CHEMICAL_TANK_ID { get; set; }
        [Display(Name = "Chemical Tank Name :")]
        public string CHEMICAL_TANK_NAME { get; set; }
        [Display(Name = "Chemical Name :")]
        public string CHEMICAL_NAME { get; set; }





        public string strPersonName;


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Monthly :")]
        public string START_DATED { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "End Date :")]
        public DateTime END_DATED { get; set; }



        //1.Cu Electroless (2.0 - 2.8 g/L)

        public string[] strDailyX_CuElectroless = new string[] { };
        public double[] douL_CuElectroless = new double[] { };
        public double[] douM_CuElectroless = new double[] { };
        public double[] douH_CuElectroless = new double[] { };

        //2.EDTA Elextroless (14-30 g/L)

        public string[] strDailyX_EDTAElextroless = new string[] { };
        public double[] douL_EDTAElextroless = new double[] { };
        public double[] douM_EDTAElextroless = new double[] { };
        public double[] douH_EDTAElextroless = new double[] { };

        //3.Sodium hydroxide

        public string[] strDailyX_Sodiumhydroxide = new string[] { };
        public double[] douL_Sodiumhydroxide = new double[] { };
        public double[] douM_Sodiumhydroxide = new double[] { };
        public double[] douH_Sodiumhydroxide = new double[] { };

        //4.Formaldahyde

        public string[] strDailyX_Formaldahyde = new string[] { };
        public double[] douL_Formaldahyde = new double[] { };
        public double[] douM_Formaldahyde = new double[] { };
        public double[] douH_Formaldahyde = new double[] { };

        //5.CleanerBath

        public string[] strDailyX_CleanerBath = new string[] { };
        public double[] douL_CleanerBath = new double[] { };
        public double[] douM_CleanerBath = new double[] { };
        public double[] douH_CleanerBath = new double[] { };

        //6.CopperContent

        public string[] strDailyX_CopperContent = new string[] { };
        public double[] douL_CopperContent = new double[] { };
        public double[] douM_CopperContent = new double[] { };
        public double[] douH_CopperContent = new double[] { };

        //7.Acid1

        public string[] strDailyX_Acid1 = new string[] { };
        public double[] douL_Acid1 = new double[] { };
        public double[] douM_Acid1 = new double[] { };
        public double[] douH_Acid1 = new double[] { };

        //8.Acid2

        public string[] strDailyX_Acid2 = new string[] { };
        public double[] douL_Acid2 = new double[] { };
        public double[] douM_Acid2 = new double[] { };
        public double[] douH_Acid2 = new double[] { };

        //9.PredipSG

        public string[] strDailyX_PredipSG = new string[] { };
        public double[] douL_PredipSG = new double[] { };
        public double[] douM_PredipSG = new double[] { };
        public double[] douH_PredipSG = new double[] { };

        //10.CopperContent_PreDip

        public string[] strDailyX_CopperContent_PreDip = new string[] { };
        public double[] douL_CopperContent_PreDip = new double[] { };
        public double[] douM_CopperContent_PreDip = new double[] { };
        public double[] douH_CopperContent_PreDip = new double[] { };

        //11.CatalystSG

        public string[] strDailyX_CatalystSG = new string[] { };
        public double[] douL_CatalystSG = new double[] { };
        public double[] douM_CatalystSG = new double[] { };
        public double[] douH_CatalystSG = new double[] { };

        //12.Palladium

        public string[] strDailyX_Palladium = new string[] { };
        public double[] douL_Palladium = new double[] { };
        public double[] douM_Palladium = new double[] { };
        public double[] douH_Palladium = new double[] { };

        //13.Cat44SnCl

        public string[] strDailyX_Cat44SnCl = new string[] { };
        public double[] douL_Cat44SnCl = new double[] { };
        public double[] douM_Cat44SnCl = new double[] { };
        public double[] douH_Cat44SnCl = new double[] { };


        //14.CatNormality

        public string[] strDailyX_CatNormality = new string[] { };
        public double[] douL_CatNormality = new double[] { };
        public double[] douM_CatNormality = new double[] { };
        public double[] douH_CatNormality = new double[] { };

        //15.AccNormality

        public string[] strDailyX_AccNormality = new string[] { };
        public double[] douL_AccNormality = new double[] { };
        public double[] douM_AccNormality = new double[] { };
        public double[] douH_AccNormality = new double[] { };

        //16.CopperContent_Acc

        public string[] strDailyX_CopperContent_Acc = new string[] { };
        public double[] douL_CopperContent_Acc = new double[] { };
        public double[] douM_CopperContent_Acc = new double[] { };
        public double[] douH_CopperContent_Acc = new double[] { };

        //17.APS30

        public string[] strDailyX_APS30 = new string[] { };
        public double[] douL_APS30 = new double[] { };
        public double[] douM_APS30 = new double[] { };
        public double[] douH_APS30 = new double[] { };

        //18.CopperContent_30

        public string[] strDailyX_CopperContent_30 = new string[] { };
        public double[] douL_CopperContent_30 = new double[] { };
        public double[] douM_CopperContent_30 = new double[] { };
        public double[] douH_CopperContent_30 = new double[] { };


        //19.APS31

        public string[] strDailyX_APS31 = new string[] { };
        public double[] douL_APS31 = new double[] { };
        public double[] douM_APS31 = new double[] { };
        public double[] douH_APS31 = new double[] { };

        //20.CopperContent_31

        public string[] strDailyX_CopperContent_31 = new string[] { };
        public double[] douL_CopperContent_31 = new double[] { };
        public double[] douM_CopperContent_31 = new double[] { };
        public double[] douH_CopperContent_31 = new double[] { };




    }
}